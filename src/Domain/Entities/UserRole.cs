using System;

namespace Domain.Entities
{
    public class UserRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public Guid? DepartmentId { get; set; }
    }
} 