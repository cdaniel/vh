using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.World.Beings;
using VH.Game.World.Beings.Actions;
using VH.Engine.World.Beings.Actions;

namespace VH.Game.World.Beings.Ai {

    public class FleeBehavior: BaseAi {

        Being oponent;

        public FleeBehavior(Being being, Being oponent)
            : base(being) {
                this.oponent = oponent;
        }

        public override AbstractAction SelectAction() {
            return new MoveAction(Being, getStepAwayFrom(getPossibleSteps(Being, oponent.Position)));
        }
    }
}
