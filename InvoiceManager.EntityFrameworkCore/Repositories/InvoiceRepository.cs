using InvoiceManager.DataAccess.Repositories;
using InvoiceManager.EntityFrameworkCore.DataBase;
using InvoiceManager.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace InvoiceManager.EntityFrameworkCore.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IDataBaseTransaction _dataBaseTransaction;

        public InvoiceRepository(IDataBaseTransaction dataBaseTransaction)
        {
            _dataBaseTransaction = dataBaseTransaction;
        }

        public void Create(Invoice item)
        {
            _dataBaseTransaction.Insert(item);
        }

        public Invoice GetBy(int id)
        {
            return _dataBaseTransaction.GetById<Invoice>(item => item.Id == id);
        }

        public IEnumerable<Invoice> GetBy(Expression<Func<Invoice, bool>> predicate)
        {
            return _dataBaseTransaction.FindBy(predicate);
        }

        public void Remove(Invoice item)
        {
            _dataBaseTransaction.SoftRemove(item);
        }

        public void Update(Invoice item)
        {
            _dataBaseTransaction.Update(item);
        }
    }
}
