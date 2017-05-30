using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.QuartetsProperties
{
    class IntegerProperty : IProperty
    {
        private string propertyName;
        private PropertyResult winningResult;

        public IntegerProperty(PropertyResult winner, string name)
        {
            winningResult = winner;
            propertyName = name;
        }

        public override string GetName()
        {
            return propertyName;
        }

        public override PropertyResult Compare(object a, object b)
        {
            if (a.GetType() != typeof(Int32) || b.GetType() != typeof(Int32))
                return PropertyResult.Invalid;

            int A = (int)a;
            int B = (int)b;

            // Compare Integer
            if (A == B)
                return PropertyResult.Equal;            
            if (A > B)
                return PropertyResult.Higher;            
            return PropertyResult.Lower;
        }

        public override PropertyResult GetWinningPropertyResult()
        {
            return winningResult;
        }
    }
}
