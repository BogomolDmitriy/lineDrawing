using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lineDrawing.Tools
{
    class Rectangle : Paint
    {
        Point _moovPoint;


        public Rectangle(Pen pen, Point firstPoint) : base(pen, firstPoint)
        {
            _moovPoint = firstPoint;
        }

    public override void Draw(ref Graphics graphics)
        {
            graphics.DrawLine(_pen, _firstPoint.X, _firstPoint.Y, _moovPoint.X, _firstPoint.Y);
            graphics.DrawLine(_pen, _moovPoint.X, _firstPoint.Y, _moovPoint.X, _moovPoint.Y);
            graphics.DrawLine(_pen, _moovPoint.X, _moovPoint.Y, _firstPoint.X, _moovPoint.Y);
            graphics.DrawLine(_pen, _firstPoint.X, _moovPoint.Y, _firstPoint.X, _firstPoint.Y);
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
            e.Graphics.DrawLine(_pen, _firstPoint.X, _firstPoint.Y, _moovPoint.X, _firstPoint.Y);
            e.Graphics.DrawLine(_pen, _moovPoint.X, _firstPoint.Y, _moovPoint.X, _moovPoint.Y);
            e.Graphics.DrawLine(_pen, _moovPoint.X, _moovPoint.Y, _firstPoint.X, _moovPoint.Y );
            e.Graphics.DrawLine(_pen, _firstPoint.X, _moovPoint.Y, _firstPoint.X, _firstPoint.Y);
        }
    }
}
