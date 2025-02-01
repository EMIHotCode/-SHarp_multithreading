using ToDo.Client.BL;
using ToDo.Model;

namespace ToDo.Desktop.ViewModels;

public abstract class PageViewModelBase : ViewModelBase
{
    protected readonly Service Service = new();
    public static TaskDto? SelectedTask { get; set; }
    public string PageTitle { get; set; } = string.Empty;
}
