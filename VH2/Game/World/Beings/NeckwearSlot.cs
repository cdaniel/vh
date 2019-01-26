using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.World.Items;
using VH.Engine.Translations;

namespace VH.Game.World.Beings {

    public class NeckwearSlot: EquipmentSlot {

        public NeckwearSlot() { }

        public override string Name {
            get { return Translator.Instance["neckwear-slot"]; }
        }

        public override bool IsItemCompatible(Item item) {
            return item.Character == '\'';
        }
    }
}
