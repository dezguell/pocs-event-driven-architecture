using Asset.Events;
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
                new() { EventType = typeof(AssetCreationResponseEvent), Handler = new BookReactionToAssetCreationResponseEvent(this) },
                new() { EventType = typeof(SendMessageEvent),           Handler = new BookReactionToSendEvent(this) }
            });
        }

    }
}
