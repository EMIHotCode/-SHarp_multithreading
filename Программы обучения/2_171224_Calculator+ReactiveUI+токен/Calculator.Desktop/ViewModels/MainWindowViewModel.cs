using System.Reactive;
using Calculator.Core;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Calculator.Desktop.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    private CancellationTokenSource _ctsCalculateSum;  // для каждой задачи создают свой токен отмены чтобы они не пересекались (отменяли чтото одно а не все). _cts универсалная практикующаяся приставка
    private CancellationTokenSource _ctsCalculateFactorial;

    private int? _numberStartNum = null;
    private long? _startSum = null;
    private int? _numberFactorial;
   
    [Reactive] public string? InputNumberText { get; set; }  // наблюдаемые свойства в реактивном исполнении Fody
    [Reactive] public string? OutputSumText { get; set; }
    [Reactive] public string? OutputFactorialText { get; set; }
    
    [Reactive] public double ProgressSumValue { get; set; }
    [Reactive] public double ProgressFactorialValue { get; set; }
    
    [Reactive] public string? StatusCalculateSum { get; set; }
    [Reactive] public string? StatusCalculateFactorial { get; set; }
    
    public ReactiveCommand<Unit, Unit> CommandCalculateSumStart { get; } // <Unit, Unit> ничего не передается и ничего не возвращается в качестве результата
    public ReactiveCommand<Unit, Unit> CommandCalculateSumStop { get; }
    
    public ReactiveCommand<Unit, Unit> CommandCalculateFactorialStart { get; }
    public ReactiveCommand<Unit, Unit> CommandCalculateFactorialStop { get; }

    public MainWindowViewModel()
    {
        IObservable<bool> canExecuteCalculateSumStart = this.WhenAnyValue(   // можем ли выполнить CommandCalculateSumStart. WhenAnyValue - Когда поле ввода числа будет не пустым 
            p1 => p1.InputNumberText,  // свойство за которым будем наблюдать InputNumberText
            p1 => !string.IsNullOrWhiteSpace(p1));         // обработка этого свойства и возврат булевского значения. WhiteSpace - это пробелы заместо символов
            // CommandCalculateSumStart  - обработчик события когда кнопка старт активна\неактивна
            // canExecuteCalculateSumStart будет записываться каждый раз когда меняется значение InputNumberText.  IObservable<bool> canExecuteCalculateSumStart попадает в реактивную команду CommandCalculateSumStart
            
        var canExecuteCalculateSumStop = this.WhenAnyValue(
            p => p.ProgressSumValue,
            p => p > 0); 

        CommandCalculateSumStart = ReactiveCommand.CreateFromTask(
            execute: async () =>
            {
                _ctsCalculateSum = new CancellationTokenSource();  // создаем источник токена отмены. создаем новый так как сам он не обнуляется в случае чего (когда в CommandCalculateSumStop вызовем Stop, то повторно запустить нельзя можно только перезапустить комманду с новым токеном)

                var startNum = _numberStartNum ?? 0;
                var endNum = int.Parse(InputNumberText!);
                var startSum = _startSum ?? 0;

                var progress = new Progress<(int index, long sum)>();
                progress.ProgressChanged += (_, report) =>
                {
                    ProgressSumValue = report.index;
                    
                    _startSum = report.sum;
                    _numberStartNum = report.index + 1;
                };

                try
                {
                    StatusCalculateSum = "Вычисление суммы...";
                    
                    var result = await Calc.SumAsync(
                        startNum: startNum,
                        endNumber: endNum,
                        startSum: startSum,
                        cancellationToken: _ctsCalculateSum.Token,
                        progress: progress);
                    
                    OutputSumText = result.ToString();
                    
                    _numberStartNum = null;
                    _startSum = null;
                    
                    StatusCalculateSum = "Вычисление суммы завершено";
                }
                catch (Exception)
                {
                    StatusCalculateSum = "Приостановка вычисления суммы";
                }
            },
            canExecute: canExecuteCalculateSumStart);
        
        CommandCalculateSumStop = ReactiveCommand.CreateFromTask(
            execute: async () =>
            {
                await _ctsCalculateSum!.CancelAsync();
            },
            canExecute: canExecuteCalculateSumStop);
    }
}