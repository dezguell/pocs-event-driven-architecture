using System;
using Common;
using Common.Events;

namespace Asset.Reactions
{
    public class SendMessageEventEventReaction : Reaction
    {
        public SendMessageEventEventReaction(Service service) : base(service)
        {
        }
        public override void ReactTo(Event @event)
        {
            var colleague = @event.GetService();
            Console.WriteLine(" ---- " +
                              $"{this.GetType().Name} " +
                              $"was notified of: {@event.GetType().Name} " +
                              $"from: {colleague.GetType().Name} " +
                              $"with content: {colleague.GetMessage()}\n");
        }
    }
}