using InvoiceManager.Infrastructure.Extensions;
using System.Collections.Generic;

namespace InvoiceManager.DTO.BaseResponse
{
    public class EnumeratorResponse
    {
        public EnumeratorResponse()
        {
            Enumerator = new List<Enumerator>();
        }

        public List<Enumerator> Enumerator { get; set; }
    }
}
