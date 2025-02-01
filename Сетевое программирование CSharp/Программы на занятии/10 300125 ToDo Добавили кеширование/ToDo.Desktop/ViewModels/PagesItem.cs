using ReactiveUI.Fody.Helpers;

namespace ToDo.Desktop.ViewModels;

public class PagesItem
{
    [Reactive] public PageViewModelBase? Page { get; set; }
    public string? Title => Page?.PageTitle;
}
