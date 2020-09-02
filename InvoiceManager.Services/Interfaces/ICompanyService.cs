using InvoiceManager.DTO.BaseResponse;
using InvoiceManager.DTO.Messages.Companies;
using System.Collections.Generic;

namespace InvoiceManager.Services.Interfaces
{
    public interface ICompanyService
    {
        List<CompanyResponse> Search(SearchCompaniesRequest request);
        CompanyResponse Get(GetCompanyRequest request);
        CreateResponse Create(CompanyRequest request);
        SuccessResponse Update(CompanyRequest request);
        SuccessResponse Delete(DeleteCompanyRequest request);
    }
}
