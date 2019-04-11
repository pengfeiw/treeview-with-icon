using System;
using System.Drawing;
using System.Windows.Forms;

namespace WPF_TreeView
{
    public class WpfTreeView : TreeView
    {
        public WpfTreeView()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            ShowLines = false;
            FullRowSelect = true;
            ItemHeight = 30;
            DrawMode = TreeViewDrawMode.OwnerDrawAll;
            this.NodeMouseHover += new TreeNodeMouseHoverEventHandler(MouseHoverStatus);
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            Font nodeFont = e.Node.NodeFont == null ? this.Font: e.Node.NodeFont;
            e.Graphics.DrawString(e.Node.Text, nodeFont, new SolidBrush(this.ForeColor), e.Node.Bounds.Location);
        }

        private void MouseHoverStatus(object sender, TreeNodeMouseHoverEventArgs e)
        {
            
        }
    }
}
