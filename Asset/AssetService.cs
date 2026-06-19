using Asset.Events;
using Asset.Reactions;
using Common.Events.EventBox;
using Common.Mediator;
using Common.Reaction;
using Common.Service;

namespace Asset
{
    public class AssetService : Service
    {
        public AssetService(IMediator mediator) : base(mediator)
        {
            RegisterReactions(new List<EventReaction>
            {
                new() { EventType = typeof(AssetCreationRequestEvent), Reaction = new AssetReactionToCreationRequestEvent(this) },
                new() { EventType = typeof(SendMessageEvent),          Reaction = new AssetReactionToSendMessageEvent(this) }
            });
        }

        public void SendMessage(string message) => Interact(new SendMessageEvent(message));
    }
}