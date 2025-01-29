using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ToDo.Desktop.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<PagesItem> Pages { get; set; } =
    [
        new() {Page = new MainPageViewModel()},
        new() {Page = new CreateTaskPageViewModel()}
    ];

    [Reactive] public PagesItem? SelectedPage { get; set; }

    [Reactive] public bool IsPaneOpen { get; set; } = false;

    public ReactiveCommand<Unit, Unit> PaneOpenClose { get; }

    public MainWindowViewModel()
    {
        SelectedPage = Pages[0];

        PaneOpenClose = ReactiveCommand.Create(() =>
        {
            IsPaneOpen = !IsPaneOpen;
        });
    }
}
