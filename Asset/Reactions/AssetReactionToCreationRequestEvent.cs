using Asset.Events;
using Common.Events;
using Common.Events.EventBox;
using Common.Reaction;
using Common.Service;
using AssetModel = Asset.Models.Asset;

namespace Asset.Reactions
{
    public class AssetReactionToCreationRequestEvent : Reaction
    {
        public AssetReactionToCreationRequestEvent(Service service) : base(service)
        {
        }

        public override void ReactTo(Event @event)
        {
            var asset = (@event as AssetCreationRequestEvent)?.GetAsset()
                ?? throw new InvalidOperationException("AssetCreationRequestEvent must carry an asset.");

            Console.WriteLine($@" ----{this.service.GetType().Name}: Creating a asset...
                 Asset Data:
                 ID: {asset.Id}
                 Type: {asset.AssetType}
                 Cost: {asset.Cost}
      this action was requested by: {@event.PublisherName} ");

            this.service.Interact(new AssetCreationResponseEvent());
        }
    }
}