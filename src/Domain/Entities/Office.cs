using System.Collections.Generic;

namespace Domain.Entities
{
    public class Office : BaseEntity
    {
        public string Name { get; set; }
        public Guid OrganizationId { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
} 