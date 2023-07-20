using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace DocumentModel.LibraryModel
{
    public class LocalizedBook : Book
    {
        public string CountryOfLocalization { get; set; }
        public string LocalPublisher { get; set; }

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
            sb.AppendLine($"Country Of Localization: {CountryOfLocalization}");

            return sb.ToString();
        }
    }
}

