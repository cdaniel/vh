using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace VH.Engine.Levels {

    /// <summary>
    /// Represents location of an entity (Item or Being) in Level coorditates.
    /// </summary>
    public class Position {

        #region fields

        private int x;
        private int y;

        #endregion

        #region constructors

        public Position(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public Position() { }

        #endregion

        #region properties

        public int X {
            get { return x; }
            set { x = value; }
        }

        public int Y {
            get { return y; }
            set { y = value; }
        }

        #endregion

        #region public methods

        public Position AddStep(Step step) {
            Position position = new Position(x, y);
            position.x += step.X;
            position.y += step.Y;
            return position;
        }

        public bool Equals(Position otherPosition) {
            return X == otherPosition.X && Y == otherPosition.Y;
        }

        public Position Clone() {
            return new Position(x, y);
        }

        #endregion

    }
}
