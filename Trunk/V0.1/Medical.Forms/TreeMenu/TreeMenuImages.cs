using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Medical.Forms.TreeMenu
{
    [Serializable]
    public class TreeMenuImages
    {
        [XmlAttribute("Folder")]
        public String Folder { get; set; }

        [XmlArray]
        [XmlArrayItem("Name")]
        public List<String> Files { get; set; }
    }
}
