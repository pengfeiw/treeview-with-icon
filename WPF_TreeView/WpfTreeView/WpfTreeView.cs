using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Collections.Generic;

namespace WPFTreeView
{
    public class WpfTreeView : TreeView
    {
        private const int btnToText = 15;
        private const int buttonDis = 10;

        const int buttonHeight = 16;
        const int buttonWidth = 16;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public WpfTreeView()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            ShowLines = true;
            FullRowSelect = true;
            ItemHeight = 20;
            DrawMode = TreeViewDrawMode.OwnerDrawText;
            this.MouseMove += new MouseEventHandler(MouseMoveListener);
        }

        public WpfTreeNode AddWPFTreeNode(string text, ButtonMenu buttons)
        {
            WpfTreeNode node = new WpfTreeNode(text, buttons);
            this.Nodes.Add(node);
            return node;
        }

        public WpfTreeNode AddWPFTreeNode(string text)
        {
            WpfTreeNode node = new WpfTreeNode(text);
            this.Nodes.Add(node);
            return node;
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            Font nodeFont = e.Node.NodeFont == null ? this.Font : e.Node.NodeFont;
            int fontHeight = nodeFont.Height;
            e.Graphics.DrawString(e.Node.Text, nodeFont, new SolidBrush(this.ForeColor), new Point(e.Node.Bounds.Location.X, e.Node.Bounds.Location.Y + e.Node.Bounds.Height / 2 - fontHeight / 2));

            WpfTreeNode customNode = e.Node as WpfTreeNode;
            if (customNode != null && customNode.ButtonRight == true)
            {
                Graphics graphics = e.Graphics;

                for (int i = 0; i < customNode.buttonMenu.buttonItems.Count; i++)
                {
                    Rectangle btnBounds = getBtnBoundsOfNode(customNode, i);
                    Image image = getBtnImageOfNode(customNode, i);
                    graphics.DrawImage(image, btnBounds);

                    //Draw tip
                    if (customNode.buttonMenu.buttonItems[i]._mouseHover)
                    {
                        string tipStr = customNode.buttonMenu.buttonItems[i].tip;
                        if (tipStr != null && tipStr != "")
                        {
                            Brush brush1 = new SolidBrush(Color.White);
                            Brush brush2 = new SolidBrush(Color.Gray);
                            Pen pen = new Pen(Color.FromArgb(197, 197, 197));
                            Font font = new Font("微软雅黑", 10);

                            Rectangle lastBtnBounds = getBtnBoundsOfNode(customNode, customNode.buttonMenu.buttonItems.Count - 1);

                            Point textLocation = new Point(lastBtnBounds.Location.X + lastBtnBounds.Width, lastBtnBounds.Location.Y - 30);
                            SizeF textSize = graphics.MeasureString(tipStr, font);

                            PointF location = new PointF(textLocation.X - 3, textLocation.Y - 2);

                            RectangleF rect = new RectangleF(location, new SizeF(textSize.Width + 6, textSize.Height + 4));
                            graphics.FillRectangle(brush1, rect);
                            graphics.DrawRectangle(pen, rect.Location.X, rect.Location.Y, rect.Width, rect.Height);
                            graphics.DrawString(tipStr, font, brush2, textLocation);
                        }
                    }
                }
            }
        }

        private Rectangle getNodeBounds(TreeNode node)
        {
            return new Rectangle(node.Bounds.Location, new Size(this.Width, node.Bounds.Height));
        }

        private Rectangle getNewBtnBoundsOfNode(TreeNode node)
        {
            Rectangle newBtnBounds = new Rectangle(node.Bounds.X + node.Bounds.Width + btnToText, (node.Bounds.Y + node.Bounds.Height / 2 - buttonHeight / 2), buttonWidth, buttonHeight);
            return newBtnBounds;
        }
        private Rectangle getOpenBtnBoudnsOfNode(TreeNode node)
        {
            Rectangle newBtnBounds = getNewBtnBoundsOfNode(node);
            Rectangle openBtnBounds = new Rectangle(newBtnBounds.X + newBtnBounds.Width + buttonDis, (newBtnBounds.Y + newBtnBounds.Height / 2 - buttonHeight / 2), buttonWidth, buttonHeight);
            return openBtnBounds;
        }

        private Rectangle getBtnBoundsOfNode(TreeNode node, int btnIndex)
        {
            Rectangle btnBounds = new Rectangle(node.Bounds.X + node.Bounds.Width + btnToText + btnIndex * (buttonWidth + buttonDis), (node.Bounds.Y + node.Bounds.Height / 2 - buttonHeight / 2), buttonWidth, buttonHeight);
            return btnBounds;
        }

        private Image getBtnImageOfNode(WpfTreeNode node, int btnIndex)
        {
            Image image = node.buttonMenu.buttonItems[btnIndex].image;
            return image;
        }

        private void MouseMoveListener(object sender, MouseEventArgs e)
        {
            List<TreeNode> nodes = this.GetAllNodes();
            foreach (TreeNode node in nodes)
            {
                WpfTreeNode customTreeNode = node as WpfTreeNode;
                if (customTreeNode != null)
                {
                    Rectangle nodeBounds = getNodeBounds(customTreeNode);
                    if (e.Location.X >= nodeBounds.X && e.Location.X <= nodeBounds.X + nodeBounds.Width && e.Location.Y >= nodeBounds.Y && e.Location.Y <= nodeBounds.Y + nodeBounds.Height)
                    {
                        //Whether mouse is hover on the button
                        foreach (ButtonItem item in customTreeNode.buttonMenu.buttonItems)
                            item._mouseHover = false;
                        for (int i = 0; i < customTreeNode.buttonMenu.buttonItems.Count; i++)
                        {
                            Rectangle btnBounds = getBtnBoundsOfNode(customTreeNode, i);
                            if (btnBounds.Contains(e.Location))
                                customTreeNode.buttonMenu.buttonItems[i]._mouseHover = true;
                        }

                        if (customTreeNode.mouseHover == false)
                        {
                            customTreeNode.mouseEnter();
                        }
                    }
                    else
                    {
                        if (customTreeNode.mouseHover == true)
                        {
                            customTreeNode.mouseLeave();
                        }
                    }

                    this.Invalidate();
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            WpfTreeNode tnode = GetNodeAt(e.Location) as WpfTreeNode;
            if (tnode == null) return;

            for (int i = 0; i < tnode.buttonMenu.buttonItems.Count; i++)
            {
                Rectangle btnBounds = getBtnBoundsOfNode(tnode, i);
                if (btnBounds.Contains(e.Location))
                {
                    tnode.BtnClick(i);
                    break;
                }
            }
        }

        private List<TreeNode> GetAllNodes(TreeNode rootNode)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            nodes.Add(rootNode);
            foreach (TreeNode node in rootNode.Nodes)
            {
                nodes.AddRange(GetAllNodes(node));
            }
            return nodes;
        }

        public List<TreeNode> GetAllNodes()
        {
            List<TreeNode> nodes = new List<TreeNode>();
            foreach (TreeNode node in this.Nodes)
            {
                nodes.AddRange(GetAllNodes(node));
            }
            return nodes;
        }
    }
}
