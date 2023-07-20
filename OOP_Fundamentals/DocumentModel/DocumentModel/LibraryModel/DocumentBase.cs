namespace DocumentModel.LibraryModel
{
    public abstract class DocumentBase : Document
    {
        public int ISBN { get; set; }
        public List<string> Authors { get; set; }
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; }
    }
}
