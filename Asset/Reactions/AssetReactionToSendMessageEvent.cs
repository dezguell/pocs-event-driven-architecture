using System;
using Common;
using Common.Events;
using Common.Reaction;
using Common.Service;

namespace Asset.Reactions
{
    public class AssetReactionToSendMessageEvent : Reaction
    {
        public AssetReactionToSendMessageEvent(Service service) : base(service)
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