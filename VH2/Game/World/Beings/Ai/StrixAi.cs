﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.World.Beings.Actions;
using VH.Game.World.Beings.Actions;

namespace VH.Game.World.Beings.Ai.Stimuli {
    public class StrixAi: HostileAi {

        public StrixAi() : base() { }

        public override AbstractAction SelectAction() {
            AbstractAction action = base.SelectAction();
            if (action is AttackAction) {
                action = new SuckLifeAction(Being, (action as AttackAction).Attackee);
            }
            return action;
        }
    }
}
