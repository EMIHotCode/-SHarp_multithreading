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
public string Test { get; }
    //конструктор
    public MainWindowViewModel()
    {
        var connectionString = App.Current.Resources["ConnectionString"] as string; // as string - вернет null в случае чего который нужно будет обрабатывать, ToString() - выкинет исключение если null которое нужно обрабатывать
        _db = new DataBaseContext(connectionString);
        _db.JournalPages
            .Include(t => t.Employee)
            .ToList();

        InitJournalPages(_db.JournalPages);
        InitEmployees(_db.Employees);
        Test = "Hello";
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