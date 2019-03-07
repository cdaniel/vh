using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.World.Beings;
using VH.Engine.World.Items;
using System.Xml;
using VH.Engine.Levels;

namespace VH.Game.World.Beings {

    public class VhMonster: Monster, ITempsBeing {

        #region constants

        private const string CAN_OPEN_DOOR = "can-open-door";
        private const string TEMPS = "temps";

        #endregion

        #region fields

        private bool canOpenDoor = false;
        private TempSet temps = new TempSet();

        #endregion

        #region properties

        public TempSet Temps {
            get { return temps; }
        }

        public bool CanOpenDoor {
            get { return canOpenDoor; }
        }

        #endregion

        #region public methods

        public override void FromXml(XmlElement element) {
            base.FromXml(element);
            canOpenDoor = GetBoolAttribute(CAN_OPEN_DOOR);
            temps = GetElement(TEMPS) as TempSet;
        }

        public override XmlElement ToXml(string name, XmlDocument doc) {
            XmlElement element =  base.ToXml(name, doc);
            AddAttribute(CAN_OPEN_DOOR, canOpenDoor);
            AddElement(TEMPS, temps);
            return element;
        }

        public override void Create(XmlElement prototype) {
            base.Create(prototype);
            if (prototype.Attributes[CAN_OPEN_DOOR] != null) {
                canOpenDoor = bool.Parse(prototype.Attributes[CAN_OPEN_DOOR].Value); 
            }
        }

        public override bool CanWalkOn(char c) {
            return base.CanWalkOn(c) || canOpenDoor && c == Terrain.Get("closed-door").Character;
        }

        #endregion


    }
}
