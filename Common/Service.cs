using System;
using System.Collections.Generic;
using System.Linq;
using Common.Events;

namespace Common
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

        public void AnswerFriendRequestFrom(Service colleagueFrom)
        {
            this.mediator.Interact(new AnswerInteractionRequestEvent(this, colleagueFrom, true));
        }

        public void ReactTo(Event @event)
        {
            foreach (var eventReaction in this.EventReactionRegistry.Where(reaction => reaction.Event.GetType().Name == @event.GetType().Name))
            {
                eventReaction.Reaction.ReactTo(@event);
            }

        }

        //public void React(SendMessageEvent @event)
        //{
        //    var colleague = @event.GetService();
        //    Console.WriteLine(" ---- " +
        //                      $"{this.GetType().Name} " +
        //                      $"was notified of: {@event.GetType().Name} " +
        //                      $"from: {colleague.GetType().Name} " +
        //                      $"with content: {colleague.GetMessage()}\n");
        //}

        //public void React(SendInteractionRequestEvent @event)
        //{
        //    Console.WriteLine(" ---- " +
        //                      $"{this.GetType().Name} " +
        //                      $"was notified of: {@event.GetType().Name} " +
        //                      $"from: {@event.GetService().GetType().Name}\n");

        //    mediator.Interact(new AnswerInteractionRequestEvent(this, @event.GetService(), true));
        //}

        //public void React(AnswerInteractionRequestEvent @event)
        //{
        //    Console.WriteLine(" ---- " +
        //                      $"{@event.GetColleagueFrom().GetType().Name} " +
        //                      $"was notified of: {@event.GetType().Name} " +
        //                      $"from: {this.GetType().Name} " +
        //                      $"whit the answer: {@event.GetAnswer()}\n");
        //}

        //public abstract void React(AssetCreationEvent @event);

        public void Interact(Event @event)
        {
            mediator.Interact(@event);
        }
    }
}