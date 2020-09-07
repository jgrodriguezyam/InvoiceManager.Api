using AutoMapper;
using InvoiceManager.DataAccess.Repositories;
using InvoiceManager.DTO.BaseResponse;
using InvoiceManager.DTO.Messages.Invoices;
using InvoiceManager.DTO.Messages.Items;
using InvoiceManager.Infrastructure.Extensions;
using InvoiceManager.Model;
using InvoiceManager.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceManager.Services.Implements
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository invoiceRepository, IItemRepository itemRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _itemRepository = itemRepository;
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
            
            var items = _itemRepository.GetBy(p => p.InvoiceId == id);
            RemoveItems(items, request.Items);

            _mapper.Map(invoiceModel, invoice);
            _invoiceRepository.Update(invoice);
            return new SuccessResponse(true);
        }

        private void RemoveItems(IEnumerable<Item> items, IEnumerable<ItemRequest> itemsRequest)
        {
            items.ToList().ForEach(itemToValidate => {
                var itemRequest = itemsRequest.FirstOrDefault(itemReq => itemReq.Id == itemToValidate.Id);                
                if (itemRequest.IsNull())
                {
                    var itemToRemove = items.FirstOrDefault(item => item.Id == itemToValidate.Id);
                    _itemRepository.Remove(itemToRemove);
                }               
            });
        }         

        public InvoiceResponse Get(int id)
        {
            var invoice = _invoiceRepository.Search(p => p.IsActive && p.Id == id).FirstOrDefault();
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
            var invoices = _invoiceRepository.Search(p => p.IsActive);
            var invoicesResponse = _mapper.Map<List<InvoiceResponse>>(invoices);
            return invoicesResponse;
        }
    }
}
