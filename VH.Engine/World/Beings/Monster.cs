using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.World.Beings;
using VH.Engine.Display;
using System.Xml;
using VH.Engine.World.Beings.Actions;
using VH.Engine.Game;
using VH.Engine.World.Items;
using VH.Engine.World.Beings.AI;

namespace VH.Engine.World.Beings {

    public class Monster: 
        Being {

        #region constants

        private const string AI_TYPE_NAME = "ai-type-name";
        private const string AI_ASSEMBLY_NAME = "ai-assembly-name";
        private const string ATTACK = "attack";
        private const string DEFENSE = "defense";
        private const string HEALTH = "health";


        #endregion

        #region fields

        private int health;
        private int maxHealth;
        private int attack;
        private int defense;
        private int distanceAttack;
        private int ticksAvailable;

        #endregion 

        #region properties

        public override Person Person {
            get { return Person.Third; }
        }

        public override string Identity {
            get { return Name; }
        }

        public override int Health {
            get { return health; }
            set { health = value; }
        }

        public override int MaxHealth {
            get { return maxHealth; }
        }

        public override int Attack {
            get { return attack; }
        }

        public override int Defense {
            get { return defense; }
        }

        public override int DistanceAttack {
            get { return distanceAttack; }
        }

        #endregion

        #region public methods

        public void Move(int gametimeTicks) {
            AbstractAction action;
            ticksAvailable += gametimeTicks;
            do {
                action = Ai.SelectAction();
                int ticksNeeded = (int)(action.TimeNeeded / Speed);
                if (ticksNeeded <= ticksAvailable) action.Perform();
                else break;
                // disregard whether the action actually succeeded.
                // it's better to consume ticks for a failed/invalid action
                // than to risk an infinite action loop.
                ticksAvailable -= ticksNeeded;
            } while (ticksAvailable > 0 && !GameController.Instance.QuitGame);
        }

        public override void Create(XmlElement prototype) {
            base.Create(prototype);
            //
            maxHealth = health = int.Parse(prototype.Attributes[HEALTH].Value);
            attack = int.Parse(prototype.Attributes[ATTACK].Value);
            defense = int.Parse(prototype.Attributes[DEFENSE].Value);
            //
            string aiTypeName = prototype.Attributes[AI_TYPE_NAME].Value;
            string aiAssemblyName = prototype.Attributes[AI_ASSEMBLY_NAME].Value;
            Ai = AbstractAi.LoadAi(aiTypeName, aiAssemblyName);
            Ai.Being = this;
        }

        public override void Kill() {
            base.Kill();
            GameController.Instance.Level.Monsters.Remove(this);
            if (this is IBackPackBeing) {
                foreach (Item item in ((IBackPackBeing)this).BackPack.Items) {
                    item.Position = Position.Clone();
                    GameController.Instance.Level.Items.Add(item);
                }
            }
        }

        #endregion
    }

}
