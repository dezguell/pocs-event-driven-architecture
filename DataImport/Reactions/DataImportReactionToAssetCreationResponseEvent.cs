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

        public override void ReactTo(DomainEvent domainEvent)
        {
            Console.WriteLine(" ---- " +
                              $"{this.service.GetType().Name}: Notification of a asset creation...  " +
                              $"this action was perform by: {domainEvent.PublisherName} ");
        }
    }
}