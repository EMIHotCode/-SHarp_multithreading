using System.Windows;
using System.Windows.Input;

namespace WpfApp8;

public class MainWindowViewModel : ViewModelBase
{
    private AgeModel _ageModel;

    public AgeModel AgeModel
    {
        get => _ageModel;
        set => SetField(ref _ageModel, value);
    }

    public ICommand CommandSave { get; }

    public MainWindowViewModel()
    {
        _ageModel = new AgeModel();
        
        CommandSave = new RelayCommand(
            _ =>
        {
            MessageBox.Show($"{AgeModel.Age} years old");
        },
        _ => !AgeModel.HasError);
    }
}