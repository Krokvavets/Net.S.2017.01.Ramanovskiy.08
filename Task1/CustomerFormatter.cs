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
        ///<summary>
        ///Returns an object that provides formatting services for the specified type.
        ///</summary>
        ///<param name="formatType">An object that specifies the type of format object to return.</param>
        ///<returns>An instance of the object specified by formatType, if the IFormatProvider implementation can supply that type of object; otherwise, null.</returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) return this;
            return null;
        }
        ///<summary>
        ///Converts the value of a specified object to an equivalent string representation using specified format and culture-specific formatting information.
        ///</summary>
        ///<param name="format">A format string containing formatting specifications.</param>
        ///<param name="arg">An object to format.</param>
        ///<param name="formatProvider">An object that supplies format information about the current instance.</param>
        ///<returns>The string representation of the value of arg, formatted as specified by format and formatProvider.</returns>
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
