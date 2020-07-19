using Events_POC.Events;
using Events_POC.Mediator;

namespace Events_POC.Colleagues
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