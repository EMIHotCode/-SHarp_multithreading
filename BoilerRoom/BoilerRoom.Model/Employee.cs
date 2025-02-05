namespace BoilerRoom.Model;

public class Employee
{
    public int Id { get; set; }
    public string Fio { get; set; }
    public List<JournalPage> pages { get; set; }
}