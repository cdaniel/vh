using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using VH.Engine.World.Items;

namespace VH.Game.World.Beings {

    public class RingSlot: EquipmentSlot {

        private string name;

        public RingSlot() { }

        public RingSlot(string name) {
            this.name = name;
        }

        public override string Name {
            get { return name; }
        }

        public override void FromXml(XmlElement element) {
            base.FromXml(element);
            this.name = GetStringAttribute("name");
        }

        public override XmlElement ToXml(string name, XmlDocument doc) {
            XmlElement element = base.ToXml(name, doc);
            AddAttribute("name", this.name);
            return element;
        }

        public override bool IsItemCompatible(Item item) {
            return item.Character == '=';
        }
    }
}
