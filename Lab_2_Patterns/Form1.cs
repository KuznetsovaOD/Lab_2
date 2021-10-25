using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2_Patterns
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)   //controller
        {
            ShapeFactory factory = new ShapeFactory();
            Shape ShapePolygon = factory.get(Convert.ToInt32(comboBox1.Text));
            try
            {
                pictureBox1.Image = ShapePolygon.Draw();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка"); }
            label2.Text = ShapePolygon.Descriptor();
        }

        public int getHeight()
        {
            return pictureBox1.Height;
        }
        public int getWidth()
        {
            return pictureBox1.Width;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "0";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


    public class ShapeFactory
    {
        public Shape get(int numberOfSides)
        {
            if (numberOfSides == 0)
            {
                return new Circle();
            }
            else if (numberOfSides == 1)
            {
                return new Line();
            }
            else if (numberOfSides == 2)
            {
                return new Angle();
            }
            else if (numberOfSides == 3)
            {
                return new Triangle();
            }
            else if (numberOfSides == 4)
            {
                return new Square();
            }
            else
            {
                return new Pentagon();
            }
        }
    }


    abstract public class Shape
    {
        public int x1;
        public int y1;
        public SolidBrush pen;
        public Pen myPen;
        public Shape()
        {
            x1 = 100;
            y1 = 100;
            pen = new SolidBrush(Color.White);
            myPen = new Pen(Color.Purple);
        }
        public abstract string Descriptor();
        abstract public Image Draw();
    }


    public class Circle : Shape
    {
        public override Image Draw()
        {
            Form1 form1 = new Form1();
            Bitmap pictureBox = new Bitmap(form1.getWidth(), form1.getHeight());
            Graphics graph = Graphics.FromImage(pictureBox);
            graph.FillRectangle(pen, form1.ClientRectangle);
            graph.DrawEllipse(myPen, x1, y1, 100, 100);
            return pictureBox;
        }
        public override string Descriptor() { return "Круг"; }
    }


    public class Line : Shape
    {
        public override Image Draw()
        {
            Form1 form1 = new Form1();
            Bitmap pictureBox = new Bitmap(form1.getWidth(), form1.getHeight());
            Graphics graph = Graphics.FromImage(pictureBox);
            graph.FillRectangle(pen, form1.ClientRectangle);
            graph.DrawLine(myPen, x1, y1, 200, 200);
            return pictureBox;
        }
        public override string Descriptor() { return "Линия"; }
    }


    public class Angle : Shape
    {
        public override Image Draw()
        {
            Form1 form1 = new Form1();
            Bitmap pictureBox = new Bitmap(form1.getWidth(), form1.getHeight());
            Graphics graph = Graphics.FromImage(pictureBox);
            graph.FillRectangle(pen, form1.ClientRectangle);
            graph.DrawLine(myPen, 100, 100, 200, 200);
            graph.DrawLine(myPen, 200, 200, 100, 200);
            return pictureBox;
        }
        public override string Descriptor() { return "Угол"; }
    }


    public class Triangle : Shape
    {
        public override Image Draw()
        {
            Form1 form1 = new Form1();
            Bitmap pictureBox = new Bitmap(form1.getWidth(), form1.getHeight());
            Graphics graph = Graphics.FromImage(pictureBox);
            graph.FillRectangle(pen, form1.ClientRectangle);

            PointF point1 = new PointF(100, 100);
            PointF point2 = new PointF(200, 200);
            PointF point3 = new PointF(100, 200);
            PointF[] curvePoints =
                     {
                                point1,
                                point2,
                                point3,
                             };
            graph.DrawPolygon(myPen, curvePoints);
            return pictureBox;
        }
        public override string Descriptor() { return "Треугольник"; }
    }


    public class Square : Shape
    {
        public override Image Draw()
        {
            Form1 form1 = new Form1();
            Bitmap pictureBox = new Bitmap(form1.getWidth(), form1.getHeight());
            Graphics graph = Graphics.FromImage(pictureBox);
            graph.FillRectangle(pen, form1.ClientRectangle);
            graph.DrawRectangle(myPen, 100, 100, 100, 100);
            return pictureBox;
        }
        public override string Descriptor() { return "Квадрат"; }
    }


    public class Pentagon : Shape
    {
        public override Image Draw()
        {
            Form1 form1 = new Form1();
            Bitmap pictureBox = new Bitmap(form1.getWidth(), form1.getHeight());
            Graphics graph = Graphics.FromImage(pictureBox);
            graph.FillRectangle(pen, form1.ClientRectangle);
            PointF point1 = new PointF(150, 100);
            PointF point2 = new PointF(200, 140);
            PointF point3 = new PointF(180, 200);
            PointF point4 = new PointF(120, 200);
            PointF point5 = new PointF(100, 140);
            PointF[] curvePoints =
                     {
                                point1,
                                point2,
                                point3,
                                point4,
                                point5,
                             };
            graph.DrawPolygon(myPen, curvePoints);
            return pictureBox;
        }
        public override string Descriptor() { return "Пентагон"; }
    }
}

