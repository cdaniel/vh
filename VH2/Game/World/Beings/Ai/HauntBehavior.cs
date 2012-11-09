using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.World.Beings;
using VH.Engine.World.Beings.Actions;
using VH.Engine.World.Beings.AI;

namespace VH.Game.World.Beings.Ai {

    public class HauntBehavior: BaseAi {

        private const int MAX_DISTANCE = 5;
        private const int MIN_DISTANCE = 3;

        private Being oponent;
        private AbstractAi chase;
        private AbstractAi runAway;
        private AbstractAi wander;

        public HauntBehavior(Being being, Being oponent): base(being) {
            this.oponent = oponent;
            chase = new ChaseBehavior(being, oponent);
            runAway = new FleeBehavior(being, oponent);
            wander = new NeutralBehavior(being);
        }

        public override AbstractAction SelectAction() {
            float distance = getDistance(Being.Position, oponent.Position);
            if (distance > MAX_DISTANCE) return chase.SelectAction();
            if (distance < MIN_DISTANCE) return runAway.SelectAction();
            return wander.SelectAction();
        }


    }
}
