using System;
using Common;
using Common.Events;
using Common.Reaction;
using Common.Service;

namespace DataImport.Reactions
{
    public class DataImportReactionToSendMessageEvent : Reaction
    {
        public DataImportReactionToSendMessageEvent(Service service) : base(service)
        {
        }

        public override void ReactTo(Event @event)
        {
            var colleague = @event.GetService();
            Console.WriteLine(" ---- " +
                              $"{this.service.GetType().Name} " +
                              $"was notified of: {@event.GetType().Name} " +
                              $"from: {colleague.GetType().Name} " +
                              $"with content: {colleague.GetMessage()}\n");
        }


    }
}