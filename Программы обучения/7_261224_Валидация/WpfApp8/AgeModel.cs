using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp8;

public sealed class AgeModel : IDataErrorInfo, INotifyPropertyChanged
{
    private string _error = string.Empty;
    public string Error
    {
        get => _error;
        private set => SetField(ref _error, value);
    }
    public int? Age { get; set; }
    
    public bool HasError => !string.IsNullOrEmpty(Error);

    public string this[string columnName]
    {
        get
        {
            Error = string.Empty;
            switch (columnName)
            {
                case "Age":
                    Error = Age switch
                    {
                        null => "Ошибка ввода возраста",
                        < 0 => "Возраст не может быть отрицательным!",
                        _ => Error
                    };

                    break;
                default:
                    break;
            }

            return Error;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}