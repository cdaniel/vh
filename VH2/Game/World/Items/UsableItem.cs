using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.World.Items;
using VH.Engine.World.Beings.Actions;
using VH.Engine.World.Beings;
using System.Xml;

namespace VH.Game.World.Items {

    public class UsableItem: Item {

        #region constants

        private const string ACTION_TYPE_NAME = "action-type-name";
        private const string ACTION_ASSEMBLY_NAME = "action-assembly-name";

        #endregion

        #region fields

        private string actionTypeName;
        private string actionAssemblyName;
        private string useKind;

        #endregion

        #region properties

        public string UseKind {
            get { return useKind; }
            set { useKind = value; }
        }

        #endregion

        #region public methods

        public bool Use(Being performer) {
            AbstractAction action = AbstractAction.LoadAction(actionTypeName, actionAssemblyName);
            action.Performer = performer;
            return action.Perform();
        }

        public override void Create(XmlElement prototype) {
            base.Create(prototype);
            actionTypeName = prototype.Attributes[ACTION_TYPE_NAME].Value;
            actionAssemblyName = prototype.Attributes[ACTION_ASSEMBLY_NAME].Value;
        }

        #endregion

    }
}
