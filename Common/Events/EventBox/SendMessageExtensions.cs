namespace Common.Events.EventBox
{
    public static class SendMessageExtensions
    {
        public static void SendMessage(this Service.Service service, string message)
            => service.Interact(new SendMessageEvent(message));
    }
}
