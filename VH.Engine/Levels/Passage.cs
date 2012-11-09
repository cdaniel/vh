using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VH.Engine.Levels {

    /// <summary>
    /// Represents a passage (such as a stairway) from this Level
    /// to another Level
    /// </summary>
    public class Passage {

        #region fields

        private Level level;
        private Position position;

        #endregion

        #region constructors

        public Passage(Level level) {
            this.level = level;
        }

        #endregion

        #region properties

        public Level Level {
            get { return level; }
        }

        public Position Position {
            get { return position; }
            set { position = value; }
        }

        #endregion

    }
}
