namespace WebAPI_Demo.DB;

public enum PhoneType
{
    Mobile,
    Home,
    Work
}

public class Phone
{
    public Guid Id { get; set; }
    public PhoneType Type { get; set; }
    public string Number { get; set; }

    public Guid PersonId { get; set; }
    public Person Person { get; set; }
}