using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.Game;
using VH.Engine.Levels;
using VH.Engine.World.Beings;

namespace VH.Game.World.Beings.Actions {

    public class SearchAction: VhAction {

        public SearchAction(Being being): base(being) { }

        public override bool Perform() {
            base.Perform();
            for (int x = -1; x <= 1; ++x) {
                for (int y = -1; y <= 1; ++y) {
                    Step step = new Step(x, y);
                    Position position = performer.Position.AddStep(step);
                    if (GameController.Instance.Map[position] == Terrain.Get("hidden-door").Character) {
                        GameController.Instance.Map[position] = Terrain.Get("closed-door").Character;
                        notify("spot");
                    }
                }
            }
            return true;
        }          
    }
}
