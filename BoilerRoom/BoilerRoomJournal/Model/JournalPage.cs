using System.Runtime.InteropServices.JavaScript;

namespace BoilerRoomJournal.Model;

public class JournalPage
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } 
    // температура
    public int[] temprarture { get; set; } = new int[8];
    // давление газа 
    public float[] pressure_gas { get; set; } = new float[8];
    // давление воды
    public float[] pressure_water { get; set; } = new float[8];
    // расход воды по часам
    public int[] consumption { get; set; } = new int[8];
    // ЧП 
    public string extraordinaryEvent { get; set; }
    // замечания 
    public string comments { get; set; }
    // объем газа
    public int gasVolume { get; set; }
}