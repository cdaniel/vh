using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.World.Beings;
using VH.Engine.World.Beings.Actions;

namespace VH.Game.World.Beings.Actions {
    public class JumpAction : VhAction {

        public JumpAction(Being performer): base(performer) { }



        public override bool Perform() {
            notify("disappear");
            Performer.ChoosePosition();
            notify("appear");
            return true;
        }

    }
}
