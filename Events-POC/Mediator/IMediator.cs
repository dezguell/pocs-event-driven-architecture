using System.Collections.Generic;
using Events_POC.Colleagues;
using Events_POC.Events;

namespace Events_POC.Mediator
{
    public interface IMediator
    {
        void Subscribe(Colleague colleagueA);
        void Interact(Event @event);
        IEnumerable<Colleague> GetColleagues();
    }
}