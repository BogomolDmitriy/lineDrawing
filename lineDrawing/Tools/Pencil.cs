using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lineDrawing.Tools
{
    class Pencil : Paint
    {
        private List<Point> pencilPoint = new List<Point> { };

        public Pencil(Pen pen, Point firstPoint) : base(pen, firstPoint)
        {
            pencilPoint.Add(firstPoint);
        }
        public override void Draw(ref Graphics graphics)
        {
            if (pencilPoint.Count > 1)
            {
                Point countPoint = pencilPoint[0];
                for (int i = 1; i < pencilPoint.Count; i++)
                {
                    graphics.DrawLine(_pen, countPoint, pencilPoint[i]);
                    countPoint = pencilPoint[i];
                }
            }
        }

        public override void MouseMove(Point point)
        {
            if (pencilPoint.Last() != point)
            {
                pencilPoint.Add(point);
            }
        }

        public override bool MouseUp()
        {
            return pencilPoint.Count > 1;
        }

        public override void Prerender(ref PaintEventArgs e)
        {
            //e.Graphics.DrawLine(_pen, pencilPoint[pencilPoint.Count - 1], pencilPoint.Last());
            if (pencilPoint.Count>1)
            {
                Point countPoint = pencilPoint[0];
                for (int i = 1; i < pencilPoint.Count; i++)
                {
                    e.Graphics.DrawLine(_pen, countPoint, pencilPoint[i]);
                    countPoint = pencilPoint[i];
                }
            }
        }
    }
}
