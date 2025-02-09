using Microsoft.EntityFrameworkCore;
using PBook.Server_DAL.Postgres;
using PBook.Server_Model;

namespace PBook.Server_BL;

public class PhoneBookService
{
    private readonly PhoneBookContext _context;

    public PhoneBookService()
    {
        var contextFactory = new PhoneBookContextFactory();
        _context = contextFactory.CreateDbContext();
    }
    
    public async Task<IEnumerable<Person>> GetAllPersonsAsync()
    {
        return await _context.Persons
            .AsNoTracking() //не отслеживать изменения в Persons - так как мы только забираем
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Phone>> GetAllPhonesAsync()
    {
        return await _context.Phones.ToListAsync();
    }
    
    public async Task<List<Person>> GetAllPersonsWithPhonesAsync()
    {
        return await _context.Persons
            .AsNoTracking() //не отслеживать изменения в Persons - так как мы только забираем
            .Include(p => p.Phones)
            .ToListAsync();
    }
    
    public async Task UpdatePersonAsync(Person person)
    {
        var temp = await _context.Persons.SingleOrDefaultAsync(p => p.Id == person.Id);
        if (temp == null) throw new NullReferenceException();
        temp.FirstName = person.FirstName;
        temp.LastName = person.LastName;
        temp.Patronymic = person.Patronymic;
        temp.Phones = person.Phones;
        temp.IsDeleted = person.IsDeleted;

        await _context.SaveChangesAsync();
    }
    
    public async Task DeletePersonAsync(int id)
    {
        /*var temp = await _context.Persons.SingleOrDefaultAsync(t => t.Id == id);    не работает 
        if (temp == null) throw new NullReferenceException();

        temp.IsDeleted = true;
        await _context.SaveChangesAsync();*/
        await _context.Persons
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task CreatePersonAsync(Person person)
    {
        await _context.Persons.AddAsync(person);
        await _context.SaveChangesAsync();
    }
}