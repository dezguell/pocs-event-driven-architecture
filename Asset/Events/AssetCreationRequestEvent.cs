using Common.Events;
using AssetModel = Asset.Models.Asset;

namespace Asset.Events
{
    public class AssetCreationRequestEvent : Event
    {
        private readonly AssetModel _asset;

        public AssetCreationRequestEvent(AssetModel asset)
        {
            _asset = asset;
        }

        public AssetModel GetAsset()
        {
            return _asset;
        }
    }
}
