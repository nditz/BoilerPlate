using System;

namespace Domain.Events
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
} 