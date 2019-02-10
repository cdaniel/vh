using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using VH.Engine.Game;
using VH.Engine.World.Beings;
using VH.Engine.World.Items;

namespace VH.Game.World.Beings {

    public class Humanoid : VhMonster,
        IBackPackBeing {

        private string BACK_PACK = "backpack";

        private BackPack backPack = new BackPack("", 10);

        public BackPack BackPack {
            get { return backPack; }
        }

        public override void Kill() {
            base.Kill();
            foreach (Item item in ((IBackPackBeing)this).BackPack.Items) {
                item.Position = Position.Clone();
                GameController.Instance.Level.Items.Add(item);
            }
        }

        public override void FromXml(XmlElement element) {
            base.FromXml(element);
            backPack = GetElement(BACK_PACK) as BackPack;
        }

        public override XmlElement ToXml(string name, XmlDocument doc) {
            XmlElement element = base.ToXml(name, doc);
            AddElement(BACK_PACK, BackPack);
            return element;
        }

    }
}
