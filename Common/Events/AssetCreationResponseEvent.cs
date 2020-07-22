namespace Common.Events
{
    public class AssetCreationResponseEvent : Event
    {
        public AssetCreationResponseEvent(Service service) : base(service)
        {
        }
    }
}