using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class PaintPanal : UserControl
    {
        public PaintPanal()
        {
            InitializeComponent();
        }
        Point[] lastPaint;

        Pen myPen = new Pen(new SolidBrush(Color.Blue), 0.5f);
        public void DrawPoints(Pen _pen,Point[] _points)
        {
            if (_points != null)
            {
                lastPaint = _points;
            }
            else if (lastPaint == null)
                return;

            //lastPaint = _points;
            Graphics g = this.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            for (int i = 0; i < lastPaint.Length; i++)
            {
                Rectangle rg = new Rectangle(lastPaint[i].X - 2, lastPaint[i].Y - 2, 4, 4);
                g.DrawEllipse(_pen, rg);
                g.FillEllipse(new SolidBrush(_pen.Color), rg);
                g.Flush();
            }

            g.Dispose();
        }

        public void DrawLines(Pen _pen, Point[] _points)
        {
            if (_points != null)
            {
                lastPaint = _points;
            }
            else if (lastPaint == null)
                return;

            Graphics g = this.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawCurve(_pen, lastPaint);
            g.Dispose();
        }

        private void PaintPanal_Paint(object sender, PaintEventArgs e)
        {
            //if (lastPaint != null)
            //{
            //    DrawPoints(null);
            //    DrawLines(null);
            //}

            Pen myGrid = new Pen(Color.FromArgb(30, 30, 30), 1);
            Graphics g = this.CreateGraphics();
            //横向
            for (int i = 0; i <= this.Size.Height / 50; i++)
            {
                g.DrawLine(myGrid, new Point(0, i * 50), new Point(this.Size.Width,i * 50));
            }
            //纵向
            for (int i = 0; i <= this.Size.Width / 50; i++)
            {
                g.DrawLine(myGrid, new Point(i * 50, 0), new Point(i * 50,this.Size.Height));
            }
        }
    }
}
