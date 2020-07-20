using System.Collections.Generic;
using Events_POC.Events;
using Events_POC.Services;

namespace Events_POC.Mediator
{
    public interface IMediator
    {
        void Subscribe(KeyValuePair<Service, Event[]> colleagueA);
        void Interact(SendMessageEvent @event);
        void Interact(SendInteractionRequestEvent @event);
        void Interact(AnswerInteractionRequestEvent @event);
        IEnumerable<Service> GetColleagues();
        
    }
}