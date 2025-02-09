using System.ComponentModel.DataAnnotations.Schema;

namespace PBook.Server_Model;

public class Person
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Patronymic { get; set; } = string.Empty;
    public List<Phone> Phones { get; set; } = [];
    public bool IsDeleted { get; set; } = false;
}