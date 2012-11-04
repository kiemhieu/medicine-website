using System;
using System.Collections.Generic;
using System.Xml;
using System.Windows.Forms;
using Medical.Forms.Entities;
using Medical.Forms.Interfaces;
using System.Data;

namespace RunTest.Implementation
{
    public class MessageManager : IMessageManager
    {
        readonly Dictionary<string, SystemMessage> _messageDic = new Dictionary<string, SystemMessage>();
        private readonly string _configFile;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageManager"/> class.
        /// </summary>
        public MessageManager()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageManager"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        public MessageManager(string file)
        {
            this._configFile = file;
            LoadConfigFile();
            var dt = new DataTable();
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
            if (nodeList.Count < 2) throw new Exception(string.Format("Message.Xml is invalid format. [ File Name: {0}]", this._configFile));

            this._messageDic.Clear();
            foreach (XmlNode node in xml.ChildNodes[1].ChildNodes)
            {
                var message = CreateMessageFromRootXmlNode(node);
                this._messageDic.Add(message.ID, message);
            }            
        }

        /// <summary>
        /// Gets the message by ID.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public SystemMessage GetMessageByID(string id, params object[] param)
        {
            if (!this._messageDic.ContainsKey(id)) throw new Exception(string.Format("This message id {0} is not existed in the message list", id));

            SystemMessage msg;
            this._messageDic.TryGetValue(id, out msg);
            if (param == null || param.Length == 0) return msg;

            msg.Content = string.Format(msg.Content, param);
            return msg;
        }

        /// <summary>
        /// Gets the message by ID.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="param">The param.</param>
        /// <returns></returns>
        public SystemMessage GetFormatedMessageById(string id, params object[] param)
        {
            return null;
        }

        /// <summary>
        /// Creates the message from root XML node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        private static SystemMessage CreateMessageFromRootXmlNode(XmlNode node)
        {
            if (node.ChildNodes.Count != 4) return null;
            var message = new SystemMessage();
            foreach (XmlNode item in node.ChildNodes)
            {
                switch (item.Name)
                {
                    case "Code":
                        message.ID = item.InnerText;
                        break;
                    case "Content":
                        message.Content = item.InnerText;
                        break;
                    case "Type":
                        message.Type = MappingIconFromString(item.InnerText);
                        break;
                    case "Button":
                        if (String.IsNullOrEmpty(item.InnerText)) break;
                        message.Button = MappingButtonFromString(item.InnerText);
                        break;
                    default:
                        break;
                }
            }
            return message;
        }

        /// <summary>
        /// Mappings from string.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        private static MessageBoxIcon MappingIconFromString(string str)
        {
            return (MessageBoxIcon) Enum.Parse(typeof(MessageBoxIcon), str, true);
        }

        /// <summary>
        /// Mappings the button from string.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <returns></returns>
        private static MessageBoxButtons MappingButtonFromString(string str)
        {
            return (MessageBoxButtons)Enum.Parse(typeof(MessageBoxButtons), str, true);
        }
    }
}
