using Book.Reactions;
using Common.Events;
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
            this.mediator.Subscribe(new KeyValuePair<Service, Event[]>(this, new Event[]
            {
                new SendMessageEvent(this),
                new AssetCreationResponseEvent(this),
            }));

            this.EventReactionRegistry = new List<EventReaction>()
            {
                new() {Event = new AssetCreationResponseEvent(this),Reaction = new BookReactionToAssetCreationResponseEvent(this)},
                new() {Event = new SendMessageEvent(this),Reaction = new BookReactionToSendEvent(this)}
            };
        }
    }
}
