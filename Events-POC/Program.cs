using System;
using System.Collections.Generic;
using Events_POC.Colleagues;
using Events_POC.Mediator;

namespace Events_POC
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = new MessageMediator();
            var jon = new Jon(mediator);
            var peter = new Peter(mediator);
            var ema = new Ema(mediator);

            var exitCondition = false;

            while (!exitCondition)
            {
                SendMessages(mediator);
            }
        }

        private static void SendMessages(IMediator mediator)
        {
            Console.WriteLine("Sending Messages: ");
            foreach (var colleague in mediator.GetColleagues())
            {
                Console.Write($" -- {colleague.GetType().Name}: ");
                colleague.SendMessage(Console.ReadLine());
                Console.WriteLine("-----------------------");
            }


        }
    }
}
