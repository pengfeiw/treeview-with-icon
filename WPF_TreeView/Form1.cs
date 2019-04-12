using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WPF_TreeView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.wpfTreeView1.Nodes.Add(new WpfTreeNode("节点1", true));
            this.wpfTreeView1.Nodes.Add(new WpfTreeNode("节点2", true));

            this.wpfTreeView1.Nodes.Add(new WpfTreeNode("节点3", false));
        }
    }
}
