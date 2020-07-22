using System;
using Common;
using Common.Events;

namespace DataImport.Reactions
{
    public class AssetCreationResponseEventReaction : Reaction
    {
        public AssetCreationResponseEventReaction(Service service) : base(service)
        {
        }

        public override void ReactTo(Event @event)
        {
            Console.WriteLine(" ---- " +
                              $"{this.service.GetType().Name}: Notification of asset creation...  " +
                              $"this action was perform by: {@event.GetService().GetType().Name} ");
        }
    }
}