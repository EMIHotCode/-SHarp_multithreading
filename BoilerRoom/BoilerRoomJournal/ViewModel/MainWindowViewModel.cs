using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Input;
using BoilerRoomJournal.Model;
using Microsoft.EntityFrameworkCore;

namespace BoilerRoomJournal.ViewModel;


public class MainWindowViewModel : ViewModelBase
{
    private readonly DataBaseContext _db;
    
    public ObservableCollection<JournalPage> JournalPages { get; } = [];
    public ObservableCollection<Employee> Employees { get; } = [];
    
    public string City { get; set; }
    public string Temperature { get; set; }
    
    public ICommand CommandSave { get; }

    public MainWindowViewModel()
    {
        var connectionString = App.Current.Resources["ConnectionString"] as string; // as string - вернет null в случае чего который нужно будет обрабатывать, ToString() - выкинет исключение если null которое нужно обрабатывать
        _db = new DataBaseContext(connectionString);
        _db.JournalPages
            .Include(t => t.Employee)
            .ToList();

        InitJournalPages(_db.JournalPages);
        InitEmployees(_db.Employees);
        
        
        var http = new HttpClient();  // Для отправки HTTP-запросов в .NET применяется класс HttpClient
        //  var response = await http.GetAsync   
        // приложение нужно переделывать под WebAPI проект
        var response = await http.GetAsync("https://www.meteoservice.ru/weather/overview/nizhniy-novgorod"); // получаем ответ от запроса 
        
        while(true)
        {
            Task.WaitAll(Task.Run(() =>
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var httpText = response.Content.ReadAsStringAsync();
                        City = new Regex("(?:<meta.*?name=\"keywords\".*?)(.*?)(?:\\/>)").Match(httpText).Groups[0].Value;
                        Temperature = new Regex("(<span.*?class=\"value\">)(.*?)(<\\/span>)").Match(httpText).Groups[0].Value;

                        string[] wordsTagCity = City.Split(',');
                        string[] wordsTagTemprature = Temperature.Split('<', '>');
    
                        City = wordsTagCity[2];
                        Temperature = wordsTagTemprature[2];
                    }
                }),
                Task.Delay(3600000));
        }
    }

    private void InitJournalPages(IEnumerable<JournalPage>? journalPages)
    {
        if (journalPages is null)
        {
            JournalPages.Clear();
            
            return;
        }
        JournalPages.Clear();

        foreach (var page in journalPages)
        {
            JournalPages.Add(page);
        }
    }
    
    private void InitEmployees(IEnumerable<Employee>? employees)
    {
        if (employees is null)
        {
            Employees.Clear();
            
            return;
        }
        Employees.Clear();
        foreach (var employee in employees)
        {
            Employees.Add(employee);
        }
    }
}