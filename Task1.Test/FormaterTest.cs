using System;
using NUnit.Framework;
using Task1;
using System.Globalization;

namespace Task1.Test
{
    [TestFixture]
    public class FormaterTest
    {
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 1000000, "G", "Customer record: Jeffrey Richter, $1,000,000.00, +1 (425) 555-0100")]
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 1000000, "NRCP", "Customer record: Jeffrey Richter, $1,000,000.00, +1 (425) 555-0100")]
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 1000000, "N", "Customer record: Jeffrey Richter")]
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 1000000, "CP", "Customer record: +1 (425) 555-0100")]
        [Test]
        public void ToString_PositiveTest(string name, string phone, decimal revenue, string format, string result)
        {
            Customer cust = new Customer(name, phone, revenue);
            
            Assert.AreEqual(result, cust.ToString(format, new CultureInfo("en-US")));
        }

        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 1000000, "NCP", "Customer record: Jeffrey Richter, +1 (425) 555-0100")]
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 1000000, "CPN", "Customer record: +1 (425) 555-0100, Jeffrey Richter")]
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 1000000, "N", "Customer record: Jeffrey Richter")]
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 1000000, "CP", "Customer record: +1 (425) 555-0100")]
        [Test]
        public void CustomerFormatter_PositiveTest(string name, string phone, decimal revenue, string format, string result)
        {
            Customer cust = new Customer(name, phone, revenue);
            IFormatProvider fp = new CustomerFormatter();
            Assert.AreEqual(result, string.Format(fp, "{0:" + format + "}", cust));
        }

        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 1000000, "NqCP", "Customer record: Jeffrey Richter, +1 (425) 555-0100")]
        [TestCase("Jeffrey Richter", "+1 (425) 555-0100", 1000000, "CPttN", "Customer record: +1 (425) 555-0100, Jeffrey Richter")]
        [Test]
        public void CustomerFormatter_FormatException(string name, string phone, decimal revenue, string format, string result)
        {
            Customer cust = new Customer(name, phone, revenue);
            IFormatProvider fp = new CustomerFormatter();
            Assert.Throws<FormatException>(() => string.Format(fp, "{0:" + format + "}", cust));
        }

    }
}