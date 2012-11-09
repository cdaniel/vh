using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.Translations;

namespace VH.Engine.World.Items {

    /// <summary>
    /// Represents an equipment slot.
    /// </summary>
    public abstract class EquipmentSlot {

        #region fields

        protected Item item;

        #endregion

        #region constructors

        /// <summary>
        /// Creates an instance of EquipmentSlot
        /// </summary>
        public EquipmentSlot() { }

        #endregion

        #region properties
        
        /// <summary>
        /// Gets the name ot this equipment slot
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets otr sets an Item that is contained in this EquipmentSlot
        /// </summary>
        public Item Item {
            get { return item; }
            set { item = value; }
        }

        #endregion

        #region public methods

        /// <summary>
        /// Indicates whether a given Item can be contained in this EquipmentSlot
        /// </summary>
        /// <param name="item">An item to check</param>
        /// <returns>true if the item can be contained in this equipment slot</returns>
        public abstract bool IsItemCompatible(Item item);

        public override string ToString() {
            string result = Name + ": ";
            if (item != null) result += item.ToString();
            return result;
        }

        #endregion


    }
}
