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
        public AssetService(IMediator mediator)
            : base(mediator)
        {
            RegisterReactions(
                new List<EventReaction>
                {
                    new()
                    {
                        EventType = typeof(AssetCreationRequestEvent),
                        Handler = new AssetReactionToCreationRequestEvent(this),
                    },
                    new()
                    {
                        EventType = typeof(SendMessageEvent),
                        Handler = new AssetReactionToSendMessageEvent(this),
                    },
                }
            );
        }
    }
}
