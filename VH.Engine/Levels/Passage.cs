using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using VH.Engine.Persistency;

namespace VH.Engine.Levels {

    /// <summary>
    /// Represents a passage (such as a stairway) from this Level
    /// to another Level
    /// </summary>
    public class Passage: AbstractPersistent {

        #region fields

        private Level targetLevel;
        private Position position;

        #endregion

        #region constructors

        public Passage(Level targetLevel) {
            this.targetLevel = targetLevel;
        }

        #endregion

        #region properties

        public Level Level {
            get { return targetLevel; }
        }

        public Position Position {
            get { return position; }
            set { position = value; }
        }

        #endregion

        #region public methods

        public override XmlElement ToXml(string name, XmlDocument doc) {
            XmlElement element =  base.ToXml(name, doc);
            AddElement("position", position);
            AddAttribute("target-level", targetLevel.Name);
            return element;
        }

        #endregion

    }
}
