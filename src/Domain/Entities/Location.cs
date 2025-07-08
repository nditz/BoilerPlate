using System.Collections.Generic;

namespace Domain.Entities
{
    public class Location : BaseEntity
    {
        public string Name { get; set; }
        public Guid OfficeId { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
} 