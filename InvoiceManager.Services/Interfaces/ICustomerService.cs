using InvoiceManager.DTO.BaseResponse;
using InvoiceManager.DTO.Messages.Customers;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace InvoiceManager.Services.Interfaces
{
    public interface ICustomerService
    {   
        CreateResponse Create(CustomerRequest request);
        SuccessResponse Update(int id, CustomerRequest request);
        CustomerResponse Get(int id);
        SuccessResponse Delete(int id);
        SuccessResponse Patch(int id, JsonPatchDocument<CustomerRequest> request);
        List<CustomerResponse> Search(SearchCustomersRequest request);
    }
}
