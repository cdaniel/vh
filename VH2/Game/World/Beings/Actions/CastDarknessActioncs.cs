using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.World.Beings;
using VH.Engine.Levels;
using VH.Engine.Game;

namespace VH.Game.World.Beings.Actions {

    public class CastDarknessActioncs: VhAction {

        private const int RANGE = 5;

        public CastDarknessActioncs(): base(null) { }
        public CastDarknessActioncs(Being performer) : base(performer) { }

        public override bool Perform() {
            if (((ISkillsBeing)performer).Skills["magick"].Roll()) {
                for (int i = -RANGE; i <= RANGE; ++i) {
                    for (int j = -RANGE; j <= RANGE; ++j) {
                        if (i * i + j * j <= RANGE * RANGE) {
                            int x = Performer.Position.X + i;
                            int y = Performer.Position.Y + j;
                            Terrain terrain = Terrain.Get(GameController.Instance.Map[x, y]);
                            GameController.Instance.Map[x, y] = getDarkTerrain(terrain).Character;
                        }
                    }
                }
                notify("cast-darkness");
            } else {
                notify("spell-failed");
            }
            return true;
        }

        private Terrain getDarkTerrain(Terrain terrain) {
            if (terrain.Key == "floor") return Terrain.Get("dark-floor");
            if (terrain.Key == "ground") return Terrain.Get("dark-ground");
            if (terrain.Key == "corridor") return Terrain.Get("dark-corridor");
            if (terrain.Key == "grass") return Terrain.Get("dark-grass");
            return terrain;
        }

    }
}

