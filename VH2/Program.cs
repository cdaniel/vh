using System;
using System.Collections.Generic;
using System.Linq;
using VH.Engine.Display;
using VH.Engine.Levels;
using VH.Game;
using VH.Engine.Game;


namespace VH2 {

    class Program {

        static void Main(string[] args) {
            GameController.Instance = new VhGameController();
            GameController.Instance.Play(
                   args[0]
                );

            /*if (args.Length > 0) {
                GameController.Instance.Play(args[0]);
            } else {
                GameController.Instance.Play();
            }*/
        }
    }
}
