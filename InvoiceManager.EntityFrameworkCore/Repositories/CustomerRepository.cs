using InvoiceManager.DataAccess.Repositories;
using InvoiceManager.EntityFrameworkCore.DataBase;
using InvoiceManager.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace InvoiceManager.EntityFrameworkCore.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDataBaseTransaction _dataBaseTransaction;

        public CustomerRepository(IDataBaseTransaction dataBaseTransaction)
        {
            _dataBaseTransaction = dataBaseTransaction;
        }

        public void Create(Customer item)
        {
            _dataBaseTransaction.Insert(item);
        }

        public Customer GetBy(int id)
        {
            return _dataBaseTransaction.GetById<Customer>(item => item.Id == id);
        }

        public IEnumerable<Customer> GetBy(Expression<Func<Customer, bool>> predicate)
        {
            return _dataBaseTransaction.FindBy(predicate);
        }

        public void Remove(Customer item)
        {
            _dataBaseTransaction.SoftRemove(item);
        }

        public void Update(Customer item)
        {
            _dataBaseTransaction.Update(item);
        }
    }
}
