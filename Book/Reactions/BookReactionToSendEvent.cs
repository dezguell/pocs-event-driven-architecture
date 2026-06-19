using Common.Events;
using Common.Events.EventBox;
using Common.Reaction;
using Common.Service;

namespace Book.Reactions
{
    public class BookReactionToSendEvent : Reaction
    {
        public BookReactionToSendEvent(Service service) : base(service)
        {
        }

        public override void ReactTo(DomainEvent domainEvent)
        {
            var message = (domainEvent as SendMessageEvent)?.Message;
            Console.WriteLine(" ---- " +
                              $"{this.GetType().Name} " +
                              $"was notified of: {domainEvent.GetType().Name} " +
                              $"from: {domainEvent.PublisherName} " +
                              $"with content: {message}\n");
        }
    }
}