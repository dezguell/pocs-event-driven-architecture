using Asset.Models;
using Common.Events;

namespace Asset.Events
{
    public class AssetCreationRequestEvent(AssetData asset) : DomainEvent
    {
        public AssetData Asset { get; } = asset;
    }
}
