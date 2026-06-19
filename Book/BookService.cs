using Book.Reactions;
using Common.Events.EventBox;
using Common.Mediator;
using Common.Reaction;
using Common.Service;

namespace Book
{
    public class BookService : Service
    {
        public BookService(IMediator mediator) : base(mediator)
        {
            RegisterReactions(new List<EventReaction>
            {
                new() { EventType = typeof(AssetCreationResponseEvent), Reaction = new BookReactionToAssetCreationResponseEvent(this) },
                new() { EventType = typeof(SendMessageEvent),           Reaction = new BookReactionToSendEvent(this) }
            });
        }

        public void SendMessage(string message) => Interact(new SendMessageEvent(message));
    }
}
