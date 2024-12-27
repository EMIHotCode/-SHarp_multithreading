using ReactiveUI;

namespace SPA.ViewModel;

public class ViewModelsBase : ReactiveObject
{
    public string? Title { get; protected set; }  // только через get можем получать свойство Title
}