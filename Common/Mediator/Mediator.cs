using Common.Events;

namespace Common.Mediator
{
    public class Mediator : IMediator
    {
        private readonly Dictionary<Service.Service, HashSet<Type>> _serviceContainer = new();

        public void Subscribe(Service.Service service, Type[] eventTypes)
        {
            if (!_serviceContainer.TryGetValue(service, out var existing))
                _serviceContainer.Add(service, new HashSet<Type>(eventTypes));
            else
                foreach (var type in eventTypes)
                    existing.Add(type);
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
                        $"[Mediator] {kvp.Key.GetType().Name} failed reacting to {domainEvent.GetType().Name}: {ex.Message}");
                }
            }
        }
    }
}
