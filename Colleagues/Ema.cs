namespace Events_POC
{
    internal class Ema : Colleague
    {
        public override void SendMessage(string message)
        {
            this.message = message;
            this.mediator.Interact(new SendMessageEvent(this));
        }

        public Ema(IMediator mediator) : base(mediator)
        {
        }
    }
}