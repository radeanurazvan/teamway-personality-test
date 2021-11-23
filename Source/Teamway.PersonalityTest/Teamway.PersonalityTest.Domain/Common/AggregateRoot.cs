using System.Collections.Generic;

namespace Teamway.PersonalityTest.Domain
{
    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
        private readonly ICollection<IEvent> events = new List<IEvent>();

        public IEnumerable<IEvent> Events => events;

        public void ClearEvents() => events.Clear();

        protected void AddEvent(IEvent @event) => events.Add(@event);
    }

    public interface IAggregateRoot
    {
        public void ClearEvents();
    }
}