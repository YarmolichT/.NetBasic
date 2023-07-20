using System.Text;

namespace DocumentModel.LibraryModel
{
    public class Patent : Book
    {
        public DateTime ExpirationDate { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"Title: {Title}");
            sb.AppendLine($"Authors: {string.Join("; ", Authors)}");
            sb.AppendLine($"Date Published: {DatePublished}");
            sb.AppendLine($"Expiration Date: {ExpirationDate}");

            return sb.ToString();
        }
    }
}
