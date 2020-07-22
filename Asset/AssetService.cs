using System.Collections.Generic;
using System.Linq;
using Asset.Reactions;
using Common;
using Common.Events;

namespace Asset
{
    public class AssetService : Service
    {
        public AssetService(IMediator mediator) : base(mediator)
        {
            this.EventReactionRegistry = new List<EventReaction>()
            {
                new EventReaction {Event = new AssetCreationRequestEvent(this), Reaction = new AssetCreationRequestEventReaction(this)},
                new EventReaction {Event = new SendMessageEvent(this), Reaction = new SendMessageEventEventReaction(this)}
            };

            mediator.Subscribe(new KeyValuePair<Service, Event[]>(this, new Event[]
            {
                new SendMessageEvent(this),
                new AssetCreationRequestEvent(this),
            }));
        }
    }
}