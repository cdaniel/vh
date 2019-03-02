using System;
using System.Collections.Generic;
using System.Linq;
using VH.Engine.Display;
using VH.Engine.Levels;
using VH.Game;
using VH.Engine.Game;
using System.Windows.Forms;

namespace VH2 {

    class Program {

        static void Main(string[] args) {
            try {
                GameController.Instance = new VhGameController();
#if !DEBUG
                if (args.Length > 0) {
                    GameController.Instance.Play(args[0]);
                } else {
#endif
                GameController.Instance.Play();
#if !DEBUG
                }
#endif
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.Write(ex.StackTrace);
                Console.ReadKey();
                string filename = Application.StartupPath + "\\Data\\_error.log";
                System.IO.File.WriteAllText(filename, ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}
