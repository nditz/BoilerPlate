using System;

namespace Domain.Entities
{
    public class AuditTrail : BaseEntity
    {
        public string EntityName { get; set; } // e.g., "User", "Role"
        public Guid EntityId { get; set; } // The Id of the entity being changed
        public string Action { get; set; } // e.g., "Create", "Update", "Delete"
        public Guid? ChangedBy { get; set; } // UserId of the actor
        public DateTime ChangedAt { get; set; } // When the change happened
        public string? OldValues { get; set; } // JSON or string representation
        public string? NewValues { get; set; } // JSON or string representation
        public string? Description { get; set; } // Optional description
    }
} 