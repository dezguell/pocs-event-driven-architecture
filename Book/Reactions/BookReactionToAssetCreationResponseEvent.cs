using Asset.Events;
using Common.Events;
using Common.Reaction;
using Common.Service;

namespace Book.Reactions
{
    public class BookReactionToAssetCreationResponseEvent : Reaction
    {
        public BookReactionToAssetCreationResponseEvent(Service service)
            : base(service) { }

        public override void ReactTo(DomainEvent domainEvent)
        {
            Console.WriteLine(
                " ---- "
                    + $"{this.service.GetType().Name}: Received asset creation notification "
                    + $"from: {domainEvent.PublisherName} "
            );
        }
    }
}
