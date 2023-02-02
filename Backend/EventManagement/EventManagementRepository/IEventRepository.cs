using EventManagement.Models;

namespace EventManagement.Repository;

public interface IEventRepository
{
    Task<List<EventModel>> Get();

    Task<EventModel> GetEventById(int Id);

    Task<bool> Insert(EventModel Event);

    Task Update (int id,EventModel Event);

    Task Delete(int Id);

    Task<List<EventModel>> GetPagination(Paging paginator);

    Task<List<EventModel>> Search(string name);
 }
