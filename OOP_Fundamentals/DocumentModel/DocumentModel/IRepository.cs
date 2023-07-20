namespace DocumentModel
{
    public interface IRepository<T>
    {
        public void SaveItem(T Document);

        public T SearchItemById(int itemId);
    }
}
