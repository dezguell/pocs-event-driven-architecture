using System;
using System.Collections.Generic;
using Events_POC.Events;
using Events_POC.Mediator;

namespace Events_POC.Colleagues
{
    public abstract class Colleague
    {
        protected IMediator mediator;
        protected string message;
        protected List<Colleague> Friends;

        protected Colleague(IMediator mediator)
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

        public void SendFriendRequestTo(Colleague colleagueTo)
        {
            mediator.Interact(new SendFriendRequestEvent(this, colleagueTo));
        }

        public void AnswerFriendRequestFrom(Colleague colleagueFrom)
        {
            this.mediator.Interact(new AnswerFriendRequestEvent(this, colleagueFrom, true));
        }

        public void React(SendMessageEvent @event)
        {
            var colleague = @event.GetColleague();
            Console.WriteLine(" ---- " +
                              $"{this.GetType().Name} " +
                              $"was notified of: {@event.GetType().Name} " +
                              $"from: {colleague.GetType().Name} " +
                              $"with content: {colleague.GetMessage()}\n");
        }

        public void React(SendFriendRequestEvent @event)
        {
            Console.WriteLine(" ---- " +
                              $"{this.GetType().Name} " +
                              $"was notified of: {@event.GetType().Name} " +
                              $"from: {@event.GetColleague().GetType().Name}\n");

            mediator.Interact(new AnswerFriendRequestEvent(this,@event.GetColleague(),true));
        }

        public void React(AnswerFriendRequestEvent @event)
        {
            Console.WriteLine(" ---- " +
                              $"{@event.GetColleagueFrom().GetType().Name} " +
                              $"was notified of: {@event.GetType().Name} " +
                              $"from: {this.GetType().Name} " +
                              $"whit the answer: {@event.GetAnswer()}\n");
        }
    }
}