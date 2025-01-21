namespace WebAPI_Demo.DB;

public class Person
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public List<Phone> Phones { get; set; }
}