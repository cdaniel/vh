using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.World.Beings;
using VH.Game.World.Beings.Actions;
using VH.Engine.World.Beings.Actions;

namespace VH.Game.World.Beings.Ai {

    public class ChaseBehavior: BaseAi {

        private Being oponent;

        public ChaseBehavior(Being being, Being oponent)
            : base(being) {
                this.oponent = oponent;
        }

        public override AbstractAction SelectAction() {
            if (isAdjacentTo(oponent)) return new AttackAction(Being, oponent);
            else return new MoveAction(Being, getStepTowards(getPossibleSteps(Being, oponent.Position)));
        }

        protected bool isAdjacentTo(Being oponent) {
            return Math.Max(Math.Abs(Being.Position.X - oponent.Position.X),
                Math.Abs(Being.Position.Y - oponent.Position.Y)) == 1;
        }


    }
}
