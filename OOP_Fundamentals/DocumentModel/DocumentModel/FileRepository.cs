using DocumentModel.LibraryModel;

namespace DocumentModel
{
    public class FileRepository<T> : IRepository<T> where T : Document 
    {
        private IProvider<T> _fileProvider;

        public FileRepository() {

            _fileProvider = new FileProvider<T>();
        }

        public void SaveItem(T document) {
            _fileProvider.SaveItem(document);
        }

        public T SearchItemById(int id) {

            var item = _fileProvider.SearchItemById(id);

            return item;
        }
    }
}
