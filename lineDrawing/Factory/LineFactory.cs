using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using lineDrawing.Factory;


namespace lineDrawing.Factory
{
    class LineFactory : PaintFactory
    {
        private Point _firstPoint;
        private Pen _pen;

        public LineFactory(Pen pen, Point firstPoint)
        {
            _pen = pen;
            _firstPoint = firstPoint;
        }
        public override Paint GetPaint()
        {
            Line newLine = new Line(_pen, _firstPoint);
            return newLine;

        }
    }
}
