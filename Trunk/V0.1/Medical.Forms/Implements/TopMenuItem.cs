using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace Medical.Forms.Implements
{
    public class TopMenuItem
    {
        public TopMenuItem()
        {
        }

        public TopMenuItem(XmlNode xml)
        {
            this.XmlNode = xml;
            var info = this.GetType().GetProperties();
            if (info.Length == 0) return;
            foreach (var inf in info)
            {
                if (inf.Name.Equals("ParentItem")) continue;
                if (inf.Name.Equals("Childs")) continue;
                if (inf.Name.Equals("XmlNode")) continue;
                if (xml.Attributes == null) continue;
                if (xml.Attributes[inf.Name] == null) continue;
                if (xml.Attributes[inf.Name].Value == null) continue;

                switch (inf.PropertyType.Name)
                {
                    case "Boolean" :
                        inf.SetValue(this, Convert.ToBoolean(xml.Attributes[inf.Name].Value), null);
                        break;
                    default:
                        inf.SetValue(this, xml.Attributes[inf.Name].Value, null);
                        break;
                }
            }
        }

        public string Key { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string ShortKey{ get; set; }

        public Boolean IsShowToolBar { get; set; }

        public string InvokeKey { get; set; }

        public TopMenuItem ParentItem
        {
            get
            {
                return this.XmlNode.ParentNode == null ? null : new TopMenuItem(this.XmlNode.ParentNode);
            }
        }

        public List<TopMenuItem> Childs
        {
            get
            {
                var childs = new List<TopMenuItem>();
                if (this.XmlNode.ChildNodes.Count == 0) return childs;
                childs.AddRange(from XmlNode node in this.XmlNode.ChildNodes select new TopMenuItem(node));
                return childs;
            }
        }

        public XmlNode XmlNode { get; set; }

        public Keys GetKey()
        {
            if (string.IsNullOrEmpty(this.ShortKey)) return Keys.None;
            string[] keys = this.ShortKey.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
            if (keys.Count() == 0) return Keys.None;
            return keys.Aggregate(Keys.None, (current, key) => (Keys) (current | (Keys) Enum.Parse(typeof (Keys), key, true)));
        }

    }
}
