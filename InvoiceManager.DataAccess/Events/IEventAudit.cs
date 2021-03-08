namespace InvoiceManager.DataAccess.Events
{
    public interface IEventAudit
    {
        void OnPreInsert(object entity);
        void OnPreUpdate(object entity);
        void OnPreDelete(object entity);

        void OnPreInsertForSystem(object entity);
        void OnPreUpdateForSystem(object entity);
        void OnPreDeleteForSystem(object entity);
    }
}
