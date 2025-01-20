using ReactiveUI.Fody.Helpers;

namespace ClassRoom.ViewModels;

public class MainPageViewModel : PageViewModelBase
{
    [Reactive] public string Text { get; set; }
    
    public MainPageViewModel()
    {
        PageTitle = "ClassRoom";
    }
}