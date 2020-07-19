using System.Collections.Generic;
using Events_POC.Colleagues;
using Events_POC.Events;

namespace Events_POC.Mediator
{
    public interface IMediator
    {
        void Subscribe(KeyValuePair<Colleague, Event[]> colleagueA);
        void Interact(SendMessageEvent @event);
        void Interact(SendFriendRequestEvent @event);
        void Interact(AnswerFriendRequest @event);
        IEnumerable<Colleague> GetColleagues();
        
    }
}