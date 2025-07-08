using System;
using Domain.Entities;

namespace Domain.Events
{
    public class UserCreatedEvent : IDomainEvent
    {
        public User User { get; }
        public DateTime OccurredOn { get; }

        public UserCreatedEvent(User user)
        {
            User = user;
            OccurredOn = DateTime.UtcNow;
        }
    }
} 