using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WpfApp5;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private long? _sum;
    public long? Sum
    {
        get => _sum;
        set => SetField(ref _sum, value);
    }

    private long? _factorial;
    public long? Factorial
    {
        get => _factorial;
        set => SetField(ref _factorial, value);
    }
    
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void ButtonCalculate_OnClick(object sender, RoutedEventArgs e)
    {
        ButtonCalculate.IsEnabled = false; // делаем кнопку неактивной после нажатия Вычислить
        
        var number = Convert.ToInt32(ВводЧисла.Text);

        var progressSum = new Progress<int>(); // экземпляр класса Progress
        progressSum.ProgressChanged += (s, i) => // событие к которому подписываемся для получения значения
        {
            ProgressSum.Value = i;  // i это индекс из калькулятор.cs\СуммаAsync \ progress?.Report(число - i);
        };
        
        var progressFactorial = new Progress<int>();
        progressFactorial.ProgressChanged += (s, i) =>
        {
            ProgressFactorial.Value = i;
        };

        await Task.Run(async () =>
        {
            Sum = await Калькулятор.СуммаAsync(number, progressSum);  // используем progressSum
        });
        
        await Task.Run(async () =>
        {
           Factorial = await Калькулятор.ФакториалAsync(number, progressFactorial);
        });
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}