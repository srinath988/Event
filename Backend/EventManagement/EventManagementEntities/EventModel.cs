using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Details { get; set; }
        public DateTime Time { get; set; }
        public string Duration { get; set; }
        public string Comments { get; set; }

    }
}
