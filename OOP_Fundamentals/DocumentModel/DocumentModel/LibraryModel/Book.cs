using System.Text;

namespace DocumentModel.LibraryModel
{
    public class Book : DocumentBase
    {
        public DateTime DatePublished { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"Title: {Title}");
            sb.AppendLine($"Authors: {string.Join("; ", Authors)}");
            sb.AppendLine($"Date Published: {DatePublished}");
            sb.AppendLine($"ISBN: {ISBN}");
            sb.AppendLine($"Number Of Pages: {NumberOfPages}");
            sb.AppendLine($"Publisher: {Publisher}");

            return sb.ToString();
        }
    }
}
