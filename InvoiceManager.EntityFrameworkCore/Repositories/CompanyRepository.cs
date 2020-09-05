using InvoiceManager.DataAccess.Repositories;
using InvoiceManager.EntityFrameworkCore.DataBase;
using InvoiceManager.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace InvoiceManager.EntityFrameworkCore.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDataBaseTransaction _dataBaseTransaction;

        public CompanyRepository(IDataBaseTransaction dataBaseTransaction)
        {
            _dataBaseTransaction = dataBaseTransaction;
        }

        public void Create(Company item)
        {
            _dataBaseTransaction.Insert(item);
        }

        public Company GetBy(int id)
        {
            return _dataBaseTransaction.GetById<Company>(item => item.Id == id);
        }

        public IEnumerable<Company> GetBy(Expression<Func<Company, bool>> predicate)
        {
            return _dataBaseTransaction.FindBy(predicate);
        }

        public void Remove(Company item)
        {
            _dataBaseTransaction.SoftRemove(item);
        }

        public void Update(Company item)
        {
            _dataBaseTransaction.Update(item);
        }
    }
}
