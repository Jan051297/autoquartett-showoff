using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Controller
    {
        public MainWindow mainWindow = null;
        public QuartetsGame game;

        public Controller()
        {
            game = new QuartetsGame();
        }

        public void Run()
        {
            // Show Main Window
            mainWindow = new MainWindow();
            System.Windows.Forms.Application.Run(mainWindow);

            // Show Game Window
            System.Windows.Forms.Application.Run(new GameWindow());
        }

        public bool LoadGame(string path)
        {
            return game.Load(path);
        }
    }
}
