using Common.Events;
using Common.Mediator;
using Common.Reaction;

namespace Common.Service
{
    public abstract class Service
    {
        private readonly IMediator mediator;

        private List<EventReaction> _reactions;

        protected Service(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected void RegisterReactions(IEnumerable<EventReaction> reactions)
        {
            _reactions = [.. reactions];

            var invalid = _reactions
                .Where(r => !typeof(DomainEvent).IsAssignableFrom(r.EventType))
                .ToList();
            if (invalid.Count > 0)
                throw new ArgumentException(
                    $"EventType must be a DomainEvent subtype. Invalid: {string.Join(", ", invalid.Select(r => r.EventType.Name))}"
                );

            mediator.Subscribe(this, [.. _reactions.Select(r => r.EventType)]);
        }

        internal void ReactTo(DomainEvent domainEvent)
        {
            foreach (var er in _reactions.Where(r => r.EventType == domainEvent.GetType()))
            {
                er.Handler.ReactTo(domainEvent);
            }
        }

        public void Interact(DomainEvent domainEvent)
        {
            domainEvent.PublisherName = GetType().Name;
            mediator.Interact(domainEvent, this);
        }
    }
}
