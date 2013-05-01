using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Medical.Forms.TreeMenu
{
    [Serializable()]
    public class TreeMenuItem
    {
        [XmlAttribute("No")]
        public int No { get; set; }

        [XmlAttribute("Title")]
        public String Title { get; set; }

        [XmlAttribute("Key")]
        public String Key { get; set; }

        [XmlAttribute("Role")]
        public String Role { get; set; }

        [XmlAttribute("ImageIndex")]
        public int ImageIndex { get; set; }

        [XmlAttribute("Description")]
        public String Description { get; set; }

        public List<TreeMenuItem> Childs { get; set; }

    }
    
}
