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
            var editorWindow = new QuartetCardPropertyEditor(card, propertyIndex);
            editorWindow.ShowDialog();
        }
    }
}
