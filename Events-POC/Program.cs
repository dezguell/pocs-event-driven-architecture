using System;
using System.Collections.Generic;
using Events_POC.Events;
using Events_POC.Mediator;
using Events_POC.Services;

namespace Events_POC
{
    class Program
    {
        private static IMediator mediator = new ServicesMediator();
        private static Service asset = new AssetService(mediator);
        private static Service gl = new GeneralLagerService(mediator);
        private static Service book = new BookService(mediator);

        static void Main(string[] args)
        {
            SendMessages();
            SendInteractionRequest();

            Console.ReadKey();
        }

        private static void SendMessages()
        {
            Console.WriteLine("Sending Messages: ");
            foreach (var colleague in mediator.GetColleagues())
            {
                Console.Write($" -- {colleague.GetType().Name}: ");
                colleague.SendMessage(Console.ReadLine());
                Console.WriteLine("-----------------------");
            }
        }

        private static void SendInteractionRequest()
        {
            Console.WriteLine("Sending Friend Requests : ");
            Console.WriteLine(" -- From Ema to Jon: ");
            book.SendInteractionRequestTo(asset);

            Console.WriteLine(" -- From Jon to Peter: ");
            asset.SendInteractionRequestTo(gl);

            Console.WriteLine(" -- From Peter to Ema: ");
            gl.SendInteractionRequestTo(book);
            Console.WriteLine("-----------------------");
        }
    }
}
