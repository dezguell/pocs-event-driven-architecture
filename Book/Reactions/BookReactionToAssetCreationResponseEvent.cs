using System;
using Common.Events;
using Common.Reaction;
using Common.Service;

namespace Book.Reactions
{
    public class BookReactionToAssetCreationResponseEvent : Reaction
    {
        public BookReactionToAssetCreationResponseEvent(Service service) : base(service)
        {
        }

        public override void ReactTo(Event @event)
        {
            Console.WriteLine(" ---- " +
                              $"{this.service.GetType().Name}: Saving a asset... " +
                              $"this action was requested by: {@event.GetService().GetType().Name} ");

            this.service.Interact(new SaveAssetActionCompleteEvent(this.service));
        }
    }
}