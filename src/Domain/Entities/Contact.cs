using System;

namespace Domain.Entities
{
    public class Contact : BaseEntity
    {
        public Guid UserId { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        // Navigation property (optional)
        public User? User { get; set; }
    }
} 