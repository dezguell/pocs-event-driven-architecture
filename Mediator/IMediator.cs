using System.Collections.Generic;

namespace Events_POC
{
    public interface IMediator
    {
        void Subscribe(Colleague colleagueA);
        void Interact(Event @event);
        IEnumerable<Colleague> GetColleagues();
    }
}