namespace DocumentModel
{
    public interface IProvider<T>
    {
        public void SaveItem(T item);

        public T SearchItemById(int id);
    }
}
