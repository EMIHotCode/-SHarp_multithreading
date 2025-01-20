namespace BoilerRoom.WebAPI.Model;

public enum DayTime {At8am, At11am, At14pm, At17pm, At20pm, At23pm, At2am, At5am }
public class JournalPage
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } 
    // температура
    public int[] temprarture { get; set; } = new int[8];
    // FIXME  переделать под MongoDB, Заменить одинаковые поля на массивы с подключением через Enum. 
    /* Было так
     public int temp8am { get; set; }
     public int temp11am { get; set; }
     public int temp14pm { get; set; }
     public int temp17pm { get; set; }
     public int temp20pm { get; set; }
     public int temp23pm { get; set; }
     public int temp2am { get; set; }
     public int temp5am { get; set; }*/
   
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