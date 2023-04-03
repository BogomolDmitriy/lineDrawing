using lineDrawing.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using lineDrawing.Factory;


namespace lineDrawing.Factory
{
    abstract class PaintFactory
    {
        public abstract Paint GetPaint();
    }
}
