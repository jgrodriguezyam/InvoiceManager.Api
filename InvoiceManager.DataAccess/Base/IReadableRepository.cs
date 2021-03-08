using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace InvoiceManager.DataAccess.Base
{
    public interface IReadableRepository<T>
    {
        T GetBy(int id);
        IEnumerable<T> GetBy(Expression<Func<T, bool>> predicate);
    }
}
