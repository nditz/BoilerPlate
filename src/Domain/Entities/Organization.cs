using System.Collections.Generic;

namespace Domain.Entities
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Office> Offices { get; set; }
    }
} 