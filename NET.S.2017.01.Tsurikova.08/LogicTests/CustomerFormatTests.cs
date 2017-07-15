using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Logic;
using NUnit.Framework;

namespace LogicTests
{
    [TestFixture]
    public class CustomerFormatTests
    {
        [TestCase("Severus Snape", "+1 (425) 555-0100", 250000, "{0:N}",
            ExpectedResult = "Severus Snape")]
        [TestCase("Severus Snape", "+1 (425) 555-0100", 250000, "{0:C}",
            ExpectedResult = "$250,000.00")]
        [TestCase("Severus Snape", "+1 (425) 555-0100", 250000, "{0:NP}",
            ExpectedResult = "Name: Severus Snape\nPhone: +1 (425) 555-0100")]
        public string Format_Customer_Format_Result(string name, string phone, decimal revenue, string format)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-Us");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-Us");
            return string.Format(new CustomerFormat(), format,
                new Customer(name, phone, revenue));
        }

        [Test]
        public void Format_NotCustomer_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => string.Format(new CustomerFormat(), "{0:C}", 4));
        }
    }
}
