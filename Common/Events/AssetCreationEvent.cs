namespace Common.Events
{
    public class AssetCreationRequestEvent:Event
    {
        public AssetCreationRequestEvent(Service service) : base(service)
        {
        }
    }
}