using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// class provides additional formatting options for customer
    /// </summary>
    public class CustomerFormat : IFormatProvider, ICustomFormatter
    {
        private readonly IFormatProvider parentProvider;

        public CustomerFormat() : this(CultureInfo.CurrentCulture) { }
        public CustomerFormat(IFormatProvider parent)
        {
            parentProvider = parent;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) return this;
            return parentProvider.GetFormat(formatType);
        }

        /// <summary>
        /// represents customer in corresponding format and culture
        /// </summary>
        /// <param name="format">string format</param>
        /// <param name="arg">customer to be formatted</param>
        /// <param name="formatProvider">format provider</param>
        /// <exception cref="FormatException">throws when string format is invalid</exception>
        /// <exception cref="ArgumentException">throws when arg isn't customer</exception>
        /// <returns>string representation</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!(arg is Customer)) throw new ArgumentException($"{nameof(arg)} isn't a customer");
            if (ReferenceEquals(formatProvider, null))
                formatProvider = parentProvider;

            Customer customer = (Customer)arg;

            switch (format.ToUpperInvariant())
            {
                case "C":
                    return $"{customer.Revenue.ToString("C2", formatProvider)}";
                case "NP":
                    return $"Name: {customer.Name}\nPhone: {customer.ContactPhone}";
                default:
                    return customer.ToString(format, formatProvider);
            }
        }
    }
}
