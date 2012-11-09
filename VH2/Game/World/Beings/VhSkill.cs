using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.World.Beings;
using VH.Engine.Game;
using VH.Engine.Translations;
using VH.Engine.Random;

namespace VH.Game.World.Beings {

    public class VhSkill: Skill {

        #region fields

        private Stat stat;
        private Stat learningStat;

        #endregion

        #region constructors

        public VhSkill(string key, string name, int skillValue, Stat stat, Stat learningStat)
            : base(key, name, skillValue, 0) {
                this.stat = stat;
                this.learningStat = learningStat;
        }

        #endregion

        #region properties

        public Stat Stat {
            get { return stat; }
        }

        public override int MaxValue {
            get {
                return (int)(((float)Stat.Value / VhPc.MAX_STAT_VALUE) * MAX_SKILL_VALUE);
            }
        }

        #endregion

        #region public methods

        public override string ToString() {
            return base.ToString() + " (" + Stat.Name.Substring(0, 3) + ")";
        }

        #endregion

        #region protected methods

        protected override void train() {
            base.train();
            int skillUpgradeLevel = (Value / 5) * (25 - learningStat.Value);
            if (trainingPoints >= skillUpgradeLevel && Value < MaxValue) {
                Value++;
                trainingPoints = 0;
                string message = Name + Translator.Instance["skill-upgrade"] + Value;
                GameController.Instance.MessageManager.ShowDirectMessage(message);
            }
        }

        #endregion

    }
}
