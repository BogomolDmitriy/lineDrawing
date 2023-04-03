using lineDrawing.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lineDrawing
{
    public class Line : Paint
    {
        Point _moovPoint;
        public Line(Pen pen, Point firstPoint) : base(pen, firstPoint)
        {
            _moovPoint = firstPoint;
        }

        public override void MouseMove(Point point)
        {
            _moovPoint = point;
        }

        public override bool MouseUp()
        {
            return _firstPoint != _moovPoint;
        }

        public override void Prerender(ref PaintEventArgs e)
        {
            e.Graphics.DrawLine(_pen, _firstPoint, _moovPoint);
        }

        public override void Draw(ref Graphics graphics)
        {
            graphics.DrawLine(_pen, _firstPoint, _moovPoint );
        }
    }
}
