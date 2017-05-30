using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.QuartetsProperties
{
    enum PropertyResult
    {
        Invalid,
        Disabled,

        Lower,
        Equal,
        Higher
    }

    abstract class IProperty
    {
        public abstract string GetName();

        public abstract PropertyResult Compare(object a, object b);
        public abstract PropertyResult GetWinningPropertyResult();
    }

}
