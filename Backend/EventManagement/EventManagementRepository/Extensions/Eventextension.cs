using EventManagement.Models;
using EventManagementRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Repository.Extensions
{
    public static class Eventextension
    {
        public static Event AsEntity(this EventModel item){
            return new Event
            {
                Id = item.Id,
                Name = item.Name,
                Place = item.Place,
                Details = item.Details,
                DateTime = item.Time,
                Duration = item.Duration,
                Comments= item.Comments,
            };
        }

        public static EventModel AsModel(this Event item) {
            return new EventModel
            {
                Id = item.Id,
                Name = item.Name,
                Place = item.Place,
                Details = item.Details,
                Duration= item.Duration,
                Time=item.DateTime,
                Comments=item.Comments,
            };
        }
    }
}
