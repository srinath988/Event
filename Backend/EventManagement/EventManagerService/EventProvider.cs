using EventManagement.Models;
using EventManagement.Repository;
using EventManagerProvider;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EventManagerService;

public class EventProvider : IEventProvider
{
    private readonly IEventRepository eventRepository;

    public EventProvider(IEventRepository eventRepository)
    {
        this.eventRepository = eventRepository;
    }

    public async Task<List<EventModel>> Get()
    {
        return await eventRepository.Get();
    }
   
    public async Task<EventModel> GetEventById(int Id)
    {
        return await eventRepository.GetEventById(Id);
    }

    public async Task Insert(EventModel Event)
    {
        await eventRepository.Insert(Event);
    }

    public async Task Update(int id,EventModel Event)
    {
        await eventRepository.Update(id,Event);
    }
   
    public async Task Delete(int Id)
    {
        await eventRepository.Delete(Id);
    }
    public async Task<List<EventModel>> GetPagination(Paging paginator)
    {
        return await eventRepository.GetPagination(paginator);
    }

    public async Task<List<EventModel>> SearchByName(string name)
    {
        return await eventRepository.Search(name);
    }
}