namespace Events_POC
{
    public class Peter : Colleague
    {
        public Peter(IMediator mediator) : base(mediator)
        {
        }

        public override void SendMessage(string message)
        {
            this.message = message;
            this.mediator.Interact(new SendMessageEvent(this));
        }
    }
}