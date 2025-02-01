using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using ToDo.Model;

namespace ToDo.Desktop.ViewModels;

public class MainPageViewModel : PageViewModelBase
{
    public ObservableCollection<TaskDto> Tasks { get; set; } = [];

    public ReactiveCommand<Unit, Unit> CommandGetAllTasks { get; }

    public MainPageViewModel()
    {
        PageTitle = "Список задач";

        CommandGetAllTasks = ReactiveCommand.CreateFromTask(LoadTasks);
    }

    private async Task LoadTasks()
    {
        var tasks = await Service.GetAllTasksAsync();

        foreach (var task in tasks)
        {
            Tasks.Add(task);
        }
    }
}
