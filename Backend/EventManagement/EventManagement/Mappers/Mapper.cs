using EventManagement.Api.Event.Dtos;
using EventManagement.Models;

namespace EventManagement.Api.Mappers
{
    public static class Mapper
    {
        public static EventDTO AsDTO(this EventModel eventModel)
        {
            return new EventDTO 
            { 
                Id = eventModel.Id,
                Comments= eventModel.Comments,
                Time = eventModel.Time,
                Details= eventModel.Details,
                Duration= eventModel.Duration,
                Name= eventModel.Name,
                Place = eventModel.Place
            };
        }
        public static EventModel AsModel(this EventDTO eventDTO)
        {
            return new EventModel 
            { 
                Id = eventDTO.Id,
                Comments= eventDTO.Comments,
                Time = eventDTO.Time,
                Details= eventDTO.Details,
                Duration= eventDTO.Duration,
                Name= eventDTO.Name,
                Place = eventDTO.Place
            };
        }
    }
}
