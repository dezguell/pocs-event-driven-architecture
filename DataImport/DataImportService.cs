using Asset.Events;
using Common.Events.EventBox;
using AssetModel = Asset.Models.Asset;
using Common.Mediator;
using Common.Reaction;
using Common.Service;
using DataImport.Reactions;

namespace DataImport
{
    public class DataImportService : Service
    {
        public DataImportService(IMediator mediator) : base(mediator)
        {
            RegisterReactions(new List<EventReaction>
            {
                new() { EventType = typeof(AssetCreationResponseEvent),   Reaction = new DataImportReactionToAssetCreationResponseEvent(this) },
                new() { EventType = typeof(SendMessageEvent),             Reaction = new DataImportReactionToSendMessageEvent(this) },
                new() { EventType = typeof(SaveAssetActionCompleteEvent), Reaction = new DataImportReactionToSaveAssetActionCompleteEvent(this) }
            });
        }

        public void SendMessage(string message) => Interact(new SendMessageEvent(message));

        public void SendAssetCreationRequest(Guid id, string assetTypeValue, int cost)
        {
            var asset = new AssetModel(id, assetTypeValue, cost);
            Interact(new AssetCreationRequestEvent(asset));
        }
    }
}
