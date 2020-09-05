using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InvoiceManager.EntityFrameworkCore.DataBase
{
    public interface IDataBaseTransaction
    {
        void Insert<T>(T objectToInsert) where T : class;
        void InsertForSystem<T>(T objectToInsert) where T : class;
        void Update<T>(T objectToUpdate) where T : class;
        void UpdateForSystem<T>(T objectToUpdate) where T : class;
        void SoftRemove<T>(T objectToRemove) where T : new();
        void HardRemove<T>(T objectToRemove) where T : new();
        void RemoveForSystem<T>(T objectToRemove) where T : new();
        T GetById<T>(Expression<Func<T, bool>> predicate) where T : class;        
        IEnumerable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class;
        IQueryable<T> GetQueryable<T>() where T : class;
        void Commit();
        void Rollback();
        InvoiceManagerContext GetDbContext();        
    }
}
