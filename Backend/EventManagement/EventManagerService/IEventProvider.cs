using EventManagement.Models;
using EventManagementRepository;

namespace EventManagerProvider;

public interface IEventProvider
{
    Task<List<EventModel>> Get();

    Task<EventModel> GetEventById(int id);

    Task Insert(EventModel Event);

    Task Update(int id,EventModel Event);

    Task Delete(int id);
    Task<List<EventModel>> GetPagination(Paging paginator);

    Task<List<EventModel>> SearchByName(string name);

}
