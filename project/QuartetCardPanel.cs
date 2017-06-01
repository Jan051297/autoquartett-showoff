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
    public struct QuartetCardPanelContextMenu
    {
        public string[] options;
        public Action<QuartetsCard, string> eventHandler;
    }

    public partial class QuartetCardPanel : UserControl
    {
        private QuartetsCard card;
        private QuartetCardPanelContextMenu contextMenuSettings;

        public QuartetCardPanel()
        {
            InitializeComponent();
        }

        private bool UpdateCardLabelFontSize()
        {
            Font currentFont = labelCardName.Font;
            if(labelCardName.Width < TextRenderer.MeasureText(labelCardName.Text, currentFont).Width)
            {
                labelCardName.Font = new Font(currentFont.FontFamily, currentFont.Size - 0.5f, currentFont.Style);
                return UpdateCardLabelFontSize();
            }

            return true;
        }

        public void SetCardTitle(string str)
        {
            labelCardName.Text = str;
            UpdateCardLabelFontSize();
        }

        public void SetCard(QuartetsCard c)
        {
            card = c;
            SetCardTitle(c.name);
            cardImage.Image = c.image;

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

        public QuartetsCard GetCard()
        {
            return card;
        }

        private int rowcount = 0;
        private void AddProperty(string a, object val)
        {
            // Steal Row Style from previous Row
            if (tableProperties.RowCount > 99999)
            {
                RowStyle previousRow = tableProperties.RowStyles[tableProperties.RowCount - 1];
                tableProperties.RowStyles.Add(new RowStyle(previousRow.SizeType, previousRow.Height));
                tableProperties.RowCount++;
            }

            // Add Labels to Row
            
            tableProperties.Controls.Add(new Label() { Text = a, TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Fill }, 0, rowcount);
            tableProperties.Controls.Add(new Label() { Text = val.ToString(), TextAlign = ContentAlignment.MiddleRight }, 1, rowcount);

            rowcount++;
        }

        public void UpdatePropertyColor(int propertyIndex, Color color)
        {
            if (propertyIndex < 0 || propertyIndex > card.propertyValues.Length)
                return;

            var labelPropertyName = tableProperties.GetControlFromPosition(0, propertyIndex);
            var labelPropertyValue = tableProperties.GetControlFromPosition(1, propertyIndex);

            labelPropertyName.ForeColor = color;
            labelPropertyValue.ForeColor = color;
        }

        public void UpdatePropertyColor(int propertyIndex, QuartetsProperties.PropertyResult result)
        {
            Color color = Color.Black;

            switch(result)
            {
                case QuartetsProperties.PropertyResult.Equal:
                    color = Color.Orange;
                    break;
                case QuartetsProperties.PropertyResult.Higher:
                    color = Color.Green;
                    break;
                case QuartetsProperties.PropertyResult.Lower:
                    color = Color.Red;
                    break;
            }

            UpdatePropertyColor(propertyIndex, color);
        }

        public void SetupContextMenu(QuartetCardPanelContextMenu settings)
        {
            contextMenuSettings = settings;

            // Menu Items
            MenuItem[] items = new MenuItem[settings.options.Length];
            for (int index = 0; index < items.Length; index++)
            {
                items[index] = new MenuItem(settings.options[index]);
                items[index].Click += QuartetCardPanel_Click;
            }
            
            // Setup Context Menu
            ContextMenu = new ContextMenu(items);
        }

        private void QuartetCardPanel_Click(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            contextMenuSettings.eventHandler(card, menuItem.Text);
        }
    }
}
