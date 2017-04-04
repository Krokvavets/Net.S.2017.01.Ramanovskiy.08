using System;
using System.Globalization;

namespace Task1
{
    public class Customer : IFormattable
    {
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }

        public Customer(string name, string phone, decimal revenue)
        {
            Name = name;
            ContactPhone = phone;
            Revenue = revenue;
        }
        public override string ToString() => this.ToString("G", CultureInfo.CurrentCulture);
        public string ToString(string format) => this.ToString(format, CultureInfo.CurrentCulture);
        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format)) format = "G";
            if (provider == null) provider = CultureInfo.CurrentCulture;
            CultureInfo cl = (CultureInfo)provider;
            switch (format.ToUpperInvariant())
            {
                case "G":
                case "NRCP":
                    return String.Format("Customer record: {0}, {1}, {2}", Name, Revenue.ToString("C", cl), ContactPhone);
                case "CP":
                    return String.Format("Customer record: {0}", ContactPhone);
                case "NR":
                    return String.Format("Customer record: {0}, {1}", Name, Revenue.ToString("C", cl));
                case "N":
                    return String.Format("Customer record: {0}", Name);
                case "R":
                    return String.Format("Customer record: {0}C", Revenue.ToString("C", cl));
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }


        }
    }
}
