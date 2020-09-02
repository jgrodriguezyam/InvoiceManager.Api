using System.Collections.Generic;
using System.Linq;

namespace InvoiceManager.Infrastructure.Extensions
{
    public static class CollectionExtensions
    {
        public static bool IsNotEmpty(this IEnumerable<object> values)
        {
            return values != null && values.Any();
        }

        public static bool IsEmpty(this IEnumerable<object> values)
        {
            return !IsNotEmpty(values);
        }
    }
}
