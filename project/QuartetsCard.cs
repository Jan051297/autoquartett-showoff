using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class QuartetsCard
    {
        public QuartetsGameData gameData;
        public int index;
        public string name;
        public Image image;
        public object[] propertyValues;

        public QuartetsCard()
        {
            gameData = null;
            name = "[QuartetsCard:Invalid]";
            index = -1;
            image = null;
            propertyValues = null;
        }

        public bool IsValid()
        {
            return gameData != null &&
                index > -1 &&
                propertyValues != null;
        }
    }
}
