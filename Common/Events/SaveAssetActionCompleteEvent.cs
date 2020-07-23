namespace Common.Events
{
    public class SaveAssetActionCompleteEvent : Event
    {
        public SaveAssetActionCompleteEvent(Service.Service service) : base(service)
        {
        }
    }
}