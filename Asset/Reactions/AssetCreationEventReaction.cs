using System;
using Common;
using Common.Events;

namespace Asset.Reactions
{
    public class AssetCreationRequestEventReaction : Reaction
    {
        public AssetCreationRequestEventReaction(Service service) : base(service)
        {
        }

        public override void ReactTo(Event @event)
        {
            Console.WriteLine(" ---- " +
                              $"{this.service.GetType().Name}: Creating an asset... " +
                              $"this action was requested by: {@event.GetService().GetType().Name} ");

            this.service.Interact(new AssetCreationResponseEvent(this.service));
        }


    }
}