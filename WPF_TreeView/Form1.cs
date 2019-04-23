using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPFTreeView;

namespace WPFTreeView
{
    public partial class Form1 : Form
    {
        Image openImage = Resource1.openFile;
        Image saveImage = Resource1.save;
        Image deleteImage = Resource1.delete;
        Image newImage = Resource1.newFile;
        Image copyImage = Resource1.copy;
        public Form1()
        {
            InitializeComponent();

            ButtonMenu bm1 = new ButtonMenu(this.wpfTreeView1);
            ButtonMenu bm2 = new ButtonMenu(this.wpfTreeView1);

            bm1.AddButtonItems(new ButtonItem(newImage, "New File", new ButtonItemClickEventHandler(newFileClick)));
            bm1.AddButtonItems(new ButtonItem(openImage, "Open File", new ButtonItemClickEventHandler(openFileClick)));
            bm2.AddButtonItems(new ButtonItem(saveImage, "Save File", new ButtonItemClickEventHandler(saveFileClick)));
            bm2.AddButtonItems(new ButtonItem(deleteImage, "Delete File", new ButtonItemClickEventHandler(deleteFileClick)));
            bm2.AddButtonItems(new ButtonItem(copyImage, "Save File", new ButtonItemClickEventHandler(copyFileClick)));
            
            WPFTreeNode root = this.wpfTreeView1.AddWPFTreeNode("WpfTreeView Demo");
            WPFTreeNode child1 =  root.AddWPFTreeNode("节点1", bm1);
            WPFTreeNode child1_1 = child1.AddWPFTreeNode("节点1-1", bm2);
            child1_1.AddWPFTreeNode("1");
            child1_1.AddWPFTreeNode("2");
            child1_1.AddWPFTreeNode("3");
            child1.AddWPFTreeNode("节点1-2", bm2);
            WPFTreeNode child2 =  root.AddWPFTreeNode("节点2", bm1);
            child2.AddWPFTreeNode("节点2-1", bm2);
            WPFTreeNode child3 =  root.AddWPFTreeNode("节点3", bm1);
            child3.AddWPFTreeNode("节点2-1", bm2);

            this.wpfTreeView1.ExpandAll();
        }

        private void newFileClick(ButtonItemClickEventArgs e)
        {
            MessageBox.Show(e.Node.Text + ":New File.");
        }

        private void openFileClick(ButtonItemClickEventArgs e)
        {
            MessageBox.Show(e.Node.Text + ":Open File.");
        }

        private void saveFileClick(ButtonItemClickEventArgs e)
        {
            MessageBox.Show(e.Node.Text + ":Save File.");
        }

        private void deleteFileClick(ButtonItemClickEventArgs e)
        {
            MessageBox.Show(e.Node.Text + ":Delete File.");
        }

        private void copyFileClick(ButtonItemClickEventArgs e)
        {
            MessageBox.Show(e.Node.Text + ":Copy File.");
        }
    }
}
