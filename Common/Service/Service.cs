using Common.Events;
using Common.Mediator;
using Common.Reaction;

namespace Common.Service
{
    public abstract class Service
    {
        private readonly IMediator mediator;

        protected List<EventReaction> EventReactionRegistry { get; private set; }

        protected Service(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected void RegisterReactions(IEnumerable<EventReaction> reactions)
        {
            EventReactionRegistry = reactions.ToList();
            mediator.Subscribe(this, EventReactionRegistry.Select(r => r.EventType).ToArray());
        }

        public void ReactTo(Event @event)
        {
            foreach (var er in EventReactionRegistry.Where(r => r.EventType == @event.GetType()))
            {
                er.Reaction.ReactTo(@event);
            }
        }

        public void Interact(Event @event)
        {
            @event.PublisherName = GetType().Name;
            mediator.Interact(@event, this);
        }
    }
}