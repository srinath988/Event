using System;
using System.Collections.Generic;

namespace EventManagementRepository.Models
{
    public partial class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Details { get; set; }
        public DateTime DateTime { get; set; }
        public string Duration { get; set; }
        public string Comments { get; set; }
    }
}
