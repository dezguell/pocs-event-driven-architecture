using Common.Events;
using Common.Events.EventBox;
using Common.Mediator;
using Common.Reaction;

namespace Common.Service
{
    public abstract class Service
    {
        protected IMediator mediator;
        protected string message;

        protected List<EventReaction> EventReactionRegistry { get; set; }

        protected Service(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public string GetMessage()
        {
            return message;
        }

        public void SendMessage(string message)
        {
            this.message = message;
            mediator.Interact(new SendMessageEvent(this));
        }

        public void ReactTo(Event @event)
        {
            foreach (var eventReaction in EventReactionRegistry.Where(reaction => reaction.Event.GetType() == @event.GetType()))
            {
                eventReaction.Reaction.ReactTo(@event);
            }

        }

        public void Interact(Event @event)
        {
            mediator.Interact(@event);
        }
    }
}