using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace WPF_TreeView
{
    internal class WpfTreeNode : TreeNode
    {
        [Description("BtnRight"), Category("Data")]
        public bool ButtonRight
        {
            get { return isDrawButton ? _buttonRight : false; }
        }
        private bool isDrawButton = false;
        private bool _buttonRight = false;  //右边是否有按钮
        private bool _mouseHover = false;

        public bool mouseHover { get { return _mouseHover; } }

        public void mouseEnter()
        {
            _mouseHover = true;
            MouseEnterEvent(new TreeNodeMouseEnterEventArgs(this));
        }

        public void newBtnClick()
        {
            newBtnClickEvent(new TreeNodeNewBtnClickEventArgs(this));
        }
        public void openBtnClick()
        {
            openBtnClickEvent(new TreeNodeOpenBtnClickEventArgs(this));
        }

        public void mouseLeave()
        {
            _mouseHover = false;
            MouseLeaveEvent(new TreeNodeMouseLeaveEventArgs(this));
        }

        public delegate void TreeNodeMouseEnterEventHandler(TreeNodeMouseEnterEventArgs e);
        public delegate void TreeNodeMouseLeaveEventHandler(TreeNodeMouseLeaveEventArgs e);
        public event TreeNodeMouseLeaveEventHandler MouseLeaveEvent;
        public event TreeNodeMouseEnterEventHandler MouseEnterEvent;

        public delegate void newBtnClickEventHandler(TreeNodeNewBtnClickEventArgs e);
        public event newBtnClickEventHandler newBtnClickEvent;
        public delegate void openBtnClickEventHandler(TreeNodeOpenBtnClickEventArgs e);
        public event openBtnClickEventHandler openBtnClickEvent;

        public WpfTreeNode(string text, bool isDrawButton) : base(text)
        {
            this.isDrawButton = isDrawButton;
            MouseEnterEvent += new TreeNodeMouseEnterEventHandler(MouseEnter);
            MouseLeaveEvent += new TreeNodeMouseLeaveEventHandler(MouseLeave);
        }

        private void MouseEnter(TreeNodeMouseEnterEventArgs e)
        {
            _buttonRight = true;
        }

        private void MouseLeave( TreeNodeMouseLeaveEventArgs e)
        {
            _buttonRight = false;
        }
    }
}
