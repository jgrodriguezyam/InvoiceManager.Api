using InvoiceManager.DataAccess.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace InvoiceManager.EntityFrameworkCore.DataBase
{
    public class DataBaseTransaction : IDataBaseTransaction
    {
        private readonly InvoiceManagerContext _invoiceManagerContext;
        public IDbContextTransaction DbContextTransaction;
        public IEventAudit EventAudit;

        public DataBaseTransaction(InvoiceManagerContext invoiceManagerContext)
        {
            _invoiceManagerContext = invoiceManagerContext;
            DbContextTransaction = _invoiceManagerContext.Database.BeginTransaction(IsolationLevel.Snapshot);
            EventAudit = new EventAudit();
        }

        public void Insert<T>(T objectToInsert) where T : class
        {
            EventAudit.OnPreInsert(objectToInsert);
            _invoiceManagerContext.Set<T>().Add(objectToInsert);
            _invoiceManagerContext.SaveChanges();
        }

        public void InsertForSystem<T>(T objectToInsert) where T : class
        {
            EventAudit.OnPreInsertForSystem(objectToInsert);
            _invoiceManagerContext.Set<T>().Add(objectToInsert);
            _invoiceManagerContext.SaveChanges();
        }

        public void Update<T>(T objectToUpdate) where T : class
        {
            EventAudit.OnPreUpdate(objectToUpdate);
            _invoiceManagerContext.SaveChanges();
        }

        public void UpdateForSystem<T>(T objectToUpdate) where T : class
        {
            EventAudit.OnPreUpdateForSystem(objectToUpdate);
            _invoiceManagerContext.SaveChanges();
        }

        public void SoftRemove<T>(T objectToRemove) where T : new()
        {
            EventAudit.OnPreDelete(objectToRemove);
            _invoiceManagerContext.SaveChanges();
        }

        public void HardRemove<T>(T objectToRemove) where T : new()
        {
            _invoiceManagerContext.Remove(objectToRemove);
            _invoiceManagerContext.SaveChanges();
        }

        public void RemoveForSystem<T>(T objectToRemove) where T : new()
        {
            EventAudit.OnPreDeleteForSystem(objectToRemove);
            _invoiceManagerContext.SaveChanges();
        }

        public T GetById<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _invoiceManagerContext.Set<T>().FirstOrDefault(predicate);
        }        

        public IEnumerable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _invoiceManagerContext.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetQueryable<T>() where T : class
        {
            return _invoiceManagerContext.Set<T>();
        }

        public void Commit()
        {
            DbContextTransaction.Commit();
            DbContextTransaction.Dispose();
            _invoiceManagerContext.Database.CloseConnection();
        }

        public void Rollback()
        {
            DbContextTransaction.Rollback();
            DbContextTransaction.Dispose();
            _invoiceManagerContext.Database.CloseConnection();
        }

        public InvoiceManagerContext GetDbContext()
        {
            return _invoiceManagerContext;
        }
    }
}
