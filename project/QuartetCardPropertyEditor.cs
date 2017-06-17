using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class QuartetCardPropertyEditor : Form
    {
        private QuartetsCard card;
        private int propertyIndex;
        private QuartetsProperties.IProperty property;
        public bool changesMade = false;

        public QuartetCardPropertyEditor(QuartetsCard c, int pi)
        {
            card = c;
            propertyIndex = pi;

            // GUI
            InitializeComponent();

            // Property
            if(pi == -1)
            {
                // Name Property
                property = new QuartetsProperties.NameProperty();
            }
            else
            {
                property = card.gameData.properties[pi];

                if(card.propertyValues[propertyIndex] != null)
                    textBoxValue.Text = card.propertyValues[propertyIndex].ToString();
            }

            // Setup Labels
            labelPropertyName.Text = property.GetName();
            labelPropertyInfo.Text = property.GetInfoText();

            // Center
            CenterToScreen();
        }

        private void OnSaveClick(object sender, EventArgs e)
        {            
            var value = property.ParseValueType(textBoxValue.Text);

            if(value == null)
            {
                labelPropertyInfo.Text = "Invalid Text, unable to convert!";
                return;
            }

            object currentValue = propertyIndex == -1 ?
                card.name :
                card.propertyValues[propertyIndex];

            if (value != currentValue)
            {
                changesMade = true;

                if (propertyIndex == -1)
                    card.name = (string)value;
                else
                    card.propertyValues[propertyIndex] = value;
            }

            Close();
        }
    }
}
