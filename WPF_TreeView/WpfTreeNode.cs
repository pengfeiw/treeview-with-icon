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
            get { return _buttonRight; }
            set { _buttonRight = value; }
        }
        private bool _buttonRight = false;  //右边是否有按钮
        public WpfTreeNode()
        {
            
        }
    }
}
