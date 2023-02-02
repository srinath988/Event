using System;
using System.Collections.Generic;

namespace EventManagementRepository.Models
{
    public partial class ContactsInfo
    {
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? Message { get; set; }
        public string Phone { get; set; } = null!;
    }
}
