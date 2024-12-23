using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfAppTest;

public class MainWindowViewModel : INotifyPropertyChanged
{
    // ObservableCollection работает с Binding хорошо в одном потоке без создания await Task.Run(async () => 
    public ObservableCollection<string> Items { get; set; } = [];// ObservableCollection сама реализует INotifyPropertyChanged без использования наследования 
    private readonly List<string> _items = []; // заменим в CommandStart1  Items на _items

    private object _lock = new(); // lock это блокировка (объект к которому можно прицепиться, он ничего не значит, внутри него нельзя делать await)
    public ICommand CommandStart1 { get; }  // не нуждаются в INotifyPropertyChanged так как не используют SetField<T> значит в этой задаче INotifyPropertyChanged не нужен 
    public LambdaCommand CommandStart2 { get; } // ICommand заменили на LambdaCommand
    
    public MainWindowViewModel ()
    {
        CommandStart1 = new LambdaCommand(async _ =>
        {
            await Task.Run(async () =>
            {
                for (int i = 0; i < 10; i++) 
                {
                    _items.Add($"Item {i}");
                    await Task.Delay(500);
                }
            });
            FillItems(_items);
        });
        
        CommandStart2 = new LambdaCommand(async _ =>
        {
            await Task.Run(async () =>
            {
                lock (_lock)  // внутри lock код должен быть синхронным
                {
                    for (int i = 10; i < 20; i++)
                    {
                        _items.Add($"Item {i}");
                        Task.Delay(500);
                    }
                }
            });
            FillItems(_items); // нельзя заполнять наблюдаемую коллекцию внутри какой нибудь задачи
        });
    }
    
    private void FillItems(IEnumerable<string> items)
    {
       // Items.Clear();
        
        foreach (var item in items)
        {
            Items.Add(item);
        }
        //_items.Clear();
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