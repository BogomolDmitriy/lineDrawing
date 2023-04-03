using lineDrawing.Factory;
using lineDrawing.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lineDrawing
{
    public partial class Form1 : Form
    {
        List<Paint> mainСollectionPaint = new List<Paint> { };
        List<Paint> deletedItemsCollectionPaint = new List<Paint> { };
        bool isClicked = false;
        Point moovPoint;
        enumTools tools;
        Color color = Color.Black;
        Paint paint;
        PaintFactory factory;
        int lineThickness;

        Bitmap map;
        Graphics graphics;

        public Form1()
        {
            InitializeComponent();
            Skren();
        }

        private void Skren()
        {
            System.Drawing.Rectangle rec = Screen.PrimaryScreen.Bounds;
            map = new Bitmap(rec.Width, rec.Height);
            graphics = Graphics.FromImage(map);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Pen toolPen = new Pen(color, lineThickness);
            toolPen.Alignment = PenAlignment.Center;

            toolPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            toolPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            switch (tools)
            {
                case enumTools.Free:
                    break;
                case enumTools.Line:
                    factory = new LineFactory(toolPen, new Point(e.X, e.Y));
                    paint = factory.GetPaint();
                    isClicked = true;
                    break;
                case enumTools.Pencil:
                    factory = new PencilFactory(toolPen, new Point(e.X, e.Y));
                    paint = factory.GetPaint();
                    isClicked = true;
                    break;
                case enumTools.Rectangle:
                    factory = new RectangleFactory(toolPen, new Point(e.X, e.Y));
                    paint = factory.GetPaint();
                    isClicked = true;
                    break;
                default:
                    break;
            }

            deletedItemsCollectionPaint = new List<Paint> { };
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClicked)
            {
                moovPoint = new Point(e.X, e.Y);
                paint.MouseMove(moovPoint);
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if ( paint != null && paint.MouseUp())
            {
                mainСollectionPaint.Add(paint);
                paint.Draw(ref graphics);
                pictureBox1.Image = map;
            }
            isClicked = false;
            paint = null;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (paint != null)
            {
                //graphics.Clear(pictureBox1.BackColor);
                paint.Prerender(ref e);
            }

            //pictureBox1.Image = map;

            //foreach (var item in proba)
            //{
            //    item.Draw(ref graphics);
            //    pictureBox1.Image = map;
            //}
        }

        //***************************************

        private void buttonLine_Click(object sender, EventArgs e)
        {
            tools = enumTools.Line;
        }

        private void buttonPencil_Click(object sender, EventArgs e)
        {
            tools = enumTools.Pencil;
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            tools = enumTools.Rectangle;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            lineThickness = (int)numericUpDown1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            color = ((Button)sender).BackColor;
        }

        private void buttonShowDialog_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog1.Color;
                ((Button)sender).BackColor = color;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear ()
        {
            graphics.Clear(Color.White);
            pictureBox1.Image = map;
        }

        private void Redrawing()
        {
            pictureBox1.Image = map;
            foreach (var item in mainСollectionPaint)
            {
                item.Draw(ref graphics);
                pictureBox1.Image = map;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG(*.JPG)|*.jpg";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox1 != null)
                {
                    pictureBox1.Image.Save(saveFileDialog1.FileName);
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (mainСollectionPaint.Count > 0)
            {
                deletedItemsCollectionPaint.Add(mainСollectionPaint[mainСollectionPaint.Count - 1]);
                mainСollectionPaint.Remove(mainСollectionPaint.Last());
                Clear();
                Redrawing();


            }
        }

        private void buttonForth_Click(object sender, EventArgs e)
        {
            if (deletedItemsCollectionPaint.Count>0)
            {
                mainСollectionPaint.Add(deletedItemsCollectionPaint[deletedItemsCollectionPaint.Count - 1]);
                deletedItemsCollectionPaint.Remove(deletedItemsCollectionPaint.Last());
                Redrawing();
            }
        }
    }
}
