using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TX_Widget
{
    /// <summary>
    /// 仿搜狗设置向导的Tabcontrol.
    /// 方向水平，tab在顶部。
    /// </summary>
    public class BWHoriTabcontrol : TabControl
    {
        public BWHoriTabcontrol()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            DoubleBuffered = true;
            this.ItemSize = new Size(20, 25);
            SizeMode = TabSizeMode.Fixed;
            this.SelectedIndexChanged += new EventHandler(BWHoriTabcontrol_SelectedIndexChanged);
        }

        void BWHoriTabcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.Invalidate();
        }

        protected override void CreateHandle()
        {
            base.CreateHandle();
            Alignment = TabAlignment.Top;  //强制tab在上方。
        }

        public Pen ToPen(Color color)
        {
            return new Pen(color);
        }
        public Brush ToBrush(Color color)
        {
            return new SolidBrush(color);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //m_tabPageColor = Color.FromArgb(255, 255, 255);
            //m_selectedTabColor = new Color[] { Color.FromArgb(27, 145, 236), Color.FromArgb(27, 145, 236), Color.FromArgb(27, 145, 236) };
            //m_unSelTabColor = Color.FromArgb(235, 235, 236);
            //m_fontColor = Color.Black;
            //m_selFontColor = Color.White;


            Color pageColor = Color.FromArgb(255, 255, 255);
            Color tabUnSelColor = Color.FromArgb(235, 235, 236);
            Color tabSelColor = Color.FromArgb(27, 145, 236);
            Color fontColor = Color.Black;
            Color selFontColor = Color.White;
            Bitmap B = new Bitmap(Width, Height);
            Graphics G = Graphics.FromImage(B);   //在B上绘图。
            G.SmoothingMode = SmoothingMode.HighQuality;  //设置绘图曲线光滑
            //G.PixelOffsetMode = PixelOffsetMode.HighQuality; //高像素偏移质量
            try
            {
                SelectedTab.BackColor = pageColor;
            }
            catch
            {

            }
            G.Clear(pageColor);
            G.FillRectangle(new SolidBrush(tabUnSelColor), new Rectangle(0, 0, Width, ItemSize.Height));  //tab栏

            //绘制page边框线。
            Pen pen1 = ToPen(Color.White);
            G.DrawLine(pen1, new Point(0, ItemSize.Height + 1), new Point(Width, ItemSize.Height + 1)); //上边界线
            G.DrawLine(pen1, new Point(0, Height - 1), new Point(Width, Height - 1));   //下边界线
            G.DrawLine(pen1, new Point(0, ItemSize.Height + 1), new Point(0, Height - 1)); //左
            G.DrawLine(pen1, new Point(Width, ItemSize.Height + 1), new Point(Width, Height - 1)); //右

            //绘制Tab
            for (int i = 0; i <= TabCount - 1; i++)
            {
                Color tabColor = i == this.SelectedIndex ? tabSelColor : tabUnSelColor;
                if (i == 0)
                {
                    Point p1 = GetTabRect(i).Location;
                    Point p2 = new Point(GetTabRect(i).Location.X + ItemSize.Width - 10, GetTabRect(i).Location.Y);
                    Point p3 = new Point(GetTabRect(i).Location.X + ItemSize.Width, GetTabRect(i).Location.Y + ItemSize.Height / 2);
                    //Point p4 = new Point(p2.X, GetTabRect(i).Y + ItemSize.Height - 1);
                    Point p4 = new Point(p2.X, GetTabRect(i).Y + ItemSize.Height);
                    Point p5 = new Point(p1.X, p4.Y);
                    Point p6 = p1;
                    G.DrawPolygon(pen1, new Point[] { p1, p2, p3, p4, p5, p6 });
                    Point p11 = new Point(p1.X + 1, p1.Y + 1);
                    Point p22 = new Point(p2.X, p2.Y + 1);
                    Point p33 = new Point(p3.X - 1, p3.Y);
                    Point p44 = new Point(p4.X, p4.Y - 1);
                    Point p55 = new Point(p5.X + 1, p5.Y - 1);
                    Point p66 = p11;
                    G.FillPolygon(new SolidBrush(tabColor), new Point[] { p11, p22, p33, p44, p55, p66 });

                    //绘制文字
                    if(i == SelectedIndex)
                        G.DrawString(TabPages[i].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold), new SolidBrush(selFontColor), new RectangleF(p1, new SizeF(p2.X - p1.X, p4.Y - p2.Y)), new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
                    else
                        G.DrawString(TabPages[i].Text, Font, new SolidBrush(fontColor), new RectangleF(p1, new SizeF(p2.X - p1.X, p4.Y - p2.Y)), new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
                        
                }
                else if(i != TabCount - 1)
                {
                    Point p1 = new Point(GetTabRect(i - 1).Location.X + ItemSize.Width - 10 + 1, GetTabRect(i - 1).Location.Y);
                    Point p2 = new Point(GetTabRect(i).Location.X + ItemSize.Width - 10, GetTabRect(i).Location.Y);
                    Point p3 = new Point(GetTabRect(i).Location.X + ItemSize.Width, GetTabRect(i).Location.Y + ItemSize.Height / 2);
                    Point p4 = new Point(p2.X, GetTabRect(i).Y + ItemSize.Height);
                    Point p5 = new Point(p1.X, p4.Y);
                    Point p6 = new Point(GetTabRect(i - 1).Location.X + ItemSize.Width + 1, GetTabRect(i - 1).Location.Y + ItemSize.Height / 2);
                    Point p7 = p1;

                    G.DrawPolygon(pen1, new Point[] { p1, p2, p3, p4, p5, p6, p7 });
                    Point p11 = new Point(p1.X + 1, p1.Y + 1);
                    Point p22 = new Point(p2.X, p2.Y + 1);
                    //Point p22 = new Point(p2.X - 1, p2.Y + 1);
                    Point p33 = new Point(p3.X - 1, p3.Y);
                    Point p44 = new Point(p4.X, p4.Y - 1);
                    //Point p44 = new Point(p4.X - 1, p4.Y - 1);
                    Point p55 = new Point(p5.X + 1, p5.Y - 1);
                    Point p66 = new Point(p6.X + 1, p6.Y);
                    Point p77 = p11;
                    G.FillPolygon(new SolidBrush(tabColor), new Point[] { p11, p22, p33, p44, p55, p66, p77 });
               
                    //绘制文字
                    if (i == SelectedIndex)
                        G.DrawString(TabPages[i].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold), new SolidBrush(selFontColor), new RectangleF(new PointF(p6.X, p1.Y), new SizeF(p2.X - p6.X, p4.Y - p2.Y)), new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
                    else
                        G.DrawString(TabPages[i].Text, Font, new SolidBrush(fontColor), new RectangleF(new PointF(p6.X, p1.Y), new SizeF(p2.X - p6.X, p4.Y - p2.Y)), new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
                }
                else
                {
                    Point p1 = new Point(GetTabRect(i - 1).Location.X + ItemSize.Width - 10 + 1, GetTabRect(i - 1).Location.Y);
                    Point p2 = new Point(this.Location.X + this.Width, p1.Y);
                    Point p3 = new Point(p2.X, p1.Y + this.ItemSize.Height);
                    Point p4 = new Point(p1.X, p3.Y);
                    Point p5 = new Point(GetTabRect(i - 1).Location.X + ItemSize.Width + 1, GetTabRect(i - 1).Location.Y + ItemSize.Height / 2);
                    Point p6 = p1;
                    G.DrawPolygon(pen1, new Point[] { p1, p2, p3, p4, p5, p6 });

                    Point p11 = new Point(p1.X + 1, p1.Y + 1);
                    Point p22 = new Point(p2.X, p2.Y + 1);
                    Point p33 = new Point(p3.X, p3.Y - 1);
                    Point p44 = new Point(p4.X + 1, p4.Y - 1);
                    Point p55 = new Point(p5.X + 1, p5.Y);
                    Point p66 = p11;
                    G.FillPolygon(new SolidBrush(tabColor), new Point[] { p11, p22, p33, p44, p55, p66 });

                    //绘制文字
                    if (i == SelectedIndex)
                        G.DrawString(TabPages[i].Text, new Font(Font.FontFamily, Font.Size, FontStyle.Bold), new SolidBrush(selFontColor), new RectangleF(new PointF(p5.X, p1.Y), new SizeF(p2.X - p5.X, p4.Y - p2.Y)), new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
                    else
                        G.DrawString(TabPages[i].Text, Font, new SolidBrush(fontColor), new RectangleF(new PointF(p5.X, p1.Y), new SizeF(p2.X - p5.X, p4.Y - p2.Y)), new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });

                }
            }


            e.Graphics.DrawImage((Image)B.Clone(), 0, 0);//将B绘制给控件。
            G.Dispose();
            B.Dispose();
        }
    }
}
