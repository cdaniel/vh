﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VH.Engine.Levels;
using System.Xml;
using VH.Engine.World;
using VH.Engine.Persistency;
using System.IO;

namespace VH.Engine.Display {

    public enum Person {
        Second,
        Third
    }

    /// <summary>
    /// Represents an entity that can be displayed on the screen. 
    /// Not for level squares representation.
    /// </summary>
    public abstract class AbstractEntity : AbstractPersistent, Creatable  {

        #region constants

        private const string ID = "id";
        private const string CHARACTER = "character";
        private const string NAME = "name";
        private const string ACCUSATIV = "accusativ";
        private const string PLURAL = "plural";
        private const string COLOR = "color";
        private const string DANGER = "danger";

        #endregion

        #region fields

        private string id;
        private char character;
        private string name;
        private string accusativ;
        private string plural;
        private Position position = new Position();
        private ConsoleColor color = ConsoleColor.Gray;
        private int danger;

        #endregion

        #region properties

        /// <summary>
        /// Gets the unique identifier of this AbstractEntity
        /// </summary>
        public string Id {
            get { return id; }
        }

        /// <summary>
        /// Gets or sets the name of this AbstractEntity
        /// </summary>
        public string Name {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets an Accusativ form of the name of this AbstractEntity
        /// </summary>
        public string Accusativ {
            get { return accusativ; }
            set { accusativ = value; }
        }

        /// <summary>
        /// Gets or sets the plural form of the name of this AbstractEntity
        /// </summary>
        public string Plural {
            get { return plural; }
            set { plural = value; }
        }

        /// <summary>
        /// Gets or sets the position where this AbstractEntity is located on the map.
        /// </summary>
        public Position Position {
            get { return position; }
            set { position = value; }
        }

        /// <summary>
        /// Gets or sets the character that represents this AbstractEntity on the display
        /// </summary>
        public char Character {
            get { return character; }
            set { character = value; }
        }

        /// <summary>
        /// Gets or sets the color in which this AbstractEntity is rendered on the display
        /// </summary>
        public ConsoleColor Color {
            get { return color; }
            set { color = value; }
        }

        /// <summary>
        /// In which grammatical person is this Being referred to. 
        /// </summary>
        public abstract Person Person { get; }

        /// <summary>
        /// The name that this Being is referred by.
        /// </summary>
        public abstract string Identity { get; }

        /// <summary>
        /// The danger level of this entity
        /// </summary>
        public int Danger {
            get { return danger; }
            set { danger = value; }
        }

        #endregion

        #region public methods

        public override XmlElement ToXml(string name, XmlDocument doc) {
            XmlElement element = base.ToXml(name, doc);
            AddAttribute("id", id);
            AddAttribute("character", character);
            AddAttribute("name", name);
            AddAttribute("accusativ", accusativ);
            AddAttribute("plural", plural);
            AddAttribute("danger", danger);
            AddAttribute("color", color.ToString());
            AddElement("position", position);
            return element;
        }

        public virtual void Create(XmlElement prototype) {
            id = prototype.Attributes[ID].Value;
            Character = prototype.Attributes[CHARACTER].Value[0];
            Name = prototype.Attributes[NAME].Value;
            Danger = int.Parse(prototype.Attributes[DANGER].Value);
            if (prototype.Attributes[ACCUSATIV] != null) Accusativ = prototype.Attributes[ACCUSATIV].Value;
            if (prototype.Attributes[PLURAL] != null) Plural = prototype.Attributes[PLURAL].Value;
            if (prototype.Attributes[COLOR] != null) {
                color = (ConsoleColor)Enum.Parse(
                    typeof(ConsoleColor),
                    prototype.Attributes[COLOR].Value
                );
            }
        }

        #endregion
    }
}
