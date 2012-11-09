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

        private const string CAN_OPEN_DOOR = "can-open-door";
        private bool canOpenDoor = true;
        private TempSet temps = new TempSet();

        public TempSet Temps {
            get { return temps; }
        }

        public bool CanOpenDoor {
            get { return canOpenDoor; }
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


    }
}
