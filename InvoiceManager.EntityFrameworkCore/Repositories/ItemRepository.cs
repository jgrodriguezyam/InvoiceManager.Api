using InvoiceManager.DataAccess.Repositories;
using InvoiceManager.EntityFrameworkCore.DataBase;
using InvoiceManager.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace InvoiceManager.EntityFrameworkCore.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IDataBaseTransaction _dataBaseTransaction;

        public ItemRepository(IDataBaseTransaction dataBaseTransaction)
        {
            _dataBaseTransaction = dataBaseTransaction;
        }

        public void Create(Item item)
        {
            _dataBaseTransaction.Insert(item);
        }

        public Item GetBy(int id)
        {
            return _dataBaseTransaction.GetById<Item>(item => item.Id == id);
        }

        public IEnumerable<Item> GetBy(Expression<Func<Item, bool>> predicate)
        {
            return _dataBaseTransaction.FindBy(predicate);
        }

        public void Remove(Item item)
        {
            _dataBaseTransaction.HardRemove(item);
        }

        public void Update(Item item)
        {
            _dataBaseTransaction.Update(item);
        }
    }
}
