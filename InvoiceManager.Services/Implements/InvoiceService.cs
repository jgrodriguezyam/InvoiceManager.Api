using AutoMapper;
using InvoiceManager.DataAccess.Repositories;
using InvoiceManager.DTO.BaseResponse;
using InvoiceManager.DTO.Messages.Invoices;
using InvoiceManager.Model;
using InvoiceManager.Services.Interfaces;
using System.Collections.Generic;

namespace InvoiceManager.Services.Implements
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public CreateResponse Create(InvoiceRequest request)
        {
            var invoice = _mapper.Map<Invoice>(request);
            _invoiceRepository.Create(invoice);
            return new CreateResponse(invoice.Id);
        }

        public SuccessResponse Update(int id, InvoiceRequest request)
        {
            var invoiceModel = _mapper.Map<Invoice>(request);
            var invoice = _invoiceRepository.GetBy(id);
            _mapper.Map(invoiceModel, invoice);
            _invoiceRepository.Update(invoice);
            return new SuccessResponse(true);
        }

        public InvoiceResponse Get(int id)
        {
            var invoice = _invoiceRepository.GetBy(id);
            var invoiceResponse = _mapper.Map<InvoiceResponse>(invoice);
            return invoiceResponse;
        }

        public SuccessResponse Delete(int id)
        {
            var invoice = _invoiceRepository.GetBy(id);
            _invoiceRepository.Remove(invoice);
            return new SuccessResponse(true);
        }

        public List<InvoiceResponse> Search(SearchInvoicesRequest request)
        {
            var invoices = _invoiceRepository.GetBy(p => p.IsActive);
            var invoicesResponse = _mapper.Map<List<InvoiceResponse>>(invoices);
            return invoicesResponse;
        }
    }
}
