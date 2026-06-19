namespace LocalMediator
{
    public class Mediator : IMediator
    {
        private readonly Dictionary<Service, HashSet<Type>> _serviceContainer;

        public Mediator()
        {
            _serviceContainer = new Dictionary<Service, HashSet<Type>>();
        }

        public void Subscribe(Service service, Type[] eventTypes)
        {
            if (!_serviceContainer.ContainsKey(service))
            {
                _serviceContainer.Add(service, new HashSet<Type>(eventTypes));
            }
            else
            {
                foreach (var type in eventTypes)
                    _serviceContainer[service].Add(type);
            }
        }

        public void Interact(Event @event, Service publisher)
        {
            var subscribed = _serviceContainer
                .Where(kvp => kvp.Value.Contains(@event.GetType()) && kvp.Key != publisher);

            foreach (var kvp in subscribed)
            {
                kvp.Key.ReactTo(@event);
            }
        }
    }
}
