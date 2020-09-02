using AutoMapper;
using InvoiceManager.DTO.Messages.Companies;
using InvoiceManager.DTO.Messages.Customers;
using InvoiceManager.Model;

namespace InvoiceManager.Mapper.Configs
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            #region Company

            CreateMap<Company, Company>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.CreatedBy, act => act.Ignore())
                .ForMember(dest => dest.CreatedOn, act => act.Ignore())
                .ForMember(dest => dest.ModifiedBy, act => act.Ignore())
                .ForMember(dest => dest.ModifiedOn, act => act.Ignore())
                .ForMember(dest => dest.IsActive, act => act.Ignore());

            CreateMap<CompanyRequest, Company>();

            CreateMap<Company, CompanyResponse>();

            #endregion

            #region Customer

            CreateMap<Customer, Customer>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.CreatedBy, act => act.Ignore())
                .ForMember(dest => dest.CreatedOn, act => act.Ignore())
                .ForMember(dest => dest.ModifiedBy, act => act.Ignore())
                .ForMember(dest => dest.ModifiedOn, act => act.Ignore())
                .ForMember(dest => dest.IsActive, act => act.Ignore());

            CreateMap<CustomerRequest, Customer>();

            CreateMap<Customer, CustomerResponse>();

            #endregion
        }
    }
}
