using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace WPFTreeView
{
    public class WpfTreeNode : TreeNode
    {
        [Description("BtnRight"), Category("Data")]
        public bool ButtonRight
        {
            get { return isDrawButton ? _buttonRight : false; }
        }

        private bool isDrawButton { get { return buttonMenu.buttonItems.Count > 0 ? true : false; } }
        private bool _buttonRight = false;  //右边是否有按钮
        private bool _mouseHover = false;
        public ButtonMenu buttonMenu { get { return _buttonMenu; } }

        private ButtonMenu _buttonMenu = new ButtonMenu(null);

        public bool mouseHover { get { return _mouseHover; } }

        public WpfTreeNode()
        {
            MouseEnterEvent += new TreeNodeMouseEnterEventHandler(MouseEnter);
            MouseLeaveEvent += new TreeNodeMouseLeaveEventHandler(MouseLeave);
        }

        public WpfTreeNode(string text)
            : base(text)
        {
            MouseEnterEvent += new TreeNodeMouseEnterEventHandler(MouseEnter);
            MouseLeaveEvent += new TreeNodeMouseLeaveEventHandler(MouseLeave);
        }

        public WpfTreeNode(string text, ButtonMenu buttonMenu)
            : base(text)
        {
            this._buttonMenu = buttonMenu;
            MouseEnterEvent += new TreeNodeMouseEnterEventHandler(MouseEnter);
            MouseLeaveEvent += new TreeNodeMouseLeaveEventHandler(MouseLeave);
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

        internal void mouseEnter()
        {
            _mouseHover = true;
            MouseEnterEvent(new TreeNodeMouseEnterEventArgs(this));
        }

        internal void BtnClick(int index)
        {
            this.buttonMenu.buttonItems[index].clickEvent(new ButtonItemClickEventArgs(this));
        }

        internal void ShowToolTip(int index)
        {
            this.buttonMenu.buttonItems[index].showTipEvent(new ButtonItemShowTipEventArgs(this));
        }

        internal void mouseLeave()
        {
            _mouseHover = false;
            MouseLeaveEvent(new TreeNodeMouseLeaveEventArgs(this));
        }

        public event TreeNodeMouseLeaveEventHandler MouseLeaveEvent;
        public event TreeNodeMouseEnterEventHandler MouseEnterEvent;

        private void MouseEnter(TreeNodeMouseEnterEventArgs e)
        {
            _buttonRight = true;
        }

        private void MouseLeave(TreeNodeMouseLeaveEventArgs e)
        {
            _buttonRight = false;
        }


    }
}
