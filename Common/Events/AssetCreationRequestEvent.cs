namespace Common.Events
{
    public class AssetCreationRequestEvent:Event
    {
        public AssetCreationRequestEvent(Service.Service service) : base(service)
        {
        }
    }
}