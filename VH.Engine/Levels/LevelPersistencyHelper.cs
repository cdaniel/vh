using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using VH.Engine.Persistency;

namespace VH.Engine.Levels {
    public class LevelPersistencyHelper: AbstractPersistent {

        private Level startingLevel;

        public LevelPersistencyHelper(Level startingLevel) {
            this.startingLevel = startingLevel;
        }

        public override XmlElement ToXml(string name, XmlDocument doc) {
            XmlElement element = base.ToXml(name, doc);
            HashSet<IPersistent> traversed = new HashSet<IPersistent>();
            traverse(startingLevel, traversed);
            foreach (IPersistent persistent in traversed) {
                if (persistent is Level) {
                    AddElement("level", persistent);
                }
            } 
            return element;
        }

        private void traverse(Level level, HashSet<IPersistent> traversed) {
            if (!traversed.Contains(level)) {
                traversed.Add(level);
                foreach (Passage passage in level.UpPassages) traverse(passage, traversed);
                foreach (Passage passage in level.DownPassages) traverse(passage, traversed);
            }

        }

        private void traverse(Passage passage, HashSet<IPersistent> traversed) {
            if (!traversed.Contains(passage)) {
                traversed.Add(passage);
                traverse(passage.Level, traversed);
            }
        }

    }
}
