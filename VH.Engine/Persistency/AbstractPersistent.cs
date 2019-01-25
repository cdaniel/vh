﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace VH.Engine.Persistency {

    public abstract class AbstractPersistent: IPersistent{

        #region constants

        private const string LIST_ITEM = "-item";

        #endregion

        #region fields

        private XmlDocument doc;
        private XmlElement element;

        #endregion

        #region public virtual methods

        public virtual XmlElement ToXml(string name, XmlDocument doc) {
            this.doc = doc;
            XmlElement element = doc.CreateElement(name);
            this.element = element;
            XmlAttribute typeAttribute = doc.CreateAttribute("type");
            XmlAttribute assemblyAttribute = doc.CreateAttribute("assembly");
            String typeName = this.GetType().FullName;
            String assemblyName = Path.GetFileName(GetType().Assembly.Location);
            typeAttribute.Value = typeName;
            element.Attributes.Append(typeAttribute);
            assemblyAttribute.Value = assemblyName;
            element.Attributes.Append(assemblyAttribute);
            return element;
        }

        public virtual void FromXml(XmlElement element) {
            this.element = element;
        }

        #endregion

        #region public methods

        public string GetStringAttribute(String name) {
            return element.Attributes[name].Value;
        }

        public bool GetBoolAttribute(String name) {
            return Boolean.Parse(GetStringAttribute(name));
        }

        public int GetIntAttribute(String name) {
            return Int32.Parse(GetStringAttribute(name));
        }

        public void AddAttribute(String name, String value) {
            XmlAttribute attribute = doc.CreateAttribute(name);
            attribute.Value = value;
            element.Attributes.Append(attribute);
        }

        public void AddAttribute(String name, Object obj) {
            AddAttribute(name, obj.ToString());
        }

        public void AddAttribute(String name, bool value) {
            AddAttribute(name, "" + value);
        }

        public void AddAttribute(String name, int value) {
            AddAttribute(name, "" + value);
        }

        public IPersistent GetElement(string name) {
            XmlNode node = element.SelectSingleNode("./" + name);
            return PersistentFactory.CreateObject(doc, (XmlElement)node);
        }

        public void AddElement(string name, IPersistent child) {
            if (child != null )
                element.AppendChild(child.ToXml(name, doc));
        }

        public string GetRawData(string name) {
            XmlNode data = element.ChildNodes[0];
            if (!(data is XmlCDataSection)) throw new ArgumentException("Node '" + name + "' is not a CData node.");
            return (data as XmlCDataSection).Value;
        }

        public void AddRawData(string name, string data) {
            XmlElement dataElement = doc.CreateElement(name);
            element.AppendChild(dataElement);
            dataElement.AppendChild(doc.CreateCDataSection(data));
        }

        public IEnumerable<IPersistent> GetElements(string name) {
            XmlNodeList nodes = element.SelectNodes("./" + name + "/" + name + LIST_ITEM);
            List<IPersistent> list = new List<IPersistent>();
            foreach (XmlNode node in nodes) {
                list.Add(PersistentFactory.CreateObject(doc, (XmlElement)node));
            }
            return list;
        }

        public void AddElements(string name, IEnumerable<AbstractPersistent> elements) {
            XmlElement elementList = doc.CreateElement(name);
            foreach (AbstractPersistent e in elements) {
                elementList.AppendChild(e.ToXml(name + LIST_ITEM, doc));
            }
            element.AppendChild(elementList);
        }

        #endregion
    }
}
