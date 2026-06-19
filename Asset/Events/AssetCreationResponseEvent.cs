using Asset.Models;
using Common.Events;

namespace Asset.Events
{
    public class AssetCreationResponseEvent : DomainEvent
    {
        public AssetData Asset { get; }

        public AssetCreationResponseEvent(AssetData asset)
        {
            Asset = asset;
        }
    }
}
