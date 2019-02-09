using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.Random;
using VH.Engine.World.Beings;
using VH.Engine.World.Beings.Actions;
using VH.Engine.World.Beings.AI;
using VH.Game.World.Beings.Actions;

namespace VH.Game.World.Beings.Ai {
    public class BobokAi : HostileAi {

        private const float STEAL_RATE = 0.3f;

        public BobokAi() {
        }

        public BobokAi(Being being) : base(being) {
        }


        public override AbstractAction SelectAction() {
            AbstractAction action = base.SelectAction();
            if (action is AttackAction) {
                AttackAction attackAction = action as AttackAction;
                Being attackee = attackAction.Attackee;
                if (Rng.Random.NextFloat() < STEAL_RATE && attackee is IBackPackBeing) {
                    return new StealAction(Being, attackee);
                } else {
                    return attackAction;
                }
            }
            return action;
        }
    }
}
