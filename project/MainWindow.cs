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
        public MainWindow()
        {
            InitializeComponent();

            var panel = quartetCardPanel1;

            QuartetsGame game = new QuartetsGame();
            if (!game.Load("../../../data/codequartets.json"))
                return;

            var card = game.cards[0];
            panel.SetCard(card);
        }
    }
}
