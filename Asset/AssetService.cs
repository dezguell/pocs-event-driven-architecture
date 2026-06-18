using Asset.Reactions;
using Common.Events;
using Common.Events.EventBox;
using Common.Mediator;
using Common.Reaction;
using Common.Service;
using System.Collections.Generic;

namespace Asset
{
    public class AssetService : Service
    {
        public AssetService(IMediator mediator) : base(mediator)
        {
            this.EventReactionRegistry = new List<EventReaction>()
            {
                new EventReaction {Event = new AssetCreationRequestEvent(this,null), Reaction = new AssetReactionToCreationRequestEvent(this)},
                new EventReaction {Event = new SendMessageEvent(this), Reaction = new AssetReactionToSendMessageEvent(this)}
            };

            mediator.Subscribe(new KeyValuePair<Service, Event[]>(this, new Event[]
            {
                new SendMessageEvent(this),
                new AssetCreationRequestEvent(this,null),
            }));
        }
    }
}