using System.Collections.ObjectModel;
using ReactiveUI.Fody.Helpers;
using ToDo.Model;

namespace ToDo.Desktop.ViewModels;

public class MainPageViewModel : PageViewModelBase
{
    public ObservableCollection<TaskDto> Tasks { get; set; } = [];
    [Reactive] public TaskDto? SelectedTask { get; set; }
    public MainPageViewModel()
    {
        PageTitle = "Список задач";
    }
}
