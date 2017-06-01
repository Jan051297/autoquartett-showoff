using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Drawing;

namespace project
{
    public struct QuartetsGameInfo
    {
        public string filename;
        public string name;
        public string source;
        public int amountCards;
    }

    public class QuartetsGameData
    {
        public QuartetsGameInfo info;
        public QuartetsProperties.IProperty[] properties = null;
        public QuartetsCard[] cards = null;
    }
}
