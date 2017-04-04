using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Task1
{
    public class CustomerFormatter : IFormatProvider, ICustomFormatter
    {
        IFormatProvider _parent;

        public CustomerFormatter() : this(CultureInfo.CurrentCulture) { }
        public CustomerFormatter(IFormatProvider parent)
        {
            _parent = parent;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) return this;
            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (ReferenceEquals(arg, null)) throw new ArgumentException();
            if (arg == null || !(arg is Customer)) return string.Format(_parent, "{0:" + format + "}", arg);
            Customer cust = (Customer)arg;
            switch (format.ToUpperInvariant())
            {
                case "NCP":
                    return String.Format("Customer record: {0}, {1}", cust.Name, cust.ContactPhone);
                case "CPN":
                    return String.Format("Customer record: {0}, {1}", cust.ContactPhone, cust.Name);
                default:
                    return string.Format(_parent, "{0:" + format + "}", arg);
            }
        }
    }
}
