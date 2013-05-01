using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Windows.Forms;
using Medical.Forms.Interfaces;

namespace Run.Implementation
{
    public class ContainnerProvider : IContainerProvider
    {
        private readonly string _configFile;
        private List<InstantItem> _itemList = new List<InstantItem>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainnerProvider"/> class.
        /// </summary>
        public ContainnerProvider()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainnerProvider"/> class.
        /// </summary>
        /// <param name="configFile">The config file.</param>
        public ContainnerProvider(string configFile)
        {
            this._configFile = configFile;
            LoadConfigFile();
        }

        /// <summary>
        /// Gets the component by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public Object GetComponentByKey(string key)
        {
            return (from item in _itemList
                    where item.Key.Equals(key)
                    let asm = Assembly.LoadFile(Application.StartupPath + "\\" + item.AssemblyName + ".dll")
                    select asm.CreateInstance(item.ClassName)).FirstOrDefault();
        }

        /// <summary>
        /// Loads the config file.
        /// </summary>
        private void LoadConfigFile()
        {
            string file = string.Format("{0}\\{1}", Application.StartupPath, this._configFile);
            var xml = new XmlDocument();
            xml.Load(file);
            var nodeList = xml.ChildNodes;
            if (nodeList.Count < 2) throw new Exception(string.Format("MenuFile is invalid format. [ File Name: {0}]", this._configFile));

            var keyList = new List<string>();
            _itemList = new List<InstantItem>();

            var rootNode = nodeList[1];
            if (rootNode.ChildNodes.Count == 0) return;
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (node.Attributes["Name"] == null) throw new Exception("Assembly name is missing.");
                if (node.ChildNodes.Count == 0) continue;
                foreach (XmlNode itemNode in node.ChildNodes)
                {
                    if (itemNode.Attributes["Name"] == null) throw new Exception("Class name is missing.");
                    if (itemNode.Attributes["Key"] == null) throw new Exception("Key is missing.");
                    if(keyList.Contains(itemNode.Attributes["Key"].Value))  throw new Exception("Key is conflicted.");
                    
                    var item = new InstantItem
                                   {
                                       AssemblyName = node.Attributes["Name"].Value,
                                       ClassName = itemNode.Attributes["Name"].Value,
                                       Key = itemNode.Attributes["Key"].Value
                                   };
                    keyList.Add(itemNode.Attributes["Key"].Value);
                    _itemList.Add(item);
                }
            }
        }
    }

    public class InstantItem
    {
        public string AssemblyName { get; set; }

        public string Key { get; set; }

        public string ClassName { get; set; }
    }
}
