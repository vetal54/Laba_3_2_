using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Laba_3_2_2021
{
    class CEmblem
    {
        Color color { get; set; }
        public Color currentColor { get; set; }
        int size { get; set; }
        int x { get; set; }
        int y { get; set; }
        string name { get; set; }
        Pen pen = new Pen(Color.Blue, 2);
        PointF rotatePoint;
        PointF rotatePoint1;
        PointF rotatePoint2;
        double diagonal;

        public CEmblem(int x, int y, int size, string name, Color color)
        {
            this.x = x;
            this.y = y;
            this.size = size;
            this.name = name;
            this.color = color;
            currentColor = color;
        }

        public override string ToString()
        {
            return name;
        }
        int x11=45;
        
        public void Draw(PictureBox pictureBox)
        {
            diagonal = (Math.Sqrt(Math.Pow(size, 2) + Math.Pow(size, 2)) / 2);
            pen.Color = currentColor;
            Graphics g = pictureBox.CreateGraphics();
            //Graphics g1 = pictureBox.CreateGraphics();
            rotatePoint = new PointF(x, y);
            //Matrix myMatrix1 = new Matrix();
            //myMatrix1.RotateAt(x11, rotatePoint, MatrixOrder.Append);

            //g1.Transform = myMatrix1;
            //g1.DrawLine(pen, x, y, x + size, y + size);


            Point[] points = new Point[3];
            points[0].X = x; points[0].Y = y;
            points[1].X = x - 50; points[1].Y = y + 50;
            points[2].X = x + 50; points[2].Y = y + 50;

            //Point[] points = new Point[3];
            //points[0].X = 150; points[0].Y = 150;
            //points[1].X = 100; points[1].Y = 200;
            //points[2].X = 200; points[2].Y = 200;
            //g.DrawRectangle(pen, x, y, size, size);
            Matrix myMatrix = new Matrix();
            
            myMatrix.RotateAt(x11, rotatePoint, MatrixOrder.Append);
           
            g.Transform = myMatrix;

            g.DrawPolygon(pen, points);
            //g.DrawRectangle(pen, x, y, size, size);

            //g.DrawEllipse(pen, x, y, size, size);
        }

        public void MoveRight()
        {
            if (rotatePoint.X < (852 - (diagonal * 2)) - 150) x += 4;
            else MessageBox.Show("Но-но-но, неможна бiльше");
        }
        public void MoveLeft()
        {
           
            if (rotatePoint.X > diagonal+4) x-=4;
            else MessageBox.Show("Но-но-но, неможна бiльше");
        }
        public void MoveUp()
        {
            //if (((size - size / 2) / 2) < y) y--;
            if (rotatePoint.Y > diagonal + 4) y -= 4;
            else MessageBox.Show("Но-но-но, неможна бiльше");
        }
        public void MoveDown()
        {
            if (y + size + (size - size / 2) < 510) y+=4;
            else MessageBox.Show("Но-но-но, неможна бiльше");
        }
        public void EndUp()
        {
            y = (size - size / 2)/2;
        }
        public void EndDown()
        {
            y = 495-size- ((size - size / 2) / 2);
        }
        public void EndLeft()
        {
            x = (size - size / 2) / 2;

        }

        public void Rotate(PictureBox pictureBox)
        {
            x11 += 2;
        }

        public void EndRight()
        {
            x = 610 - size;
        }
        public void Enlarge()
        {
            //if(y+size + (size - size / 2) <500 && x + size + (size - size / 2) < 780) size++;
            if (rotatePoint.X < (852 - (diagonal * 2)) && rotatePoint.Y < (610 - (diagonal * 2))) size+=4;
            else MessageBox.Show("Но-но-но, неможна бiльше");
        }
        
        public void Reduce()
        {
            if (size > 0) size-=4;
            else MessageBox.Show("Но-но-но, неможна бiльше");
        }
        
        public void Hide()
        {
            currentColor = Color.White;
        }
        public void Show()
        {
            currentColor = color;
        }
    }
}
