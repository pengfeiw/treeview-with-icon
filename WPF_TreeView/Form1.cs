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
            this.wpfTreeView1.Nodes.Add(new WpfTreeNode("节点3", true));
            this.wpfTreeView1.Nodes.Add(new WpfTreeNode("节点4", true));

            this.wpfTreeView1.Nodes[0].Nodes.Add(new WpfTreeNode("子节点0", false));
            this.wpfTreeView1.Nodes[1].Nodes.Add(new WpfTreeNode("子节点1", false));
            this.wpfTreeView1.Nodes[2].Nodes.Add(new WpfTreeNode("子节点2", false));
            this.wpfTreeView1.Nodes[3].Nodes.Add(new WpfTreeNode("子节点3", false));
            this.wpfTreeView1.Nodes[3].Nodes.Add(new WpfTreeNode("子节点4", false));

            foreach(WpfTreeNode node in this.wpfTreeView1.Nodes)
            {
                if (node != null)
                {
                    node.newBtnClickEvent += new WpfTreeNode.newBtnClickEventHandler(newBtnListener);
                    node.openBtnClickEvent += new WpfTreeNode.openBtnClickEventHandler(openBtnListener);
                }
            }
        }

        private void newBtnListener(TreeNodeNewBtnClickEventArgs e)
        {
            MessageBox.Show(e.Node.Text + ":New File");
        }
        private void openBtnListener(TreeNodeOpenBtnClickEventArgs e)
        {
            MessageBox.Show(e.Node.Text + ":Open File");
        }
    }
}
