using AutoMapper;
using InvoiceManager.DTO.Messages.Companies;
using InvoiceManager.DTO.Messages.Customers;
using InvoiceManager.DTO.Messages.Invoices;
using InvoiceManager.DTO.Messages.Items;
using InvoiceManager.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

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

            CreateMap<JsonPatchDocument<CompanyRequest>, JsonPatchDocument<Company>>();

            CreateMap<Operation<CompanyRequest>, Operation<Company>>();

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

            CreateMap<JsonPatchDocument<CustomerRequest>, JsonPatchDocument<Customer>>();

            CreateMap<Operation<CustomerRequest>, Operation<Customer>>();

            #endregion

            #region Invoice

            CreateMap<Invoice, Invoice>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.CreatedBy, act => act.Ignore())
                .ForMember(dest => dest.CreatedOn, act => act.Ignore())
                .ForMember(dest => dest.ModifiedBy, act => act.Ignore())
                .ForMember(dest => dest.ModifiedOn, act => act.Ignore())
                .ForMember(dest => dest.IsActive, act => act.Ignore());

            CreateMap<InvoiceRequest, Invoice>();

            CreateMap<Invoice, InvoiceResponse>();

            #endregion

            #region Item

            CreateMap<Item, Item>()
                .ForMember(dest => dest.Invoice, act => act.Ignore())
                .ForMember(dest => dest.InvoiceId, act => act.Ignore())

                .ForMember(dest => dest.CreatedBy, act => act.Ignore())
                .ForMember(dest => dest.CreatedOn, act => act.Ignore())
                .ForMember(dest => dest.ModifiedBy, act => act.Ignore())
                .ForMember(dest => dest.ModifiedOn, act => act.Ignore());

            CreateMap<ItemRequest, Item>();

            CreateMap<Item, ItemResponse>();

            #endregion
        }
    }
}
