using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ToDo.Client.BL;
using ToDo.Model;

namespace ToDo.Desktop.ViewModels;

public class MainPageViewModel : PageViewModelBase
{
    private readonly Service _service = new();

    public ObservableCollection<TaskDto> Tasks { get; set; } = [];
    [Reactive] public TaskDto? SelectedTask { get; set; }

    public ReactiveCommand<Unit, Unit> CommandGetAllTasks { get; }

    public MainPageViewModel()
    {
        PageTitle = "Список задач";

        CommandGetAllTasks = ReactiveCommand.CreateFromTask(LoadTasks);
    }

    private async Task LoadTasks()
    {
        var tasks = await _service.GetAllTasksAsync();

        foreach (var task in tasks)
        {
            Tasks.Add(task);
        }
    }
}
