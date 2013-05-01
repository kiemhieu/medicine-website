using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Medical.Forms.TreeMenu;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            var menu = new TreeMenu {MenuItems = new List<TreeMenuItem>()};

            var item = new TreeMenuItem { No = 1, Title = "Main Item 1", Childs = new List<TreeMenuItem>() };
            item.Childs.Add(new TreeMenuItem { No = 1, Title = "Item 1", Key = "", ImageIndex = 1, Role = "0,1,2", Description = "" });
            item.Childs.Add(new TreeMenuItem { No = 2, Title = "Item 2", Key = "", ImageIndex = 2, Role = "0,1,2", Description = "" });
            menu.MenuItems.Add(item);

            item = new TreeMenuItem { No = 2, Title = "Main Item 2", Childs = new List<TreeMenuItem>() };
            item.Childs.Add(new TreeMenuItem { No = 1, Title = "Item 1", Key = "", ImageIndex = 1, Role = "0,1,2", Description = "" });
            item.Childs.Add(new TreeMenuItem { No = 2, Title = "Item 2", Key = "", ImageIndex = 2, Role = "0,1,2", Description = "" });
            menu.MenuItems.Add(item);

            using (var myWriter = new StreamWriter(@"D:\\menu.xml", false))
            {

                var mySerializer = new XmlSerializer(typeof(TreeMenu));
                mySerializer.Serialize(myWriter, menu);
            }

            MessageBox.Show("Complete");
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            /*
            // Create an instance of the XmlSerializer specifying type and namespace.
            var serializer = new XmlSerializer(typeof(TreeMenu));

            // A FileStream is needed to read the XML document.
            var fs = new FileStream(@"D:\\menu.xml", FileMode.Open);
            var reader = new XmlTextReader(fs);

            // Declare an object variable of the type to be deserialized.
            var i = (TreeMenu)serializer.Deserialize(reader);
             */

            var m = Load<TreeMenu>(@"D:\\menu.xml");

            MessageBox.Show("Complete");
        }

        public T Load<T>(String path)
        {
            var serializer = new XmlSerializer(typeof(T));
            using(var fs = new FileStream(path, FileMode.Open))
            {
                var reader = new XmlTextReader(fs);
                var i = (T)serializer.Deserialize(reader);
                return i;    
            }
        }

        public void Write<T>(String path, T value)
        {
            using (var myWriter = new StreamWriter(path, false))
            {

                var mySerializer = new XmlSerializer(typeof(T));
                mySerializer.Serialize(myWriter, value);
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            var main = new TreeMenuImages();
            main.Folder = "Images";
            main.Files = new List<String>();

            main.Files.Add("aaa.png");
            Write<TreeMenuImages>(@"D:\Images.xml", main);
            MessageBox.Show("Complete");
        }
    }
}
