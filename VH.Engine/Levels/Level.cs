using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using VH.Engine.World.Items;
using VH.Engine.World.Beings;
using VH.Engine.Game;
using VH.Engine.Persistency;
using System.Xml;

namespace VH.Engine.Levels {

    /// <summary>
    /// Describes relationship between levels.
    /// Defines which level can be reached from a given level.
    /// </summary>
    public class Level: AbstractPersistent {

        #region fields

        private Map map = null;
        private bool persistent = true;
        private bool bidirectional = true;
        private string name;
        private IMapGenerator mapGenerator;
        private int levelWidth;
        private int levelHeight;
        private int danger;

        private List<Passage> upPassages = new List<Passage>();
        private List<Passage> downPassages = new List<Passage>();

        protected List<Monster> monsters = new List<Monster>();
        protected List<Item> items = new List<Item>();

        #endregion

        #region constructors

        public Level(string name, IMapGenerator mapGenerator,
                int levelWidth, int levelHeight) {
            this.name = name;
            this.mapGenerator = mapGenerator;
            this.levelWidth = levelWidth;
            this.levelHeight = levelHeight;
        }

        public Level(string name, IMapGenerator levelGenerator,
                int levelWidth, int levelHeight, int danger)
            : this(name, levelGenerator, levelWidth, levelHeight) {
            this.danger = danger;
        }

        public Level() { } 

        #endregion

        #region properties

        public Map Map {
            get { return map; }
            set { map = value; }
        }

        public bool Persistent {
            get { return persistent; }
            set { persistent = value; }
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public IMapGenerator MapGenerator {
            get { return mapGenerator; }
            set { mapGenerator = value; }
        }

        public int LevelWidth {
            get { return levelWidth; }
            set { levelWidth = value; }
        }

        public int LevelHeight {
            get { return levelHeight; }
            set { levelHeight = value; }
        }

        public bool Bidirectional {
            get { return bidirectional; }
            set { bidirectional = value; }
        }

        public int Danger {
            get { return danger; }
            set { danger = value; }
        }

        public List<Monster> Monsters {
            get { return monsters; }
        }

        public List<Item> Items {
            get { return items; }
        }

        #endregion

        #region public methods

        public override XmlElement ToXml(XmlDocument doc) {
            XmlElement element =  base.ToXml(doc);
            AddAttribute("persistent", persistent);
            AddAttribute("bidirectional", bidirectional);
            AddAttribute("name", name);
            AddAttribute("level-width", levelWidth);
            AddAttribute("level-height", levelHeight);
            AddAttribute("danger", danger);
            AddElement(map);
            AddElements("monsters", monsters.Cast<AbstractPersistent>());
            AddElements("items", items.Cast<AbstractPersistent>());
            AddElements("up-passages", upPassages.Cast<AbstractPersistent>());
            AddElements("down-passages", downPassages.Cast<AbstractPersistent>());
            return element;
        }

        /// <summary>
        /// Enters the LevelStructure. 
        /// Sets up or loads the Map.
        /// </summary>
        public void Enter() {
            if (Persistent && map != null) {
                map.Load(Name);
            } else {
                Map = mapGenerator.Generate(levelWidth, levelHeight);
                foreach (Passage passage in upPassages) {
                    Position position = mapGenerator.GenerateFeature(Terrain.Get("upstair").Character);
                    passage.Position = position;
                }
                foreach (Passage passage in downPassages) {
                    Position position = mapGenerator.GenerateFeature(Terrain.Get("downstair").Character);
                    passage.Position = position;
                }
                // TODO consider refactoring this to avoid circular reference to GameController
                GameController.Instance.ItemGenerator.Generate(this);
                GameController.Instance.MonsterGenerator.Generate(this);
            }
        }

        /// <summary>
        /// Leaves the Level.
        /// Saves the map if needed.
        /// </summary>
        public void Leave() {
            if (Persistent) map.Save(Name);
        }

        public void AddLevelBelow(Level child) {
            downPassages.Add(new Passage(child));
            if (child.Bidirectional) child.AddLevelAbove(this);
        }

        public void AddLevelAbove(Level parent) {
            upPassages.Add(new Passage(parent));
        }

        /// <summary>
        /// Returns a Level  
        /// to which a passage (e.g. stairway) exists at a given Position
        /// or null, if no passage is found at this Position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Level GetNextLevel(Position position) {
            foreach (Passage passage in upPassages) {
                if (passage.Position.Equals(position)) return passage.Level;
            }
            foreach (Passage passage in downPassages) {
                if (passage.Position.Equals(position)) return passage.Level;
            }
            return null;
        }

        public Position GetPassagePosition(Level level) {
            foreach (Passage passage in upPassages) {
                if (passage.Level == level) return passage.Position;
            }
            foreach (Passage passage in downPassages) {
                if (passage.Level == level) return passage.Position;
            }
            return null;
        }

        /// <summary>
        /// Returns a Being occupying the specified square of current level
        /// or null if no Being is present on that square.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Monster GetMonsterAt(Position position) {
            foreach (Monster monster in monsters) {
                if (monster.Position.Equals(position)) return monster;
            }
            return null;
        }

        /// <summary>
        /// Returns a list of Items lying on the ground on the specified position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public IEnumerable<Item> GetItemsAt(Position position) {
            return
                from item in items
                where item.Position.Equals(position)
                select item;
        }

        #endregion

    }
}
