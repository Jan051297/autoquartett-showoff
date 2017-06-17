using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.QuartetsProperties
{
    public class NameProperty : StringProperty
    {
        public NameProperty() : base("Card Name")
        {
        }

        public override string GetInfoText()
        {
            return "Card Name (String/Text)";
        }
    }
}
