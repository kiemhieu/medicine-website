using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBCustomAction
{
    public partial class LogShow : Form
    {
        public LogShow(String content)
        {
            InitializeComponent();
            this.richTextBox1.Text = content;
        }
    }
}
