using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using VH.Engine.Display;
using VH.Engine.Game;
using VH.Engine.World.Beings;
using VH.Engine.World.Beings.Actions;
using VH.Engine.World.Beings.AI;

namespace VH.Game.World.Beings.Ai {
    public class WillOWispAi : BaseAi {

        #region constants

        private const int MAX_DISTANCE = 5;
        private const string WANDER = "wander";
        private const string HAUNT = "haunt"; 

        #endregion

        #region fields 

        private AbstractAi wander;
        private AbstractAi haunt;

        #endregion

        #region constructors

        public WillOWispAi(): base() {
            
        }

        public WillOWispAi(Being being) : base(being) {
            
        }

        #endregion

        #region properties

        public override Being Being {
            get => base.Being;
            set {
                base.Being = value;
                wander = new NeutralBehavior(Being);
            }
        }

        #endregion

        #region public methods

        public override void FromXml(XmlElement element) {
            base.FromXml(element);
            haunt = GetElement(HAUNT) as AbstractAi;
            wander = GetElement(WANDER) as AbstractAi;
        }

        public override XmlElement ToXml(string name, XmlDocument doc) {
            XmlElement element = base.ToXml(name, doc);
            AddElement(HAUNT, haunt);
            AddElement(WANDER, wander);
            return element;
        }

        public override AbstractAction SelectAction() {
            if (haunt == null) {
                Being hauntee = findHauntee();
                if (hauntee != null) {
                    haunt = new HauntBehavior(Being, hauntee);
                }
            }
            if (haunt != null) return haunt.SelectAction();
            else return wander.SelectAction();
            
         }

        #endregion

        #region private methods

        private Being findHauntee() {
            foreach (Being hauntee in GameController.Instance.Beings) {
                if (hauntee.Race == "human"
                    && Being.Position.Distance(hauntee.Position) <= MAX_DISTANCE) {
                    return hauntee;
                }
            }
            return null;
        }

        #endregion

    }
}
