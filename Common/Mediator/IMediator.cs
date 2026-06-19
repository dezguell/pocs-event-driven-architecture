using Common.Events;

namespace Common.Mediator
{
    public interface IMediator
    {
        void Subscribe(Service.Service service, Type[] eventTypes);
        void Interact(Event @event, Service.Service publisher);
    }
}