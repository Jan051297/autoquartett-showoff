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
        public GameWindow gameWindow = null;

        public QuartetsGameData gameData;
        public QuartetsGameLoader gameLoader;

        public Controller()
        {
            gameLoader = new QuartetsGameLoader();
        }

        public void Run()
        {
            // Show Main Window
            mainWindow = new MainWindow();
            System.Windows.Forms.Application.Run(mainWindow);

            // Check if a game has been loaded
            // If not, close
            if (gameData == null)
                return;

            // Show Game Window
            gameWindow = new GameWindow();
            System.Windows.Forms.Application.Run(gameWindow);
        }

        public void LoadGame(string path)
        {
            gameData = gameLoader.Load(path);
        }
    }
}
