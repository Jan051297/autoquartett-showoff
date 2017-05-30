using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    static class Program
    {
        public static Game game = null;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            QuartetsGame game = new QuartetsGame();
            if (!game.Load("../../../data/bahnhof.json"))
                return;




            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //game = new Game();
            //game.Run();
        }
    }
}
