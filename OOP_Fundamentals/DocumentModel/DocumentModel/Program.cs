using DocumentModel.LibraryModel;

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
            Book book = new()
            {
                Id = 1,
                ISBN = 10000,
                Title = "My first Book",
                Authors = new List<string>() { "Tatsiana", "Ivan1" },
                NumberOfPages = 13,
                DatePublished = DateTime.Now,
                Publisher = "publisher"
            };

            LocalizedBook localized = new()
            {
                Id = 2,
                ISBN = 2000,
                Title = "My first Localized Book",
                Authors = new List<string>() { "Tatsiana", "Ivan2" },
                NumberOfPages = 13,
                DatePublished = DateTime.Now,
                Publisher = "publisher",
                CountryOfLocalization = "Bel",
                LocalPublisher = "BelPublisher"
            };

            Patent patent = new()
            {
                Id = 3,
                Title = "My first patent",
                Authors = new List<string>() { "Tatsiana", "Ivan3" },
                DatePublished = DateTime.Today,
                ExpirationDate = DateTime.Today
            };

            Magazine magazine = new()
            {
                Id = 4,
                Title = "My first magazine",
                DatePublished = DateTime.Now,
                ReleaseNumber = "14.100.1",
                Publisher = "publisher"
            };

            IRepository<Document> fileRepository = new FileRepository<Document>();

            fileRepository.SaveItem(book);
            fileRepository.SaveItem(localized);
            fileRepository.SaveItem(patent);
            fileRepository.SaveItem(magazine);

            var filteredFiles = new List<Document>
            {
                fileRepository.SearchItemById(book.Id),
                fileRepository.SearchItemById(localized.Id),
                fileRepository.SearchItemById(patent.Id),
                fileRepository.SearchItemById(magazine.Id)
            };

            ShowItems(filteredFiles);
        }
    }
}