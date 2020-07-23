using System;
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
            Console.WriteLine(" ---- " +
                              $"{this.service.GetType().Name}: Creating a asset... " +
                              $"this action was requested by: {@event.GetService().GetType().Name} ");

            this.service.Interact(new AssetCreationResponseEvent(this.service));
        }

    }
}