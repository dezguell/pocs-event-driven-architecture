using Asset.Events;
using Asset.Models;
using Common.Events.EventBox;
using Common.Mediator;
using Common.Reaction;
using Common.Service;
using DataImport.Reactions;

namespace DataImport
{
    public class DataImportService : Service
    {
        public DataImportService(IMediator mediator)
            : base(mediator)
        {
            RegisterReactions(
                new List<EventReaction>
                {
                    new()
                    {
                        EventType = typeof(AssetCreationResponseEvent),
                        Handler = new DataImportReactionToAssetCreationResponseEvent(this),
                    },
                    new()
                    {
                        EventType = typeof(SendMessageEvent),
                        Handler = new DataImportReactionToSendMessageEvent(this),
                    },
                    new()
                    {
                        EventType = typeof(SaveAssetActionCompleteEvent),
                        Handler = new DataImportReactionToSaveAssetActionCompleteEvent(this),
                    },
                }
            );
        }

        public void SendAssetCreationRequest(Guid id, string assetTypeValue, int cost)
        {
            var asset = new AssetData(id, assetTypeValue, cost);
            Interact(new AssetCreationRequestEvent(asset));
        }
    }
}
