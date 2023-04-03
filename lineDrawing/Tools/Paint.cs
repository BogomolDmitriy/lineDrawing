using lineDrawing.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lineDrawing
{
    public abstract class Paint 
    {
        public Pen _pen;
        protected bool isClicked;
        public Point _firstPoint;
        //public Point _moovPoint;
        public bool ClickFlag { get; protected set; }

        public Paint(Pen pen, Point firstPoint)
        {
            ClickFlag = true;
            isClicked = false;
            _pen = pen;
            _firstPoint = firstPoint;
        }

        //public abstract void MouseDown(Point point);

        public abstract void MouseMove(Point point);
        public abstract bool MouseUp();
        public abstract void Prerender(ref PaintEventArgs e);
        public abstract void Draw( ref Graphics graphics);
    }
}
