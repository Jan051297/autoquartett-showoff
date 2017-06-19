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
        private QuartetCardPanelContextMenu cardContextMenu;

        public GameWindow()
        {
            InitializeComponent();
            var game = Program.controller.gameData;

            // Title
            Text = game.info.name;

            // Cards (Bottom)
            cardPanelLeft.SetCardTitle("");
            cardPanelRight.SetCardTitle("");

            // Card Panel: Context Menu
            cardContextMenu.options = new string[] { "Left", "Right", "Edit" };
            cardContextMenu.eventHandler = this.OnCardContextMenu;

            // Add Cards
            foreach (QuartetsCard card in game.cards)
                AddCard(card);

            AddDummyCard();

            // Center
            CenterToScreen();
        }

        private void AddCard(QuartetsCard card)
        {
            var panelCard = new QuartetCardPanel();
            panelCard.SetCard(card);
            panelCard.SetupContextMenu(cardContextMenu);

            listCards.Controls.Add(panelCard);
        }

        private void AddDummyCard()
        {
            QuartetCardPanelContextMenu dummyContextMenu = new QuartetCardPanelContextMenu();
            dummyContextMenu.options = new string[] { "Create" };
            dummyContextMenu.eventHandler = this.OnCardContextMenu;

            var panelDummyCard = new QuartetCardPanel();
            panelDummyCard.SetCardTitle("Empty Card");
            panelDummyCard.SetupContextMenu(dummyContextMenu);
            listCards.Controls.Add(panelDummyCard);
        }

        public void OnCardPicked(QuartetsCard card)
        {
            cardPanelLeft.SetCard(card);
        }

        public void CompareCards()
        {
            // Check if cards have been selected
            var cardLeft = cardPanelLeft.GetCard();
            var cardRight = cardPanelRight.GetCard();

            if (cardLeft == null || cardRight == null)
                return;

            // Compare properties
            var props = Program.controller.gameData.properties;

            for(int i = 0; i < props.Length; i++)
            {
                var prop = props[i];
                var result = prop.Compare(cardLeft.propertyValues[i], cardRight.propertyValues[i]);
                var winningResult = prop.GetWinningPropertyResult();

                if (winningResult == QuartetsProperties.PropertyResult.Disabled ||
                    winningResult == QuartetsProperties.PropertyResult.Invalid)
                    continue;

                QuartetCardPanel.PropertyVisualResult visualResult = QuartetCardPanel.PropertyVisualResult.None;

                if (result == QuartetsProperties.PropertyResult.Equal)
                    visualResult = QuartetCardPanel.PropertyVisualResult.Draw;
                else
                    visualResult = result == winningResult ?
                        QuartetCardPanel.PropertyVisualResult.Win :
                        QuartetCardPanel.PropertyVisualResult.Lose;

                cardPanelLeft.UpdatePropertyColor(i, visualResult, true);
                cardPanelRight.UpdatePropertyColor(i, visualResult, false);
            }
        }

        private void OnCardContextMenu(QuartetCardPanel cardPanel, string option)
        {
            var card = cardPanel.GetCard();

            if(option == "Edit")
            {
                var editWindow = new CardEditorWindow(card);
                editWindow.ShowDialog();

                // Store changes (if any)
                if (editWindow.changesMade)
                {
                    // Update Panel
                    cardPanel.SetCard(card);

                    // Store Game Data
                    var gameLoader = Program.controller.gameLoader;
                    gameLoader.Save(Program.controller.gameData);
                }

                return;
            }

            if(option == "Create")
            {
                var gameData = Program.controller.gameData;

                // Card
                QuartetsCard newCard = new QuartetsCard();
                newCard.propertyValues = new object[gameData.properties.Length];
                newCard.gameData = gameData;

                // Card Name
                var editWindowCardName = new QuartetCardPropertyEditor(newCard, -1);
                editWindowCardName.ShowDialog();

                if (!editWindowCardName.changesMade)
                    return; // cancel

                // Editor Window
                var editWindow = new CardEditorWindow(newCard);
                editWindow.ShowDialog();

                // Check if card is valid
                foreach(object val in newCard.propertyValues)
                {
                    if (val == null)
                        return;
                }

                // Store Card in GameData
                var tempCards = gameData.cards;
                gameData.cards = new QuartetsCard[tempCards.Length + 1];

                for (int i = 0; i < tempCards.Length; i++)
                    gameData.cards[i] = tempCards[i];

                gameData.cards[tempCards.Length] = newCard;
                gameData.info.amountCards++;

                // Store Quartets Game
                var gameLoader = Program.controller.gameLoader;
                gameLoader.Save(Program.controller.gameData);

                // Display Card on Panel
                cardPanel.SetCard(newCard);
                cardPanel.SetupContextMenu(cardContextMenu);

                // Add another Dummy card
                AddDummyCard();

                return;
            }

            if (option == "Left")
                cardPanelLeft.SetCard(card);
            else if (option == "Right")
                cardPanelRight.SetCard(card);

            CompareCards();
        }
    }
}
