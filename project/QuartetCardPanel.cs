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

        // UpdateCardLabelFontSize changes the Font Size of labelCardName to fit
        // the actual text. This makes sure the Card name actually fits into the
        // label
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

        // SetCardTitle changes the Title and fits the Label
        public void SetCardTitle(string str)
        {
            labelCardName.Text = str;
            UpdateCardLabelFontSize();
        }

        // SetCard resets everything and shows the given Card
        public void SetCard(QuartetsCard c)
        {
            card = c;
            SetCardTitle(c.name);
            cardImage.Image = c.image;

            // Clear Table
            tableProperties.Controls.Clear();
            tableProperties.RowCount = 0;

            // Clear Row Styles, keep only original one
            {
                var originalStyle = tableProperties.RowStyles[0];
                tableProperties.RowStyles.Clear();
                tableProperties.RowStyles.Add(originalStyle);
            }

            // Properties
            for (int i = 0; i < card.propertyValues.Length; i++)
            {
                var property = card.gameData.properties[i];

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

        // AddProperty adds a Card property to the Table
        private void AddProperty(string a, object val)
        {
            // Steal Row Style from previous Row
            RowStyle previousRow = tableProperties.RowStyles[tableProperties.RowCount];
            tableProperties.RowStyles.Add(new RowStyle(previousRow.SizeType, previousRow.Height));

            // Add Labels to Row
            tableProperties.Controls.Add(new Label() { Text = a, TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Fill }, 0, tableProperties.RowCount);
            tableProperties.Controls.Add(new Label() { Text = val.ToString(), TextAlign = ContentAlignment.MiddleRight }, 1, tableProperties.RowCount);

            // Increment Row Count
            tableProperties.RowCount++;
        }

        // UpdatePropertyColor changes the Label color (both type + value) of a property
        public void UpdatePropertyColor(int propertyIndex, Color color)
        {
            if (propertyIndex < 0 || propertyIndex > card.propertyValues.Length)
                return;

            // Controls
            var labelPropertyName = tableProperties.GetControlFromPosition(0, propertyIndex);
            var labelPropertyValue = tableProperties.GetControlFromPosition(1, propertyIndex);

            // This should not happen
            if (labelPropertyName == null || labelPropertyValue == null)
                return;

            // Update Color
            labelPropertyName.ForeColor = color;
            labelPropertyValue.ForeColor = color;
        }

        // Similar to UpdatePropertyColor, Color is determined based on PropertyResult
        public void UpdatePropertyColor(int propertyIndex, QuartetsProperties.PropertyResult result)
        {
            Color color = Color.Black;

            // Color fitting PropertyResult
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

            // Update
            UpdatePropertyColor(propertyIndex, color);
        }

        // SetupContextMenu creates a Context Menu for the Panel
        public void SetupContextMenu(QuartetCardPanelContextMenu settings)
        {
            contextMenuSettings = settings;

            // Menu Items
            MenuItem[] items = new MenuItem[settings.options.Length];
            for (int index = 0; index < items.Length; index++)
            {
                items[index] = new MenuItem(settings.options[index]);
                items[index].Click += this.OnContextMenuItemClick;
            }
            
            // Setup Context Menu
            ContextMenu = new ContextMenu(items);
        }

        private void OnContextMenuItemClick(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            contextMenuSettings.eventHandler(card, menuItem.Text);
        }
    }
}
