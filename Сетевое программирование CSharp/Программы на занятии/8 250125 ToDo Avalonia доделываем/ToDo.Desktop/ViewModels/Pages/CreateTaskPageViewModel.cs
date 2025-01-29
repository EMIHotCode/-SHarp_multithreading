using System;
using System.Collections.ObjectModel;
using ReactiveUI.Fody.Helpers;
using ToDo.Model;

namespace ToDo.Desktop.ViewModels;

public class CreateTaskPageViewModel : PageViewModelBase
{
    public ObservableCollection<string> Priorities { get; set; }
    public ObservableCollection<string> Statuses { get; set; }

    [Reactive] public string Title { get; set; }
    [Reactive] public string Description { get; set; }
    [Reactive] public TaskPriority Priority { get; set; }
    [Reactive] public TaskStatus Status { get; set; }
    [Reactive] public DateTime Created { get; set; }
    [Reactive] public DateTime Deadline { get; set; }
    public CreateTaskPageViewModel()
    {
        PageTitle = "Создание задачи";
    }
}
