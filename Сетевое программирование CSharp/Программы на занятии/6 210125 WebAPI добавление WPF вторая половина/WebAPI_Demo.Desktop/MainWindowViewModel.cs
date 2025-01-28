using System.Collections.ObjectModel;
using System.Net.Http.Json;
using DynamicData.Binding;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace WebAPI_Demo.Desktop;

public class MainWindowViewModel : ReactiveObject
{
    public ObservableCollection<Person> Persons { get; set; }
    [Reactive] public Person? SelectedPerson { get; set; }
    
    [Reactive] public Guid? Id { get; set; }
    [Reactive] public string? FirstName { get; set; }
    [Reactive] public string? LastName { get; set; }

    public MainWindowViewModel()
    {
        var http = App.HttpClient; // псевдоним для App.HttpClient
        var url = new Uri("http://localhost:5012/persons");
        var persons = http.GetFromJsonAsync<IEnumerable<Person>>(url).Result;
        Persons = new ObservableCollection<Person>(persons);
        
        this.WhenValueChanged(vm => vm.SelectedPerson)
            .WhereNotNull()
            .Subscribe(p =>
            {
                Id = p.Id;
                FirstName = p.FirstName;
                LastName = p.LastName;
            });
    }
}