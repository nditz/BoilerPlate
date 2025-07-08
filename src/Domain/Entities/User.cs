using System;
using System.Collections.Generic;
using Domain.Enums;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public Guid UserEntraId { get; set; } // Azure AD identifier
        public int? UniqueUserId { get; set; } // Nullable if not a patient
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string? Prefix { get; set; }
        public string? Suffix { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Title { get; set; }
        public string? Email { get; set; }
        public UserType Type { get; set; }
        // StaffType relationship (nullable, for external users)
        public Guid? StaffTypeId { get; set; }
        public StaffType? StaffType { get; set; }
        // Navigation property for contacts
        public ICollection<Contact> Contacts { get; set; }
        // Navigation property for audit trails
        public ICollection<AuditTrail> AuditTrails { get; set; }
        // Navigation property for sessions
        public ICollection<Session> Sessions { get; set; }
    }
} 