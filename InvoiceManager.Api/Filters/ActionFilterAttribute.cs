using InvoiceManager.EntityFrameworkCore.DataBase;
using InvoiceManager.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InvoiceManager.Api.Filters
{
    public class ActionFilterAttribute : IActionFilter
    {
        private readonly IDataBaseTransaction _dataBaseTransaction;

        public ActionFilterAttribute(IDataBaseTransaction dataBaseTransaction)
        {
            _dataBaseTransaction = dataBaseTransaction;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception.IsNull())            
                _dataBaseTransaction.Commit();            
            else            
                _dataBaseTransaction.Rollback();
        }
    }
}
