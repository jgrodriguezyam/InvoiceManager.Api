using InvoiceManager.DTO.BaseResponse;
using InvoiceManager.DTO.Messages.Companies;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace InvoiceManager.Services.Interfaces
{
    public interface ICompanyService
    {
        CreateResponse Create(CompanyRequest request);
        SuccessResponse Update(int id, CompanyRequest request);
        CompanyResponse Get(int id);
        SuccessResponse Delete(int id);
        SuccessResponse Patch(int id, JsonPatchDocument<CompanyRequest> request);
        List<CompanyResponse> Search(SearchCompaniesRequest request);
    }
}
