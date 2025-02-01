using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ToDo.Model;
using TaskStatus = ToDo.Model.TaskStatus;

namespace ToDo.Desktop.ViewModels;

public class UpdateTaskPageViewModel : PageViewModelBase
{
    public ObservableCollection<string> Priorities { get; set; }
    public ObservableCollection<string> Statuses { get; set; }

    private readonly uint? _id;
    [Reactive] public string? Title { get; set; }
    [Reactive] public string? Description { get; set; }
    [Reactive] public TaskPriority? Priority { get; set; }
    [Reactive] public TaskStatus? Status { get; set; }
    [Reactive] public DateTime? Created { get; set; }
    [Reactive] public DateTime? Deadline { get; set; }

    public ReactiveCommand<Unit, Unit> CommandSave { get; }

    public UpdateTaskPageViewModel()
    {
        PageTitle = "Редактирование задачи";

        _id = SelectedTask?.Id;
        Title = SelectedTask?.Title;
        Description = SelectedTask?.Description;
        Priority = SelectedTask?.Priority;
        Status = SelectedTask?.Status;
        Created = SelectedTask?.Created;
        Deadline = SelectedTask?.Deadline;

        CommandSave = ReactiveCommand.CreateFromTask(SaveAsync);
    }

    private async Task SaveAsync()
    {
        var task = new TaskDto
        {
            Id = _id!.Value,
            Title = Title!,
            Description = Description!,
            Priority = Priority!.Value,
            Status = Status!.Value,
            Created = Created!.Value,
            Deadline = Deadline!.Value
        };

        await Service.UpdateTaskAsync(task);
    }
}
