using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.QuartetsProperties
{
    public class StringProperty : IProperty
    {
        string propertyName;

        public StringProperty(string name)
        {
            propertyName = name;
        }

        public override string GetName()
        {
            return propertyName;
        }

        public override object CheckValueType(object obj)
        {
            try
            {
                return Convert.ToString(obj);
            }
            catch
            {
                return null;
            }
        }

        public override object ParseValueType(string str)
        {
            if (str == null || str.Length == 0)
                return null;

            return str;
        }

        public override PropertyResult Compare(object a, object b)
        {
            return PropertyResult.Disabled;
        }

        public override PropertyResult GetWinningPropertyResult()
        {
            return PropertyResult.Disabled;
        }
    }
}
