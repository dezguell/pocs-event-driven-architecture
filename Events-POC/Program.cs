using Asset;
using Book;
using DataImport;
using LocalMediator;

namespace Events_POC
{
    class Program
    {
        private static readonly Mediator mediator = new();
        private static readonly AssetService assetService = new(mediator);
        private static readonly BookService bookService = new(mediator);
        private static readonly DataImportService dataImportService = new(mediator);

        static void Main(string[] args)
        {
            SendMessages();
            SendAssetCreationRequest();
            Console.ReadKey();
        }

        private static void SendMessages()
        {
            Console.WriteLine("Sending Messages: ");
            foreach (var (typeName, send) in new (string, Action<string>)[]
            {
                (assetService.GetType().Name,      assetService.SendMessage),
                (bookService.GetType().Name,       bookService.SendMessage),
                (dataImportService.GetType().Name, dataImportService.SendMessage),
            })
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
