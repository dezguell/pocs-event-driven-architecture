using Common.Events;
using Common.Events.EventBox;
using Common.Reaction;
using Common.Service;

namespace Asset.Reactions
{
    public class AssetReactionToSendMessageEvent(Service service) : Reaction(service)
    {
        public override void ReactTo(DomainEvent domainEvent)
        {
            var message = (domainEvent as SendMessageEvent)?.Message;
            Console.WriteLine(
                " ---- "
                    + $"{this.GetType().Name} "
                    + $"was notified of: {domainEvent.GetType().Name} "
                    + $"from: {domainEvent.PublisherName} "
                    + $"with content: {message}\n"
            );
        }
    }
}
