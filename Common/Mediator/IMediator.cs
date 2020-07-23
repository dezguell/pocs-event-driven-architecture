using System.Collections.Generic;
using Common.Events;

namespace Common.Mediator
{
    public interface IMediator
    {
        void Subscribe(KeyValuePair<Service.Service, Event[]> colleague);
        void Interact(Event @event);
        IEnumerable<Service.Service> GetServices();
    }
}