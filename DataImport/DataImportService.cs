using Common.Events;
using Common.Events.EventBox;
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
                new() {Event = new AssetCreationResponseEvent(this), Reaction = new DataImportReactionToAssetCreationResponseEvent(this)},
                new() {Event = new SendMessageEvent(this), Reaction = new DataImportReactionToSendMessageEvent(this)},
                new() {Event = new SaveAssetActionCompleteEvent(this),Reaction = new DataImportReactionToSaveAssetActionCompleteEvent(this)}

            };
        }

        public void SendAssetCreationRequest(Guid id, string assetTypeValue, int cost)
        {
            // create asset logic 
            var asset = new Asset(id, assetTypeValue, cost);

            //Interaction with the mediator exposing the asset creation event
            mediator.Interact(new AssetCreationRequestEvent(this, asset));
        }
    }
}
