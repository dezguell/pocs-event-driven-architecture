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

        public override void ReactTo(Event @event)
        {
            var message = (@event as SendMessageEvent)?.Message;
            Console.WriteLine(" ---- " +
                              $"{this.GetType().Name} " +
                              $"was notified of: {@event.GetType().Name} " +
                              $"from: {@event.PublisherName} " +
                              $"with content: {message}\n");
        }
    }
}