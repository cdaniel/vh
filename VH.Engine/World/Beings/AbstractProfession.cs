using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VH.Engine.World.Beings {

    public abstract class AbstractProfession {

        protected Being being;
        protected string name;

        public AbstractProfession(Being being) {
            this.being = being;
        }

        public string Name {
            get { return name; }
        }

        public abstract void InitBeing();

        public override string ToString() {
            return Name;
        }

    }
}
