namespace BoilerRoomJournal.Model;

public class Employee
{
    public Guid Id { get; set; }
    public string Fio { get; set; }
    public List<JournalPage> pages { get; set; }
}