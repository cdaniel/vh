using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.World.Beings.Actions;
using VH.Engine.World.Beings;
using VH.Engine.Game;
using VH.Engine.World.Items;
using VH.Game.World.Beings.Ai.Stimuli;
using VH.Engine.Random;

namespace VH.Game.World.Beings.Actions {
    
    public class AttackAction: VhAction {

        private Being attackee;
        private GameController controller = GameController.Instance;

        public AttackAction(Being performer, Being attackee) : base(performer) {
            this.attackee = attackee;
        }

        public Being Attackee {
            get { return attackee; }
        }

        public override bool Perform() {
            int attack = Rng.Random.Next(performer.Attack);
            int defense = Rng.Random.Next(attackee.Defense);
            int damage = attack - defense;
            if (damage > 0) {
                attackee.DecreaseHealth(damage, performer.Accusativ);
                notify("attack", attackee);
            } else {
                notify("miss", attackee);
            }
            attackee.Ai.Stimulate(new AttackStimulus(performer));
            if (attackee.Health <= 0) {
                attackee.Ai.Notify("killed");
                attackee.Kill();
            }
            base.Perform();
            return true;
        }

    }
}
