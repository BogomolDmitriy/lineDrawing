using lineDrawing.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace lineDrawing.Factory
{
    class RectangleFactory : PaintFactory
    {
        private Point _firstPoint;
        private Pen _pen;

        public RectangleFactory(Pen pen, Point firstPoint)
        {
            _pen = pen;
            _firstPoint = firstPoint;
        }
        public override Paint GetPaint()
        {
            Tools.Rectangle newRectangle = new Tools.Rectangle(_pen, _firstPoint);
            return newRectangle;
        }
    }
}
