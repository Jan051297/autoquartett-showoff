using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.QuartetsProperties
{
    class StringProperty : IProperty
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
