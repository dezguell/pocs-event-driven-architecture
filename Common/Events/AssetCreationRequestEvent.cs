using Common.Models;

namespace Common.Events
{
    public class AssetCreationRequestEvent : Event
    {
        private readonly Asset _asset;

        public AssetCreationRequestEvent(Service.Service service, Asset asset) : base(service)
        {
            _asset = asset;
        }

        public Asset GetAsset()
        {
            return _asset;
        }
    }
}