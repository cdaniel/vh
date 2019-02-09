using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.World.Beings;
using VH.Engine.World.Items;

namespace VH.Game.World.Beings {
    //TODO implement saving the backpack
    public class Humanoid : VhMonster,
        IBackPackBeing {

        private BackPack backPack = new BackPack("", 10);

        public BackPack BackPack {
            get { return backPack; }
        }
    }
}
