using System.Collections.Generic;
using Events_POC.Events;
using Events_POC.Mediator;

namespace Events_POC.Services
{
    public class AssetService : Service
    {
        public AssetService(IMediator mediator) : base(mediator)
        {
            mediator.Subscribe(new KeyValuePair<Service, Event[]>(this, new Event[]
            {
                new SendMessageEvent(this),
                new SendInteractionRequestEvent(this,null),
            }));
        }
    }
}