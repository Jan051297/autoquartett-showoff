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
    public partial class MainWindow : Form
    {
        private QuartetsGameInfo[] games = null;

        public MainWindow()
        {
            InitializeComponent();

            // List available Games
            games = QuartetsGame.DiscoverGames();
            foreach(QuartetsGameInfo game in games)
            {
                listGames.Items.Add(game.name);
            }
        }

        private void OnSelectGame(object sender, EventArgs e)
        {
            QuartetsGameInfo game = games[listGames.SelectedIndex];
            buttonLoad.Enabled = game.amountCards > 0;

            // Invalid
            if (!buttonLoad.Enabled)
            {
                labelGameInfo.Text = "Unable to parse JSON!\nCould not load Quartet!";
                return;
            }

            // Info
            labelGameInfo.Text = "Source: " + game.source + "\n";
            labelGameInfo.Text += "Cards: " + game.amountCards;
        }
    }
}
