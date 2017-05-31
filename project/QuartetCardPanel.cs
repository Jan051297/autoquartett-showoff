using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class QuartetCardPanel : UserControl
    {
        private QuartetsCard card;

        public QuartetCardPanel()
        {
            InitializeComponent();
        }

        public void SetCard(QuartetsCard c)
        {
            card = c;
            labelCardName.Text = c.name;

            // Clear Table
            tableProperties.Controls.Clear();
            tableProperties.RowCount = 1;

            // Properties
            for (int i = 0; i < card.propertyValues.Length; i++)
            {
                var property = card.game.properties[i];

                // Hide Name Property
                if (property.GetType() == typeof(QuartetsProperties.NameProperty))
                    continue;

                // Add
                AddProperty(property.GetName(), card.propertyValues[i]);
            }
        }

        private void AddProperty(string a, object val)
        {
            // Steal Row Style from previous Row
            RowStyle previousRow = tableProperties.RowStyles[tableProperties.RowCount - 1];
            tableProperties.RowStyles.Add(new RowStyle(previousRow.SizeType, previousRow.Height));
            tableProperties.RowCount++;

            // Add Labels to Row
            tableProperties.Controls.Add(new Label() { Text = a });
            tableProperties.Controls.Add(new Label() { Text = val.ToString() });
        }
    }
}
