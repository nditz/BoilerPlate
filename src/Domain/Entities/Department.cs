namespace Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public Guid LocationId { get; set; }
    }
} 