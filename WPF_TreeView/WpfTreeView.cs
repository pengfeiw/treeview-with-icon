using System;
using System.Drawing;
using System.Windows.Forms;

namespace WPF_TreeView
{
    public class WpfTreeView : TreeView
    {
        private Rectangle buttonRect = new Rectangle(80, 2, 50, 26);
        public WpfTreeView()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            ShowLines = true;
            FullRowSelect = true;
            ItemHeight = 30;
            DrawMode = TreeViewDrawMode.OwnerDrawAll;
            this.MouseMove += new MouseEventHandler(MouseMoveListener);
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            Font nodeFont = e.Node.NodeFont == null ? this.Font: e.Node.NodeFont;
            e.Graphics.DrawString(e.Node.Text, nodeFont, new SolidBrush(this.ForeColor), e.Node.Bounds.Location);

            WpfTreeNode customNode = e.Node as WpfTreeNode;
            e.Graphics.DrawRectangle(new Pen(Color.Red), e.Node.Bounds);
            if (customNode != null && customNode.ButtonRight == true)
            {
                //这里画button.
                ButtonRenderer.DrawButton(e.Graphics, new Rectangle(e.Node.Bounds.Location + new Size(buttonRect.Location), buttonRect.Size), "btn", this.Font, true, System.Windows.Forms.VisualStyles.PushButtonState.Normal);
            }
        }

        //由mouseMove确定是否离开TreeNode.
        private void MouseMoveListener(object sender, MouseEventArgs e)
        {
            foreach(TreeNode node in this.Nodes)
            {
                WpfTreeNode customTreeNode = node as WpfTreeNode;
                if (customTreeNode != null)
                {
                    Rectangle nodeBounds = node.Bounds;
                    if (e.Location.X >= nodeBounds.X && e.Location.X <= nodeBounds.X + nodeBounds.Width && e.Location.Y >= nodeBounds.Y && e.Location.Y <= nodeBounds.Y +nodeBounds.Height)
                    {
                        if (customTreeNode.mouseHover == false)
                        {
                            customTreeNode.mouseEnter();
                            this.Invalidate();
                        }
                    }
                    else
                    {
                        if (customTreeNode.mouseHover == true)
                        {
                            customTreeNode.mouseLeave();
                            this.Invalidate();
                        }
                    }
                }
            }
        }

        private void renderButton()
        {

        }
    }
}
