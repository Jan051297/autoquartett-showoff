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

            // Discover Games
            QuartetsGameLoader gameLoader = Program.controller.gameLoader;
            gameLoader.DiscoverGames();
            games = gameLoader.GetDiscoveredGames();

            // Add discovered Games to List
            foreach(QuartetsGameInfo game in games)
                listGames.Items.Add(game.name);
        }

        private void OnSelectGame(object sender, EventArgs e)
        {
            if (listGames.SelectedIndex < 0)
                return;

            QuartetsGameInfo game = games[listGames.SelectedIndex];

            // Invalid
            if (game.amountCards <= 0)
            {
                labelGameInfo.Text = "Unable to parse JSON!\nCould not load Quartet!";
                return;
            }

            // Info
            labelGameInfo.Text = "Source: " + game.source + "\n";
            labelGameInfo.Text += "Cards: " + game.amountCards;
        }

        private void OnButtonLoadGame(object sender, EventArgs e)
        {
            if (listGames.SelectedIndex < 0)
                return;

            QuartetsGameInfo game = games[listGames.SelectedIndex];
            try
            {
                Program.controller.LoadGame(game.filename);
                this.Close();
            } catch(Exception err) {
                MessageBox.Show(err.Message,
                    "Failed to Load!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
