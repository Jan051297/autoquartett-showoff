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
    public partial class CardEditorWindow : Form
    {
        private QuartetsCard card;
        public bool changesMade = false;

        public CardEditorWindow(QuartetsCard _card)
        {
            InitializeComponent();

            // Card
            card = _card;

            // Card Panel
            cardPanel.SetCard(card);
            cardPanel.SetPropertyDblClickCallback(this.OnPropertyClick);

            // Center
            CenterToScreen();
        }

        private void OnPropertyClick(QuartetsCard _, int propertyIndex)
        {
            // Editor
            var editorWindow = new QuartetCardPropertyEditor(card, propertyIndex);
            editorWindow.ShowDialog();

            // Apply Changes (if any)
            if (editorWindow.changesMade)
            {
                changesMade = true;

                // Update Card
                cardPanel.SetCard(card);
            }
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            // Check Card
            foreach(object obj in card.propertyValues)
            {
                if(obj == null)
                {
                    var result = MessageBox.Show("Not all properties have a value! If you press OK, any changes will be discarded.", "Card Editor", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.Cancel || result == DialogResult.Abort)
                        e.Cancel = true;

                    break;
                }
            }
        }
    }
}
