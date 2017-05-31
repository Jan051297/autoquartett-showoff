using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class Controller
    {
        public MainWindow window = null;

        public void Run()
        {
            // Show Main Window
            window = new MainWindow();
            System.Windows.Forms.Application.Run(window);
        }
    }
}
