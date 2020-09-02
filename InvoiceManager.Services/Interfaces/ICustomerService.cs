using InvoiceManager.DTO.BaseResponse;
using InvoiceManager.DTO.Messages.Customers;
using System.Collections.Generic;

namespace InvoiceManager.Services.Interfaces
{
    public interface ICustomerService
    {
        List<CustomerResponse> Search(SearchCustomersRequest request);
        CustomerResponse Get(GetCustomerRequest request);
        CreateResponse Create(CustomerRequest request);
        SuccessResponse Update(CustomerRequest request);        
        SuccessResponse Delete(DeleteCustomerRequest request);
    }
}
