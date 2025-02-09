

using LerningPlatform.DAL.Postgres.Models;
using Microsoft.EntityFrameworkCore;

namespace LerningPlatform.DAL.Postgres.Repositories;

public class CoursesRepository
{
    private readonly LerningDBContext _dbContext;

    public CoursesRepository(LerningDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CourseEntity>> Get()
    {
        return await _dbContext.Couses
            .AsNoTracking()
            .OrderBy(c => c.Title)
            .ToListAsync();
    }
    
    public async Task<List<CourseEntity>> GetWithLessons()
    {
        return await _dbContext.Couses
            .AsNoTracking()
            .Include(c => c.Lessons)
            .Include(c => c.Students)
            .ToListAsync();
    }
    
    public async Task<CourseEntity?> GetById(Guid id)
    {
        return await _dbContext.Couses
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }
      // изучаем фильтрацию   
    public async Task<List<CourseEntity>> GetByFilter(string title, decimal price)
    {
        var query = _dbContext.Couses.AsNoTracking();
        if (!string.IsNullOrEmpty(title))
        {
            query = query.Where(c => c.Title.Contains(title));
        }

        if (price > 0)
        {
            query = query.Where(c => c.Price > price);
        }

        return await query.ToListAsync();
    }
    
    // пагинация - взять какие то страницы   Пагинация в C# — это метод разделения больших наборов данных на небольшие, управляемые куски или страницы
    
    public async Task<List<CourseEntity>> GetByPage(int page, int pageSize)
    {
        return await _dbContext.Couses
            .AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task Add(Guid id, Guid autorId, string title, string description, decimal price)
    {
        var courseEntity = new CourseEntity
        {
            Id = id,
            AuthorId = autorId,
            Title = title,
            Description = description,
            Price = price
        };

        await _dbContext.AddAsync(courseEntity);
        await _dbContext.SaveChangesAsync();
    }
    
    // обновление данных 
    public async Task Update(Guid id, Guid authorId, string title, string description, decimal price)
    {
        var courseEntity = await _dbContext.Couses.FirstOrDefaultAsync(c => c.Id == id)
                           ?? throw new Exception();

        courseEntity.Title = title;
        courseEntity.Description = description;
        courseEntity.Price = price;
        await _dbContext.SaveChangesAsync();
    }
    
    // продвинутый способ обновления данных в одну операцию
    public async Task Update2(Guid id, Guid authorId, string title, string description, decimal price)
    {
        await _dbContext.Couses
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Title, title)
                .SetProperty(c => c.Description, description)
                .SetProperty(c => c.Price, price));
    }


    public async Task Delete(Guid id)
    {
        await _dbContext.Couses
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
    }
    
    
}