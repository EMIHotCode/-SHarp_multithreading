using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows.Controls;
using DynamicData.Binding;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using SPA.Views.Pages;

namespace SPA.ViewModel;

public class MainWindowViewModel : ViewModelsBase
{
    private readonly Dictionary<string, Page> _pages = new()
    {
        {"main", new MainPage()},
        {"first", new FirstPage()}
    };
    [Reactive] public Page CurrentPage { get; set; }
    public ObservableCollection<string> Pages { get; set; } = ["main", "first"];
    [Reactive] public string? SelectedPage { get; set; }
    public ReactiveCommand<Unit, Unit> GoBack { get; }
    public ReactiveCommand<Unit, Unit> GoForward { get; }

    public MainWindowViewModel()
    {
        CurrentPage = new MainPage();
        this.WhenValueChanged(vm => vm.SelectedPage)
            .WhereNotNull()
            .Subscribe(page => CurrentPage = _pages[page]);
        
        GoBack = ReactiveCommand.Create(() => { CurrentPage = _pages["main"]; });
        GoForward = ReactiveCommand.Create(() => { CurrentPage = _pages["first"]; });
    }
}