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
    public class CustomerTests
    {
        [TestCase("Severus Snape", "+1 (425) 555-0100", 250000,
            ExpectedResult = "Severus Snape, 250,000.00, +1 (425) 555-0100")]
        public string ToString__Result(string name, string phone, decimal revenue)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-Us");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-Us");
            return new Customer(name, phone, revenue).ToString();
        }

        [TestCase("Severus Snape", "+1 (425) 555-0100", 250000, "A",
            ExpectedResult = "Severus Snape, 250,000.00, +1 (425) 555-0100")]
        [TestCase("Severus Snape", "+1 (425) 555-0100", 250000, "N",
            ExpectedResult = "Severus Snape")]
        [TestCase("Severus Snape", "+1 (425) 555-0100", 250000, "P",
            ExpectedResult = "+1 (425) 555-0100")]
        [TestCase("Severus Snape", "+1 (425) 555-0100", 250000, "R",
            ExpectedResult = "250,000.00")]
        [TestCase("Severus Snape", "+1 (425) 555-0100", 250000, "NR",
            ExpectedResult = "Severus Snape, 250,000.00")]
        public string ToString_Format_Result(string name, string phone, decimal revenue, string format)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-Us");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-Us");
            return new Customer(name, phone, revenue).ToString(format);
        }

        [Test]
        public void ToString_InvalidFormat_FormatException()
        {
            Assert.Throws<FormatException>(() => new Customer("a", "1", 1).ToString("H"));
        }

    }


}
