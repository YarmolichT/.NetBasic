using DocumentModel.DocumentService;
using Document = DocumentModel.LibraryModel.Document;

namespace DocumentModel
{
    public class Program
    {
        private static void ShowItems(List<Document> itemsList)
        {
            foreach (var item in itemsList)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {      
            IRepository<Document> repository = new FileRepository<Document>();

            DocumentServices documentServices = new DocumentServices(repository);

            Console.WriteLine("Please, select number of operation: " +
                "1. Search  2. Add  3. Close window ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Enter id for Search");
                 
                    int IdOfDocument = Convert.ToInt32(Console.ReadLine());
                    var filteredFiles = new List<Document>
                    {
                         documentServices._repository.SearchItemById(IdOfDocument)
                    };

                    ShowItems(filteredFiles);                  

                    break;

                case "2":
                    Console.WriteLine("Enter data to create Magazine using template: id;title;releaseNumber;publisher;");
                   
                    string[] enteredData = Console.ReadLine().Split(new char[] { ';' });
                    int IdForMagazine = Convert.ToInt32(enteredData[0]);
                    var magazine = documentServices.ValidateDataForMagazine(IdForMagazine, enteredData[1], enteredData[2], enteredData[3]);
                    
                    documentServices._repository.SaveItem(magazine);

                    break;

                case "3":
                    Console.ReadKey(true);               
                    break;                
            }       
        }
    }
}