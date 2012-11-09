using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Game.World.Items;
using VH.Engine.World.Beings;

namespace VH.Game.World.Beings.Actions {

    public class ReadAction: VhAction {

         private UsableItem item;

         public ReadAction(Being performer, UsableItem item)
            : base(performer) {
            this.item = item;
        }

        public override bool Perform() {
            
            ((IBackPackBeing)performer).BackPack.Remove(item);
            item.Position = performer.Position.Clone();
            notify(item.UseKind, item);
            item.Use(performer);
            base.Perform();
            return true;
        }
    }
}
