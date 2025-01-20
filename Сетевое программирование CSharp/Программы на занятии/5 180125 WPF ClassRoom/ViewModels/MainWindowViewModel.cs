using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows.Controls;
using ClassRoom.Views;
using DynamicData.Binding;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ClassRoom.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    private UserControl mainPageView = (UserControl)App.Current.Resources[nameof(MainPageView)];
    private UserControl aboutPageView = (UserControl)App.Current.Resources[nameof(AboutPageView)];
    
    [Reactive] public UserControl CurrentContent { get; set; } // реактивное свойство. Текущий контент который хотим отобарзить на экране
    [Reactive] public ItemForPages? SelectedPage { get; set; }
    
    public ReactiveCommand<Unit, Unit> CommandMain { get; } // создаем комманды. Отобразить главную страничку
    public ReactiveCommand<Unit, Unit> CommandAbout { get; }
    
    public ObservableCollection<ItemForPages> Pages { get; }

    public MainWindowViewModel()
    {
        Pages =
        [
            new ItemForPages() { Title = "Главная", Content = mainPageView },
            new ItemForPages() { Title = "О программе", Content = aboutPageView }
        ];
        
        this.WhenValueChanged(vm => vm.SelectedPage)
            .WhereNotNull()
            .Subscribe(x => CurrentContent = x.Content);
        
        CommandMain = ReactiveCommand.Create(() =>  // создаем комманды 
        {
            CurrentContent = new MainPageView();
        });
        CommandAbout = ReactiveCommand.Create(() =>
        {
            CurrentContent = aboutPageView;
        });
    }
}

public class ItemForPages
{
    public UserControl Content { get; set; }
    public string Title { get; set; }
}