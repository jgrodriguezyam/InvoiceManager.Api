using InvoiceManager.DataAccess.Base;
using InvoiceManager.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace InvoiceManager.DataAccess.Repositories
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        IEnumerable<Invoice> Search(Expression<Func<Invoice, bool>> predicate);
    }
}
