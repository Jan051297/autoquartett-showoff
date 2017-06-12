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

        public QuartetCardPropertyEditor(QuartetsCard c, int pi)
        {
            card = c;
            propertyIndex = pi;

            // GUI
            InitializeComponent();

            // Setup Labels
            var property = card.gameData.properties[pi];

            labelPropertyName.Text = property.GetName();
            labelPropertyInfo.Text = property.GetInfoText();

            textBoxValue.Text = card.propertyValues[propertyIndex].ToString();

            // Center
            CenterToScreen();
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            var property = card.gameData.properties[propertyIndex];
            var value = property.ParseValueType(textBoxValue.Text);

            if(value == null)
            {
                labelPropertyInfo.Text = "Dum dum give me right type";
                return;
            }

            Close();
        }
    }
}
