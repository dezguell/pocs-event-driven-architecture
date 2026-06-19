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

        public override void ReactTo(Event @event)
        {
            var message = (@event as SendMessageEvent)?.Message;
            Console.WriteLine(" ---- " +
                              $"{this.service.GetType().Name} " +
                              $"was notified of: {@event.GetType().Name} " +
                              $"from: {@event.PublisherName} " +
                              $"with content: {message}\n");
        }
    }
}