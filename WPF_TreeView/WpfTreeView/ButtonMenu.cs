using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace WPFTreeView
{
    public class ButtonMenu
    {
        //internal List<ButtonItem> buttonItems { get { return  _buttonItems;} }
        internal ReadOnlyCollection<ButtonItem> buttonItems { get { return _buttonItems.AsReadOnly(); } }
        private List<ButtonItem> _buttonItems = new List<ButtonItem>();

        private WpfTreeView _treeView = null;
        public WpfTreeView treeView { get { return _treeView; } }

        public ButtonMenu(WpfTreeView treeView)
        {
            this._buttonItems = new List<ButtonItem>();
            this._treeView = treeView;
        }

        public ButtonMenu(WpfTreeView treeView, List<ButtonItem> buttons)
        {
            this._buttonItems = buttons;
            foreach (ButtonItem bi in buttonItems)
            {
                bi._parent = this;
            }
            this._treeView = treeView;
        }

        public void AddButtonItems(Image image)
        {
            ButtonItem item = new ButtonItem(image);
            item._parent = this;
            this._buttonItems.Add(item);
        }

        public void AddButtonItems(Image image, ButtonItemClickEventHandler clickEvent)
        {
            ButtonItem item = new ButtonItem(image, clickEvent);
            item._parent = this;
            this._buttonItems.Add(item);
        }

        public void AddButtonItems(ButtonItem btnItem)
        {
            btnItem._parent = this;
            this._buttonItems.Add(btnItem);
        }
        public void AddRange(List<ButtonItem> items)
        {
            foreach (ButtonItem item in items)
                item._parent = this;
            this._buttonItems.AddRange(items);
        }
    }

    public class ButtonItem
    {
        public Image image;
        public string tip = "";
        public ButtonMenu parent { get { return _parent; } }

        internal ButtonMenu _parent = null;

        internal bool _mouseHover = false;

        public ButtonItemClickEventHandler clickEvent;

        public ButtonItemShowTipHandler showTipEvent;

        public ButtonItem(Image image)
        {
            this.image = image;
            clickEvent += new ButtonItemClickEventHandler(defaultListener);
        }

        public ButtonItem(Image image, string tip, ButtonItemClickEventHandler onClick)
        {
            this.tip = tip;
            this.image = image;
            clickEvent += new ButtonItemClickEventHandler(defaultListener);
            clickEvent += onClick;
        }

        public ButtonItem(Image image, ButtonItemClickEventHandler onClick)
        {
            this.tip = tip;
            this.image = image;
            clickEvent += new ButtonItemClickEventHandler(defaultListener);
            clickEvent += onClick;
        }

        private void defaultListener(ButtonItemClickEventArgs e)
        {
            if (this.parent != null)

                if (this.parent.treeView != null)
                {
                    this.parent.treeView.SelectedNode = e.Node;
                }
        }

    }
}
