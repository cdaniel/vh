using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.Display;
using System.Xml;

namespace VH.Engine.World.Items {

    /// <summary>
    /// Represents an item.
    /// </summary>
    public class Item: AbstractEntity  {

        #region constants

        #endregion

        #region fields


        #endregion

        #region properties

        public override Person Person {
            get { return Person.Third; }
        }

        /// <summary>
        /// The name that this Being is referred by.
        /// </summary>
        public override string Identity {
            get { return Name; } 
        }

        #endregion

        #region public methods

        public override void Create(XmlElement prototype) {
            base.Create(prototype);
        }

        #endregion

    }
}
