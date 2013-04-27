using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using Medical.Forms.EventArgs;
using Medical.Forms.Implements;
using Medical.Forms.Interfaces;

namespace RunTest.Implementation
{
    public class MenuProvider : IMenuManager
    {
        private readonly string _iconPath = Application.StartupPath + "\\Icons";
        public event EventHandler<MenuItemClickedEventArgs> MenuItemClicked;
        private readonly List<TopMenuItem> _toolBarItem;
        private string _configFile;

        private TopMenuItem _rootItem;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuProvider"/> class.
        /// </summary>
        public MenuProvider()
        {
            _toolBarItem = new List<TopMenuItem>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuProvider"/> class.
        /// </summary>
        /// <param name="configFile">The config file.</param>
        public MenuProvider(string configFile) : this()
        {
            this._configFile = configFile;
            LoadConfigFile();
        }

        /// <summary>
        /// Loads the config file.
        /// </summary>
        private void LoadConfigFile()
        {
            var file = string.Format("{0}\\{1}", Application.StartupPath, this._configFile);
            var xml = new XmlDocument();
            xml.Load(file);
            var nodeList = xml.ChildNodes;
            if (nodeList.Count < 2) throw new Exception(string.Format("MenuFile is invalid format. [ File Name: {0}]", this._configFile));
            this._rootItem = new TopMenuItem(nodeList[1]);
        }

        /// <summary>
        /// Bindings the menu item. 
        /// </summary>
        /// <param name="cntrl">The CNTRL.</param>
        /// <param name="item">The item.</param>
        public void BindingMenuItem(Control cntrl, TopMenuItem item)
        {
        }

        /// <summary>
        /// Creates the menu item.
        /// </summary>
        public void CreateMenuItem(params Control[] menuCntrl)
        {
            if (menuCntrl == null) return;
            if (menuCntrl.Length == 0) return;
            var trip = menuCntrl[0] as TreeView;
            LoadMenuItem(trip);
            //if (trip == null) return;
            //trip.Items.Clear();

            //foreach (var item in this._rootItem.Childs)
            //{
            //    var toolTrip = new ToolStripMenuItem {Tag = item, Name = item.Key, Text = item.Name};
            //    //toolTrip.Click += toolTrip_Click;
            //    trip.Items.Add(toolTrip);

            //    // LoadMenuItem(toolTrip);
            //    //var childNode = new TreeNode(item.Name);
            //    //childNode.Name = item.Key;
            //    //GetNote(childNode, item);
            //    //item.Nodes.Add(childNode);

            //    if (this._toolBarItem.Count == 0 || this._toolBarItem[this._toolBarItem.Count - 1].Name.Equals("|")) continue;
            //    _toolBarItem.Add(new TopMenuItem() {Name = "|"});
            //}
        }


        /// <summary>
        /// Creates the tool bar. 
        /// Note: Call after create menu strip to  fully loading of item
        /// </summary>
        /// <param name="toolbar">The toolbar.</param>
        public void CreateToolBar(ToolStrip toolbar)
        {
            toolbar.Items.Clear();
            foreach (var item in _toolBarItem)
            {
                if (item.Name.Equals("|"))
                {
                    toolbar.Items.Add(new ToolStripSeparator());
                    continue;
                }
                var path = !String.IsNullOrEmpty(item.Image) ? string.Format("{0}\\{1}", _iconPath, item.Image) : string.Format("{0}\\tools.png", _iconPath);
                var toolItem = new ToolStripButton
                                   {
                                       DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image,
                                       Image = System.Drawing.Image.FromFile(path),
                                       ImageTransparentColor = System.Drawing.Color.Magenta,
                                       Name = item.Key,
                                       Size = new System.Drawing.Size(16, 16),
                                       Text = item.Name,
                                       Tag = item
                                   };
                toolItem.Click += ToolTripClick;
                toolbar.Items.Add(toolItem);

            }
        }

        /// <summary>
        /// Loads the menu item.
        /// </summary>
        /// <param name="item">The item.</param>
        private void LoadMenuItem(TreeView tree)
        {
            tree.NodeMouseClick += new TreeNodeMouseClickEventHandler(tree_NodeMouseClick);
            foreach (var item in this._rootItem.Childs)
            {
                var childNode = new TreeNode(item.Name);
                childNode.Name = item.Key;
                GetNote(childNode, item);
                tree.Nodes.Add(childNode);
            }
            /*
            var triItem = item.Tag as TopMenuItem;
            if (triItem == null) return;
            if (triItem.Childs.Count == 0) return;
            foreach (var itm in triItem.Childs)
            {
                //if (itm.Name.Equals("-"))
                //{
                //    item.DropDownItems.Add(new ToolStripSeparator());
                //    continue;
                //}
                //var toolTrip = new item. Node {Tag = itm, Name = itm.Key, Text = itm.Name};
                //if (!String.IsNullOrEmpty(itm.Image))
                //{
                //    string path = string.Format("{0}\\{1}", _iconPath, itm.Image);
                //    toolTrip.Image = System.Drawing.Image.FromFile(path);
                //}

                //if (itm.IsShowToolBar) _toolBarItem.Add(itm);

                //if (!String.IsNullOrEmpty(itm.ShortKey)) toolTrip.ShortcutKeys = itm.GetKey();
                //toolTrip.Click += ToolTripClick;
                //item.DropDownItems.Add(toolTrip);
                //LoadMenuItem(toolTrip);

                var childNode = new TreeNode(itm.Name);
                childNode.Name = itm.Key;
                GetNote(childNode, itm);
                item.Nodes.Add(childNode);
            }
             */
        }

        private void tree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            var item = new MenuItemClickedEventArgs { Key = node.Name, InvokeKey = String.Empty};
            this.MenuItemClicked(sender, item);
        }

        private void GetNote(TreeNode node, TopMenuItem item) {
            if (item == null) return;
            if (item.Childs.Count == 0) return;
            foreach (var child in item.Childs) {
                var childNode = new TreeNode(child.Name);
                childNode.Name = child.Key;
                GetNote(childNode, child);
                node.Nodes.Add(childNode);
            }
        }

        /// <summary>
        /// Handles the Click event of the toolTrip control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ToolTripClick(object sender, EventArgs e)
        {
            if (this.MenuItemClicked == null) return;
            var menuItem = (ToolStripMenuItem) sender;
            var topItem = (TopMenuItem) menuItem.Tag;

            //var pro = sender.GetType().GetProperty("Name");
            //var name = pro.GetValue(sender, null).ToString();
            var item = new MenuItemClickedEventArgs { Key = topItem.Key, InvokeKey = topItem .InvokeKey};
            this.MenuItemClicked(sender, item);
        }

        /// <summary>
        /// Gets the menu item by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public TopMenuItem GetMenuItemByKey(string key)
        {
            return null;
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get { return 0; }
        }

        /// <summary>
        /// Sets the config file.
        /// </summary>
        /// <value>The config file.</value>
        public string ConfigFile
        {
            set
            {
                this._configFile = value;
                LoadConfigFile();
            }
        }
    }
}
