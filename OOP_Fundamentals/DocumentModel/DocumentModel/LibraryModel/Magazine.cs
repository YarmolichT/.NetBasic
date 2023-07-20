using System.Text;

namespace DocumentModel.LibraryModel
{
    public class Magazine : Book
    {
        public string ReleaseNumber { get; set; }
        public string Publisher { get; set; }
        public DateTime DatePublished { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"Title: {Title}");
            sb.AppendLine($"Publisher: {Publisher}");
            sb.AppendLine($"Release Number: {ReleaseNumber}");
            sb.AppendLine($"Date Published: {DatePublished}");

            return sb.ToString();
        }
    }
}
