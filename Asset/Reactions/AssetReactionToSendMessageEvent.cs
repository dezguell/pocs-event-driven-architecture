using Common.Events;
using Common.Events.EventBox;
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
            var message = (@event as SendMessageEvent)?.Message;
            Console.WriteLine(" ---- " +
                              $"{this.GetType().Name} " +
                              $"was notified of: {@event.GetType().Name} " +
                              $"from: {@event.PublisherName} " +
                              $"with content: {message}\n");
        }
    }
}