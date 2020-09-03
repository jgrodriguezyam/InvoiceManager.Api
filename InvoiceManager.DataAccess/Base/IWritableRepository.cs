namespace InvoiceManager.DataAccess.Base
{
    public interface IWritableRepository<in T>
    {
        void Create(T item);
        void Update(T item);
        void Remove(T item);
    }
}
