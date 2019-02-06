using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.Random;
using VH.Engine.World.Beings;
using VH.Engine.World.Beings.Actions;

namespace VH.Game.World.Beings.Actions {
    public class ConsumeRueAction : AbstractAction {

        private const float PETRIFICATION_RESISTANCE_RATE = 0.5f;

        public ConsumeRueAction() : base(null) { }
        public ConsumeRueAction(Being performer) : base(performer) { }


        public override bool Perform() {
            TempSet temps = (Performer as ITempsBeing).Temps;
            if (temps["poisoned"]) {
                temps["poisoned"] = false;
                notify("cure");
            }
            //
            if (Rng.Random.NextFloat() < PETRIFICATION_RESISTANCE_RATE) {
                temps["petrification-resistance"] = true;
                notify("petrification-resistance");
                if (Performer is IStatBeing) {
                    StatSet stats = (Performer as IStatBeing).Stats;
                    stats["St"].Value -= 1;
                }

            }
            return true;
        }
    }
}
