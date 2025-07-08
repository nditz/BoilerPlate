using System;

namespace Domain.Entities
{
    public class UserAssignment
    {
        public Guid ExternalUserId { get; set; }
        public Guid InternalUserId { get; set; }
    }
} 