using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using VH.Engine.Persistency;
using VH.Engine.Random;

namespace VH.Engine.World.Beings {

    public class Skill: AbstractPersistent {

        #region constants

        protected const int MAX_SKILL_VALUE = 100;

        #endregion

        #region fields

        private string id;
        private string name;
        private int skillValue;
        private int maxValue;

        protected int trainingPoints = 0;

        #endregion

        #region constructors

        public Skill(string id, string name, int maxValue) : this(id, name, 0, maxValue) { }

        public Skill(string id, string name, int skillValue, int maxValue) {
            this.id = id;
            this.name = name;
            this.skillValue = skillValue;
            this.maxValue = maxValue;
        }

        #endregion

        #region properties

        public string Id {
            get { return id; }
        }

        public string Name {
            get { return name; }
        }

        public int Value {
            get { return skillValue; }
            set {
                if (value < 0) skillValue = 0;
                else if (value > MaxValue) skillValue = MaxValue;
                else skillValue = value; 
            }
        }

        public virtual int MaxValue {
            get { return maxValue; }
        }

        #endregion

        #region public methods

        public override XmlElement ToXml(XmlDocument doc) {
            AddAttribute("id", id);
            AddAttribute("name", name);
            AddAttribute("skill-value", skillValue);
            AddAttribute("max-value", maxValue);
            AddAttribute("training-points", trainingPoints);
            return base.ToXml(doc);
        }

        public bool Roll(int difficulty) {
            float valueToMatch = (float)skillValue / MAX_SKILL_VALUE;
            bool success = Rng.Random.NextFloat() <= valueToMatch - difficulty;
            if (success) train();
            return success;
        }

        public bool Roll() {
            return Roll(0);
        }

        public override string ToString() {
            return Name + ": " + Value + "/" + MaxValue;
        }

        #endregion

        #region protected methods

        protected virtual void train() {
            trainingPoints++;
        }

        #endregion

    }
}
