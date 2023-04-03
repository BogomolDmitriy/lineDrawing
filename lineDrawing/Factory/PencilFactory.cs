using lineDrawing.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace lineDrawing.Factory
{
    class PencilFactory : PaintFactory
    {
        private Point _firstPoint;
        private Pen _pen;

        public PencilFactory(Pen pen, Point firstPoint)
        {
            _pen = pen;
            _firstPoint = firstPoint;
        }
        public override Paint GetPaint()
        {
            Pencil newPencil = new Pencil(_pen, _firstPoint );
            return newPencil;
        }
    }
}
