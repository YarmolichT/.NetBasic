using DocumentModel.LibraryModel;

namespace DocumentModel.DocumentService
{
    public interface IDocument
    {
        public Magazine ValidateDataForMagazine(int Id, string title, string releaseNumber, string publisher);
    }
}
