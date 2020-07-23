using System.Collections.Generic;
using System.Linq;
using Common.Events;

namespace Common.Mediator
{
    public class ServicesMediator : IMediator
    {
        private readonly Dictionary<Service.Service, Event[]> _serviceContainer;

        public ServicesMediator()
        {
            _serviceContainer = new Dictionary<Service.Service, Event[]>();
        }

        public void Subscribe(KeyValuePair<Service.Service, Event[]> service)
        {
            if (!_serviceContainer.ContainsKey(service.Key))
            {
                _serviceContainer.Add(service.Key, service.Value);
            }
            else
            {
                _serviceContainer[service.Key].ToList().AddRange(service.Value);
            }
        }

        public void Interact(Event @event)
        {
            foreach (var colleague in _serviceContainer)
            {
                if (colleague.Value.Select(evnt => evnt.GetType().Name)
                    .Contains(@event.GetType().Name) && colleague.Key != @event.GetService())
                {
                    colleague.Key.ReactTo(@event);
                }
            }
        }

        public IEnumerable<Service.Service> GetColleagues()
        {
            return this._serviceContainer.Keys;
        }
    }
}
