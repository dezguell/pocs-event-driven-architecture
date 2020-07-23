using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Common.Events;
using Common.Mediator;
using Common.Models;
using Common.Reaction;
using Common.Service;
using DataImport.Reactions;

namespace DataImport
{
    public class DataImportService : Service
    {
        public DataImportService(IMediator mediator) : base(mediator)
        {
            mediator.Subscribe(new KeyValuePair<Service, Event[]>(this, new Event[]
            {
                new SendMessageEvent(this),
                new AssetCreationResponseEvent(this),
                new SaveAssetActionCompleteEvent(this), 
            }));

            this.EventReactionRegistry = new List<EventReaction>()
            {
                new EventReaction { Event = new AssetCreationResponseEvent(this), Reaction = new DataImportReactionToAssetCreationResponseEvent(this)},
                new EventReaction {Event = new SendMessageEvent(this), Reaction = new DataImportReactionToSendMessageEvent(this)},
                new EventReaction {Event = new SaveAssetActionCompleteEvent(this),Reaction = new DataImportReactionToSaveAssetActionCompleteEvent(this)}

            };
        }

        public void SendAssetCreationRequest(Guid id, string assettypevalue, int cost)
        {
            // create asset logic 
            var asset = new Asset(id,assettypevalue,cost);
            
            //Interaction with the mediator exposing the asset creation envent
            mediator.Interact(new AssetCreationRequestEvent(this,asset));
        }
    }
}
