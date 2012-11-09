using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.World.Items;

namespace VH.Game.World.Beings {

    public class RingSlot: EquipmentSlot {

        private string name;

        public RingSlot(string name) {
            this.name = name;
        }

        public override string Name {
            get { return name; }
        }

        public override bool IsItemCompatible(Item item) {
            return item.Character == '=';
        }
    }
}
