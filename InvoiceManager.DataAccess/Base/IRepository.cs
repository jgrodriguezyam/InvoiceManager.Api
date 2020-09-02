namespace InvoiceManager.DataAccess.Base
{
    public interface IRepository<T> : IReadableRepository<T>, IWritableRepository<T>
    {
    }
}
