using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.QuartetsProperties
{
    public enum PropertyResult
    {
        Invalid,
        Disabled,

        Lower,
        Equal,
        Higher
    }

    public abstract class IProperty
    {
        public abstract string GetName();

        public abstract PropertyResult Compare(object a, object b);
        public abstract PropertyResult GetWinningPropertyResult();
    }

}
