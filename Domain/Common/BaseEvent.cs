using Domain.Interfaces;


namespace Domain.Common
{
    public abstract class BaseEvent : IDomainEvent
    {
        public DateTime Occurred { get; }

        public string EventType => GetType().Name;

        protected BaseEvent()
        {
            Occurred = DateTime.UtcNow;
        }
    }
}
