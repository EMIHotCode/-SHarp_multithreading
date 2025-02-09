using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Model;

public enum PhoneType
{
    Home, 
    Work,
    NoType
}

public class Phone
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public PhoneType Type { get; set; } = PhoneType.NoType;
    public string Number { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PersonId { get; set; }
    public  Person? Person { get; set; }
}