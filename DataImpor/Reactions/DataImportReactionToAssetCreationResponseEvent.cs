using System;
using Common;
using Common.Events;
using Common.Reaction;
using Common.Service;

namespace DataImport.Reactions
{
    public class DataImportReactionToAssetCreationResponseEvent : Reaction
    {
        public DataImportReactionToAssetCreationResponseEvent(Service service) : base(service)
        {
        }

        public override void ReactTo(Event @event)
        {
            Console.WriteLine(" ---- " +
                              $"{this.service.GetType().Name}: Notification of a asset creation...  " +
                              $"this action was perform by: {@event.GetService().GetType().Name} ");
        }
    }
}