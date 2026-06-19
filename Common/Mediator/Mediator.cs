using Common.Events;

namespace Common.Mediator
{
    public class Mediator : IMediator
    {
        private readonly Dictionary<Service.Service, HashSet<Type>> _serviceContainer = [];

        public void Subscribe(Service.Service service, Type[] eventTypes)
        {
            if (!_serviceContainer.TryGetValue(service, out var existing))
            {
                _serviceContainer.Add(service, [.. eventTypes]);
            }
            else
            {
                foreach (var eventType in eventTypes)
                {
                    existing.Add(eventType);
                }
            }
        }

        public void Interact(DomainEvent domainEvent, Service.Service publisher)
        {
            var subscribed = _serviceContainer
                .Where(kvp => kvp.Value.Contains(domainEvent.GetType()) && kvp.Key != publisher)
                .ToList();

            foreach (var kvp in subscribed)
            {
                try
                {
                    kvp.Key.ReactTo(domainEvent);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(
                        $"[Mediator]: Service {domainEvent.PublisherName} failed reacting to {domainEvent.EventName}: {ex.Message}"
                    );
                }
            }
        }
    }
}
