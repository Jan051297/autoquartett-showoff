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

            // Store Changes (if any)
            if (editorWindow.changesMade)
            {
                changesMade = true;

                // Update Card
                cardPanel.SetCard(card);

                // Store Game Data
                var gameLoader = Program.controller.gameLoader;
                gameLoader.Save(Program.controller.gameData);
            }
        }
    }
}
