﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.World.Beings.Actions;
using VH.Game.World.Beings.Actions;
using VH.Engine.Random;

namespace VH.Game.World.Beings.Ai {

    public class SicknessAi: HostileAi {

        private const float ILLESS_ATACK_RATE = 0.30f;
        

        public SicknessAi() : base() { }

        public override AbstractAction SelectAction() {
            AbstractAction action = base.SelectAction();
            if (action is AttackAction && Rng.Random.NextFloat() < ILLESS_ATACK_RATE) {
                action = new CauseIllnessAction((action as AttackAction).Attackee);
            }
            return action;
        }
    }
}
