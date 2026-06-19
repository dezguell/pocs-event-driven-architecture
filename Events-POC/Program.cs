using Asset;
using Book;
using Common.Events.EventBox;
using Common.Mediator;
using DataImport;

namespace Events_POC
{
    class Program
    {
        private static readonly Mediator mediator = new();
        private static readonly AssetService assetService = new(mediator);
        private static readonly BookService bookService = new(mediator);
        private static readonly DataImportService dataImportService = new(mediator);

        private static readonly (string serviceName, Action<string> send)[] services =
        [
            (assetService.GetType().Name, assetService.SendMessage),
            (bookService.GetType().Name, bookService.SendMessage),
            (dataImportService.GetType().Name, dataImportService.SendMessage),
        ];

        static void Main(string[] args)
        {
            SendMessages();
            SendAssetCreationRequest();
            Console.ReadKey();
        }

        private static void SendMessages()
        {
            Console.WriteLine("Sending Messages: ");
            foreach (var (typeName, send) in services)
            {
                Console.Write($" -- {typeName}: ");
                send(Console.ReadLine());
                Console.WriteLine("-----------------------");
            }
        }

        private static void SendAssetCreationRequest()
        {
            Console.WriteLine("Sending assetCreation Requests : ");
            dataImportService.SendAssetCreationRequest(Guid.NewGuid(), "assetTypeValue", 3000);
        }
    }
}
