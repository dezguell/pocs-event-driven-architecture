using Common.Events;
using Common.Mediator;
using Common.Service;

namespace LocalMediator
{
    public class Mediator : IMediator
    {
        private readonly Dictionary<Service, Event[]> _serviceContainer;

        public Mediator()
        {
            _serviceContainer = new Dictionary<Service, Event[]>();
        }

        public void Subscribe(KeyValuePair<Service, Event[]> service)
        {
            if (!_serviceContainer.ContainsKey(service.Key))
            {
                _serviceContainer.Add(service.Key, service.Value);
            }
            else
            {
                _serviceContainer[service.Key] = _serviceContainer[service.Key].Concat(service.Value).ToArray();
            }
        }

        public void Interact(Event @event)
        {
            var servicesSubscribedToEvent = _serviceContainer
                .Where(colleague => colleague.Value
                    .Select(evnt => evnt.GetType())
                    .Contains(@event.GetType()) && colleague.Key != @event.GetService());

            foreach (var service in servicesSubscribedToEvent)
            {
                service.Key.ReactTo(@event);
            }
        }

        public IEnumerable<Service> GetServices()
        {
            return this._serviceContainer.Keys;
        }
    }
}
