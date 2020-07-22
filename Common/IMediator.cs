using System.Collections.Generic;
using System.Linq.Expressions;
using Common.Events;

namespace Common
{
    public interface IMediator
    {
        void Subscribe(KeyValuePair<Service, Event[]> colleague);
        void Interact(Event @event);
        IEnumerable<Service> GetColleagues();
        
    }
}