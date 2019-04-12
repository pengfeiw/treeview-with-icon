using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace TX_Widget
{
    public class SetFormColor
    {
        public enum style { briefWhite, classicalBlack, jewelryBlue, floridYellow, brightRed}
        Color m_tabPageColor;
        Color[] m_selectedTabColor;// = new Color[] { Color.FromArgb(0, 122, 204), Color.FromArgb(0, 122, 204), Color.FromArgb(0, 122, 204) };  //被选中的tab是一个渐变色。
        Color m_unSelTabColor;
        Color m_fontColor;
        Color m_selFontColor;

        public Color pageColor { get { return m_tabPageColor; } }
        public Color[] selTabColor { get { return m_selectedTabColor; } }
        public Color unSelTabColor { get { return m_unSelTabColor; } }
        public Color fontColor { get { return m_fontColor; } }
        public Color selFontColor { get { return m_selFontColor; } }

        public style m_formStyle;
        public SetFormColor(style formStyle)
        {
            m_formStyle = formStyle;
            switch (m_formStyle)
            {
                case style.briefWhite:
                    m_tabPageColor = Color.FromArgb(255, 255, 255);
                    m_selectedTabColor = new Color[] { Color.FromArgb(203, 217, 236), Color.FromArgb(236, 238, 250), Color.FromArgb(234, 234, 235) };
                    m_unSelTabColor = Color.FromArgb(249, 251, 253);
                    m_fontColor = Color.Black;
                    m_selFontColor = Color.Black;
                    break;
                case style.floridYellow:
                    m_tabPageColor = Color.FromArgb(255, 255, 255);
                    m_selectedTabColor = new Color[] { Color.FromArgb(255, 120, 70), Color.FromArgb(255, 120, 70), Color.FromArgb(255, 120, 70) };
                    m_unSelTabColor = Color.FromArgb(239, 242, 246);
                    m_fontColor = Color.Black;
                    m_selFontColor = Color.White;
                    break;
                case style.classicalBlack:
                    m_tabPageColor = Color.FromArgb(255, 255, 255);
                    m_selectedTabColor = new Color[] { Color.FromArgb(0, 122, 204), Color.FromArgb(0, 122, 204), Color.FromArgb(0, 122, 204) };
                    m_unSelTabColor = Color.FromArgb(31, 31, 34);
                    m_fontColor = Color.White;
                    m_selFontColor = Color.White;
                    break;
                case style.brightRed:
                    m_tabPageColor = Color.FromArgb(255, 255, 255);
                    m_selectedTabColor = new Color[] { Color.FromArgb(198, 47, 47), Color.FromArgb(198, 47, 47), Color.FromArgb(198, 47, 47) };
                    m_unSelTabColor = Color.FromArgb(245, 245, 247);
                    m_fontColor = Color.Black;
                    m_selFontColor = Color.White;
                    break;
                case style.jewelryBlue:
                    m_tabPageColor = Color.FromArgb(255, 255, 255);
                    m_selectedTabColor = new Color[] { Color.FromArgb(27, 145, 236), Color.FromArgb(27, 145, 236), Color.FromArgb(27, 145, 236) };
                    m_unSelTabColor = Color.FromArgb(235,235,236);
                    m_fontColor = Color.Black;
                    m_selFontColor = Color.White;
                    break;
            }
        }
    }
}
