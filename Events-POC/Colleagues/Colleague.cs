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
            this.mediator.Interact(new AnswerFriendRequest(this, colleagueFrom, true));
        }
    }
}