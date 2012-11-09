using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.Translations;

namespace VH.Engine.World.Beings {

    public class StatSet {

        #region fields

        private List<Stat> stats = new List<Stat>();
        private string title;

        #endregion

        #region constructors

        public StatSet(string title, params Stat[] stats) {
            this.title = title;
            foreach (Stat stat in stats) {
                this.stats.Add(stat);
            }
        }

        #endregion

        #region properties

        public virtual Stat this[string id] {
            get {
                return (
                    from stat in stats
                    where stat.Id == id
                    select stat as Stat
                ).Single();
            }
        }

        #endregion

        #region public methods

        public override string ToString() {
            StringBuilder sb = new StringBuilder(title + ":\n");
            foreach (Stat stat in stats) {
                sb.Append(stat.ToString() + "\n");
            }
            return sb.ToString();
        }

        #endregion

    }
}