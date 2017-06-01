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

            // Show Game Window
            System.Windows.Forms.Application.Run(new GameWindow());
        }

        public void LoadGame(string path)
        {
            gameData = gameLoader.Load(path);
        }
    }
}
