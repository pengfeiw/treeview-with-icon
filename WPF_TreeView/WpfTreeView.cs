using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WPF_TreeView
{
    public class WpfTreeView : TreeView
    {
        private const int btnToText = 30;
        private const int buttonDis = 10;
        Image imgNew = (Image)Resource1.newFile;
        Image imgOpen = (Image)Resource1.openFile;
        const int buttonHeight = 16;
        const int buttonWidht = 16;

        private Color _btnBackgroundColor = Color.Transparent;
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
            int fontHeight = nodeFont.Height;
            //e.Graphics.DrawString(e.Node.Text, nodeFont, new SolidBrush(this.ForeColor), e.Node.Bounds.Location);
            e.Graphics.DrawString(e.Node.Text, nodeFont, new SolidBrush(this.ForeColor), new Point(e.Node.Bounds.Location.X, e.Node.Bounds.Location.Y + e.Node.Bounds.Height / 2 - fontHeight / 2));

            WpfTreeNode customNode = e.Node as WpfTreeNode;
            //e.Graphics.DrawRectangle(new Pen(Color.Red), e.Node.Bounds);
            if (customNode != null && customNode.ButtonRight == true)
            {
                Graphics graphics = e.Graphics;
                Rectangle newBtnBounds = getNewBtnBoundsOfNode(e.Node);
                Rectangle openBtnBounds = getOpenBtnBoudnsOfNode(e.Node);
                renderButton(graphics, newBtnBounds, imgNew, newBtnBounds, false, PushButtonState.Normal);
                renderButton(graphics, openBtnBounds, imgOpen, openBtnBounds, false, PushButtonState.Normal);
            }
        }

        private Rectangle getNodeBounds(TreeNode node)
        {
            return new Rectangle(node.Bounds.Location, new Size(this.Width, node.Bounds.Height));
        }

        private Rectangle getNewBtnBoundsOfNode(TreeNode node)
        {
            Rectangle newBtnBounds = new Rectangle(node.Bounds.X + node.Bounds.Width + btnToText, (node.Bounds.Y + node.Bounds.Height / 2 - buttonHeight / 2), buttonWidht, buttonHeight);
            return newBtnBounds;
        }
        private Rectangle getOpenBtnBoudnsOfNode(TreeNode node)
        {
            Rectangle newBtnBounds = getNewBtnBoundsOfNode(node);
            Rectangle openBtnBounds = new Rectangle(newBtnBounds.X + newBtnBounds.Width + buttonDis, (newBtnBounds.Y + newBtnBounds.Height / 2 - buttonHeight / 2), buttonWidht, buttonHeight);
            return openBtnBounds;
        }

        //由mouseMove确定是否离开TreeNode.
        private void MouseMoveListener(object sender, MouseEventArgs e)
        {
            foreach(TreeNode node in this.Nodes)
            {
                WpfTreeNode customTreeNode = node as WpfTreeNode;
                if (customTreeNode != null)
                {
                    Rectangle nodeBounds = getNodeBounds(customTreeNode);
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

        private void renderButton(Graphics g, Rectangle bounds, Image image, Rectangle imageBounds, bool focused, PushButtonState state)
        {
            ButtonRenderer.DrawButton(g, bounds, image, imageBounds, focused, state);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            WpfTreeNode tnode = (WpfTreeNode)GetNodeAt(e.Location);
            if (tnode == null) return;

            Rectangle newBtnBounds = getNewBtnBoundsOfNode(tnode);
            Rectangle openBtnBounds = getOpenBtnBoudnsOfNode(tnode);


            if (newBtnBounds.Contains(e.Location))
            {
                tnode.newBtnClick();
            }
            else if (openBtnBounds.Contains(e.Location))
            {
                tnode.openBtnClick();
            }
        }
    }
}
