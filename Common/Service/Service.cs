using System.Collections.Generic;
using System.Linq;
using Common.Events;
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
            return this.message;
        }

        public void SendMessage(string message)
        {
            this.message = message;
            this.mediator.Interact(new SendMessageEvent(this));
        }

        public void ReactTo(Event @event)
        {
            foreach (var eventReaction in this.EventReactionRegistry.Where(reaction => reaction.Event.GetType().Name == @event.GetType().Name))
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