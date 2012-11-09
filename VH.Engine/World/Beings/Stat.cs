using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VH.Engine.World.Beings {

    public class Stat: ICloneable {

        #region fields

        private string id;
        private string name;
        private int attributeValue;

        #endregion

        #region constructors

        public Stat(string id, string name): this(id, name, 0) { }

        public Stat(string id, string name, int attributeValue) {
            this.id = id;
            this.name = name;
            this.attributeValue = attributeValue;
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
            get { return attributeValue; }
            set { attributeValue = value; }
        }

        #endregion

        #region public methods

        public override string ToString() {
            return Name + ": " + Value;
        }

        public object Clone() {
            return new Stat(Id, Name, Value);
        }

        #endregion


    }
}
