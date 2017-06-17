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
    public class QuartetsGameInfo
    {
        public string name;
        public string source;
        public int amountCards;

        public string imagePath;
        public string imageFileExtension = "png";

        // Not in JSON
        public string path;
        public string filename;

        // Name Property
        // since QuartetsGameData does not have a NameProperty, we have
        // to store the original index of the name property manually
        // The name of a Card is stored in QuartetsCard
        public int namePropertyIndex = -1;
    }

    public class QuartetsGameData
    {
        public QuartetsGameInfo info;
        public QuartetsProperties.IProperty[] properties = null;
        public QuartetsCard[] cards = null;
    }
}
