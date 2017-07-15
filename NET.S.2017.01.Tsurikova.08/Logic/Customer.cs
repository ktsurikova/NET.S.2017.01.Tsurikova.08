using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// class for working with customer info
    /// </summary>
    public class Customer : IFormattable
    {
        public string Name { get; }
        public string ContactPhone { get; }
        public decimal Revenue { get; }

        public Customer(string name, string phone, decimal revenue)
        {
            Name = name;
            ContactPhone = phone;
            Revenue = revenue;
        }

        /// <summary>
        /// represents customer in a general format and current culture
        /// </summary>
        /// <returns>string repersentation</returns>
        public override string ToString() => ToString("G", CultureInfo.CurrentCulture);

        /// <summary>
        /// represents customer in corresponding format and current culture
        /// </summary>
        /// <exception cref="FormatException">throws when string format is invalid</exception>
        /// <param name="format">string format</param>
        /// <returns>string representation</returns>
        public string ToString(string format) => ToString(format, CultureInfo.CurrentCulture);

        /// <summary>
        /// represents customer in corresponding format and culture
        /// </summary>
        /// <exception cref="FormatException">throws when string format is invalid</exception>
        /// <param name="format">string format</param>
        /// <param name="formatProvider">format provider</param>
        /// <returns>string representation</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
                format = "G";
            if (ReferenceEquals(formatProvider, null))
                formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "G":
                case "A":
                    return $"{Name}, {Revenue.ToString("N2", formatProvider)}, {ContactPhone}";
                case "P":
                    return $"{ContactPhone}";
                case "N":
                    return $"{Name}";
                case "R":
                    return $"{Revenue.ToString("N2", formatProvider)}";
                case "NR":
                    return $"{Name}, {Revenue.ToString("N2", formatProvider)}";
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }
        }
    }
}
