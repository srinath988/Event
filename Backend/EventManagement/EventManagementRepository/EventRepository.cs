using EventManagement.Models;
using EventManagement.Repository.Extensions;
using EventManagementRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Repository;

public class EventRepository : IEventRepository
{
    private readonly EventManagementContext _dbContext;

    public EventRepository(EventManagementContext _dbContext)
    {
        this._dbContext = _dbContext;
    }

    public async Task<List<EventModel>> Get()
    {
        try
        {
            return await _dbContext.Events.Select(
                            response => response.AsModel()
                        ).ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<EventModel> GetEventById(int Id)
    {
        try
        {
            var response = await _dbContext.Events.FirstOrDefaultAsync(s => s.Id == Id);
            if (response == null)
            {
                return null;
            }
            return response.AsModel();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<bool> Insert(EventModel e)
    {
        try
        {
            if (e.Duration == null)
            {
                throw new Exception("Duration cannot be null");
            }
            var entity = e.AsEntity();

            await _dbContext.Events.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task Update(int id, EventModel Event)
    {
        try
        {
            var entity = await _dbContext.Events.FindAsync(Event.Id);
            if (entity == null)
            {
                throw new NullReferenceException("Event is not available");
            }
            entity.Name = Event.Name;
            entity.Place = Event.Place;
            entity.DateTime = Event.Time;
            entity.Details = Event.Details;
            entity.Comments = Event.Comments;
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task Delete(int Id)
    {
        try
        {
            var entity = await _dbContext.Events.FindAsync(Id);
            if (entity == null)
            {
                throw new NullReferenceException("Event is not available");
            }
            _dbContext.Events.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public async Task<List<EventModel>> GetPagination(Paging paginator)
    {
        return await _dbContext.Events.Select(
                            response =>response.AsModel()
                        )
             .Skip((paginator.PageNumber - 1) * paginator.PageSize)
             .Take(paginator.PageSize)
             .ToListAsync();
    }

    public async Task<List<EventModel>> Search(string name)
    {
        var data = await
             _dbContext.Events.Select(
            response => response.AsModel()).ToListAsync();
        if (String.IsNullOrEmpty(name))
        {
            return data.OrderBy(x => x.Name).ToList();
        }

        data = data.OrderBy(x => x.Name)
            .Where(s => s.Name.ToLower().Contains(name.ToLower())).ToList();

        return data;
    }  
}
