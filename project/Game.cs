using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Game
    {
        MainWindow window = null;

        public void Run()
        {
            window = new MainWindow();
            System.Windows.Forms.Application.Run(window);
        }
    }
}
