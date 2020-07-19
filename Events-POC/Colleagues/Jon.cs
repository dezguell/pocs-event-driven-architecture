using System.Collections.Generic;
using Events_POC.Events;
using Events_POC.Mediator;

namespace Events_POC.Colleagues
{
    public class Jon : Colleague
    {
        public Jon(IMediator mediator) : base(mediator)
        {
            mediator.Subscribe(new KeyValuePair<Colleague, Event[]>(this, new Event[]
            {
                new SendMessageEvent(this),
                new SendFriendRequestEvent(this,null),
            }));
        }
    }
}