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
    public partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();
            var game = Program.controller.game;

            // Title
            Text = game.gameInfo.name;

            // Cards (Bottom)
            cardPanelLeft.SetCardTitle("");
            cardPanelRight.SetCardTitle("");

            // Card Panel: Context Menu
            QuartetCardPanelContextMenu contextMenu = new QuartetCardPanelContextMenu();
            contextMenu.options = new string[] { "Left", "Right" };
            contextMenu.eventHandler = this.OnCardContextMenu;

            // Add Cards
            foreach (QuartetsCard card in game.cards)
            {
                var panelCard = new QuartetCardPanel();
                panelCard.SetCard(card);
                panelCard.SetupContextMenu(contextMenu);

                listCards.Controls.Add(panelCard);
            }
        }

        public void OnCardPicked(QuartetsCard card)
        {
            cardPanelLeft.SetCard(card);
        }

        private void OnCardContextMenu(QuartetsCard card, string option)
        {
            if (option == "Left")
                cardPanelLeft.SetCard(card);
            else if (option == "Right")
                cardPanelRight.SetCard(card);
        }
    }
}
