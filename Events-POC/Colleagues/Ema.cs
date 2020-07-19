using Events_POC.Events;
using Events_POC.Mediator;

namespace Events_POC.Colleagues
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