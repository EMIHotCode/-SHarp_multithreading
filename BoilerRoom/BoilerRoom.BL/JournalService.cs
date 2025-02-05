using Microsoft.EntityFrameworkCore;
using BoilerRoom.Dal;
using BoilerRoom.Model;


namespace BoilerRoom.BL;  //В нем реализуем методы получить весь журнал, добавить в журнал, удалить из журнала до какой то даты

public class JournalService
{
    private readonly BoilerRoomContext _context; // приватная переменная для контекста

    public JournalService()
    {
        var contextFactory = new BoilerRoomContextFactory();
        _context = contextFactory.CreateDbContext();
    }
    
    
    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await _context.Employees.ToListAsync();
    }
    public async Task<IEnumerable<JournalPage>> GetAllJournalPagesAsync()
    {
        return await _context.JournalPages.ToListAsync();
    }
    
    
    public async Task AddJournalPageAsync(JournalPage page)
    {
        await _context.JournalPages.AddAsync(page);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeletePagesAfterDateAsync(DateTime date)
    {
        var temp = await _context.JournalPages.SingleOrDefaultAsync(t => t.Date >= date);
        if (temp == null) throw new NullReferenceException();
        await _context.SaveChangesAsync();
    }
}