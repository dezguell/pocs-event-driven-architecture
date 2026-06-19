using Common.Events;
using Common.Events.EventBox;
using Common.Reaction;
using Common.Service;

namespace DataImport.Reactions
{
    public class DataImportReactionToSendMessageEvent : Reaction
    {
        public DataImportReactionToSendMessageEvent(Service service) : base(service)
        {
        }

        public override void ReactTo(DomainEvent domainEvent)
        {
            var message = (domainEvent as SendMessageEvent)?.Message;
            Console.WriteLine(" ---- " +
                              $"{this.service.GetType().Name} " +
                              $"was notified of: {domainEvent.GetType().Name} " +
                              $"from: {domainEvent.PublisherName} " +
                              $"with content: {message}\n");
        }
    }
}