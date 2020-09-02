using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManager.Infrastructure.Extensions
{
    public static class IntegerExtensions
    {
        public static bool IsEqualTo(this int intValue, int valueToCompare)
        {
            return intValue == valueToCompare;
        }

        public static bool IsNotEqualTo(this int intValue, int valueToCompare)
        {
            return !IsEqualTo(intValue, valueToCompare);
        }

        public static bool IsGreaterThan(this int intValue, int valueToCompare)
        {
            return intValue > valueToCompare;
        }

        public static bool IsLessThan(this int intValue, int valueToCompare)
        {
            return intValue < valueToCompare;
        }

        public static bool IsZero(this int value)
        {
            return value == 0;
        }

        public static bool IsNotZero(this int value)
        {
            return !IsZero(value);
        }

        public static bool IsGreaterThanZero(this int value)
        {
            return IsGreaterThan(value, 0);
        }

        public static T ConvertToEnum<T>(this int value) where T : struct
        {
            return (T)Enum.ToObject(typeof(T), value);
        }        
    }
}
