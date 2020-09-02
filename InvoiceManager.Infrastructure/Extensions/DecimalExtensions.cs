using System;

namespace InvoiceManager.Infrastructure.Extensions
{
    public static class DecimalExtensions
    {
        public static bool IsZero(this decimal value)
        {
            return value == 0;
        }

        public static bool IsNotZero(this decimal value)
        {
            return !IsZero(value);
        }

        public static decimal RoundDecimal(this decimal value)
        {
            return Math.Round(value, 2);
        }
    }
}
