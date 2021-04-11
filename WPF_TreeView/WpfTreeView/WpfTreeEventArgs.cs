using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace WPFTreeView
{
    public delegate void ButtonItemClickEventHandler(ButtonItemClickEventArgs e);
    public delegate void ButtonItemShowTipHandler(ButtonItemShowTipEventArgs e);
    public delegate void TreeNodeMouseEnterEventHandler(TreeNodeMouseEnterEventArgs e);
    public delegate void TreeNodeMouseLeaveEventHandler(TreeNodeMouseLeaveEventArgs e);

    public class TreeNodeMouseLeaveEventArgs : EventArgs
    {
        public TreeNodeMouseLeaveEventArgs(TreeNode node)
        {
            this._node = node;
        }

        public TreeNode Node { get { return _node; } }

        private TreeNode _node;
    }
    public class TreeNodeMouseEnterEventArgs : EventArgs
    {
        public TreeNodeMouseEnterEventArgs(TreeNode node)
        {
            this._node = node;
        }

        public TreeNode Node { get { return _node; } }

        private TreeNode _node;
    }
    public class ButtonItemClickEventArgs : EventArgs
    {
        public ButtonItemClickEventArgs(TreeNode node)
        {
            this._node = node;
        }
        public TreeNode Node { get { return _node; } }
        private TreeNode _node;
    }
    public class ButtonItemShowTipEventArgs: EventArgs
    {
         public ButtonItemShowTipEventArgs(TreeNode node)
        {
            this._node = node;
        }
        public TreeNode Node { get { return _node; } }
        private TreeNode _node;
    }

}
