using System;
using Common.Events;
using Common.Reaction;
using Common.Service;

namespace DataImport.Reactions
{
    public class DataImportReactionToSaveAssetActionCompleteEvent : Reaction
    {
        public DataImportReactionToSaveAssetActionCompleteEvent(Service service) : base(service)
        {
        }

        public override void ReactTo(Event @event)
        {
            Console.WriteLine(" ---- " +
                              $"{this.service.GetType().Name}: Notification of a saved asset...  " +
                              $"this action was perform by: {@event.GetService().GetType().Name} ");
        }
    }
}