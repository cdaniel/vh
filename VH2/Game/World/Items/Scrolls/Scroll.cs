using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH2.Game.World.Items;
using System.Xml;
using VH.Engine.Translations;

namespace VH.Game.World.Items.Scrolls {

    public class Scroll: UsableItem, MagicalItem {

        #region fields

        private string hiddenName;
        private string hiddenAccusativ;
        private string hiddenPlural;
        private int identifyValue;

        #endregion

        public Scroll() {
            UseKind = "read";
        }

        #region properties

        public string HiddenName {
            get { return hiddenName; }
            set { hiddenName = value; }
        }

        public string HiddenAccusativ {
            get { return hiddenAccusativ; }
            set { hiddenAccusativ = value; }
        }

        public string HiddenPlural {
            get { return hiddenPlural; }
            set { hiddenPlural = value; }
        }

        public void Identify() {
            Name = HiddenName;
            Accusativ = HiddenAccusativ;
            Plural = HiddenPlural;
        }

        public int IdentifyValue {
            get { return identifyValue; }
            set { identifyValue = value; }
        }

        #endregion

        #region public methods

        public override void Create(XmlElement prototype) {
            base.Create(prototype);
            HiddenName = Name;
            HiddenAccusativ = Accusativ;
            HiddenPlural = Plural;
            Name = Translator.Instance["scroll"];
            Accusativ = Translator.Instance["scroll-accusativ"];
            Plural = Translator.Instance["scroll-plural"];
        }

        public override string ToString() {
            return Name;
        }

        #endregion
    }
}
