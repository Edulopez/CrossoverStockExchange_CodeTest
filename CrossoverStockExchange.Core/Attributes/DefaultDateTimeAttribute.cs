using System;
using System.ComponentModel;

namespace CrossoverStockExchange.Core.Attributes
{
    public class DefaultDateTimeAttribute : DefaultValueAttribute
    {
        public DefaultDateTimeAttribute(short yearoffset)
            : base(typeof(DateTime), DateTime.Now.ToString())
        {
        }
    }

}
