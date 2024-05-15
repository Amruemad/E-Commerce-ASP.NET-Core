using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.ExtensionMethods
{
    public static class DateTimeExtensions
    {
        public static DateOnly? ToNullableDateOnly(this DateTime? input)
        {
            if (input == null)
                return null;

            return DateOnly.FromDateTime(input.Value);
        }
    }
}
