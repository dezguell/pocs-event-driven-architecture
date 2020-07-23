using System;
using System.Diagnostics;
using Common;
using Common.Events;
using Common.Reaction;
using Common.Service;

namespace Asset.Reactions
{
    public class AssetReactionToCreationRequestEvent : Reaction
    {
        public AssetReactionToCreationRequestEvent(Service service) : base(service)
        {
        }

        public override void ReactTo(Event @event)
        {
            var asset = (@event as AssetCreationRequestEvent)?.GetAsset();
            Debug.Assert(asset != null, nameof(asset) + " != null");
            Console.WriteLine($@" ----{this.service.GetType().Name}: Creating a asset... 
                 Asset Data: 
                 ID: {asset._id}
                 Type: {asset._assettype}
                 Cost: {asset._cost}
      this action was requested by: {@event.GetService().GetType().Name} ");

            this.service.Interact(new AssetCreationResponseEvent(this.service));
        }

    }
}