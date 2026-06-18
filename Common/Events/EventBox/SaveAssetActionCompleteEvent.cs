namespace Common.Events.EventBox
{
    public class SaveAssetActionCompleteEvent : Event
    {
        public SaveAssetActionCompleteEvent(Service.Service service) : base(service)
        {
        }
    }
}