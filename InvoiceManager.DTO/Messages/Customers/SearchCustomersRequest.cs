﻿using InvoiceManager.DTO.BaseRequest;

namespace InvoiceManager.DTO.Messages.Customers
{
    public class SearchCustomersRequest : SearchRecordsRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
    }
}
