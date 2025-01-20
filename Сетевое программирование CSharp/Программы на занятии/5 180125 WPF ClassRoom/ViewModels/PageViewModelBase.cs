using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ClassRoom.ViewModels;

public abstract class PageViewModelBase : ReactiveObject
{
    [Reactive] public string PageTitle { get; set; }
}