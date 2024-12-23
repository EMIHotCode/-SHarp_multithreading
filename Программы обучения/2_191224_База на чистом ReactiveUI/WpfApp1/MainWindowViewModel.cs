namespace WpfApp1;
using System.Collections.ObjectModel;
using DynamicData.Binding;
using ReactiveUI.Fody.Helpers;
public class MainWindowViewModel : ViewModelBase
{
    private readonly List<Person> _sourcePeople = []; // временное хранение списка людей 
    
    [Reactive] public string SearchText { get; set; } = string.Empty;  // свойство поля поиска
    
    public ObservableCollection<Person> People { get; set; } = []; // наблюдаемый список 

    public MainWindowViewModel()
    {
        Init();
        
        this.WhenValueChanged(vm => vm.SearchText) // когда значение изменится
            .Subscribe(s =>    // описываем какоето действие при изменении значения
            {
                People.Clear();

                if (string.IsNullOrWhiteSpace(s)) // если SearchText IsNullOrWhiteSpace заполняем наблюдаемый список
                {
                    foreach (var person in _sourcePeople)
                    {
                        People.Add(person);
                    }
                }
                else  // иначе формируем список через LINQ запрос
                {
                    var people = _sourcePeople.Where(p => p.FirstName.Contains(s) || p.LastName.Contains(s)).ToList();

                    foreach (var person in people)
                    {
                        People.Add(person);
                    }
                }
            });
    }

    private void Init()
    {
        _sourcePeople.Add(new Person() { FirstName = "John", LastName = "Doe" });
        _sourcePeople.Add(new Person() { FirstName = "Jane", LastName = "Doe" });
        _sourcePeople.Add(new Person() { FirstName = "Jim", LastName = "Doe" });
        _sourcePeople.Add(new Person() { FirstName = "Julie", LastName = "Doe" });
        _sourcePeople.Add(new Person() { FirstName = "Julie", LastName = "Smith" });
        _sourcePeople.Add(new Person() { FirstName = "Jakob", LastName = "Smith" });
    }
}