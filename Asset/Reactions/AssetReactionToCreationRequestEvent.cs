using Asset.Events;
using Asset.Models;
using Common.Events;
using Common.Events.EventBox;
using Common.Reaction;
using Common.Service;

namespace Asset.Reactions
{
    public class AssetReactionToCreationRequestEvent(Service service) : Reaction(service)
    {
        public override void ReactTo(DomainEvent domainEvent)
        {
            var creationRequest = domainEvent as AssetCreationRequestEvent
                ?? throw new InvalidOperationException("Expected AssetCreationRequestEvent.");

            AssetData asset = creationRequest.Asset;

            Console.WriteLine($@" ----{this.service.GetType().Name}: Creating a asset...
                 Asset Data:
                 ID: {asset.Id}
                 Type: {asset.AssetType}
                 Cost: {asset.Cost}
      this action was requested by: {domainEvent.PublisherName} ");

            this.service.Interact(new AssetCreationResponseEvent(asset));
            this.service.Interact(new SaveAssetActionCompleteEvent());
        }
    }
}