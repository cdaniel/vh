using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace VH.Engine.Persistency {

    public abstract class AbstractPersistent: IPersistent{

        #region fields

        private XmlDocument doc;
        private XmlElement element;

        #endregion

        public virtual XmlElement ToXml(XmlDocument doc) {
            this.doc = doc;
            XmlElement element = doc.CreateElement(this.GetType().FullName);
            this.element = element;
            XmlAttribute assemblyAttribute = doc.CreateAttribute("assembly");
            String assemblyName = Path.GetFileName(GetType().Assembly.Location);
            assemblyAttribute.Value = assemblyName;
            element.Attributes.Append(assemblyAttribute);
            return element;
        }

        public virtual void FromXml(XmlElement element) { }

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

        public void AddElement(IPersistent child) {
            element.AppendChild(child.ToXml(doc));
        }

        public void AddElements(string name, IEnumerable<AbstractPersistent> elements) {
            XmlElement elementList = doc.CreateElement(name);
            foreach (AbstractPersistent e in elements) {
                elementList.AppendChild(e.ToXml(doc));
            }
            element.AppendChild(elementList);
        }


    }
}
