namespace Common.Events
{
    public class AssetCreationResponseEvent : Event
    {
        public AssetCreationResponseEvent(Service.Service service) : base(service)
        {
        }
    }
}