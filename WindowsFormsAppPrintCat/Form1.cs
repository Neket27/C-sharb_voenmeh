using Cairo;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using Graphics = System.Drawing.Graphics;
using Point = System.Drawing.Point;

namespace WindowsFormsAppPrintCat
{
    public partial class Form1 : Form
    {
              public Form1()
        {
            InitializeComponent();

        }
        bool drw;
        int beginX, beginY;

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            drw = false;
            string path = "coordinates.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLineAsync("/////");
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e) //пока мышка нажата считываем координаты
        {
            drw = true;
            beginX = e.X;
            beginY = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.White, 4);
            Point point1 = new Point(beginX, beginY);
            Point point2 = new Point(e.X, e.Y);
            if (drw == true)
            {
                g.DrawLine(p, point1, point2);
                beginX = e.X;
                beginY = e.Y;
                
                string path = "coordinates.txt";
                string text = e.X + " " + e.Y + "\n";

                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLineAsync(e.X + " " + e.Y);
                }

               
            }
        }

     

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Рисунок";
            this.BackColor = Color.Black;
        }

        bool bDrawRectangle = false;
        private void button1_Click(object sender, EventArgs e)
        {
            bDrawRectangle = true;
            Invalidate();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bDrawRectangle = true;
            Invalidate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = "coordinates.txt";
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Color.White, 4);
          
         
            using (StreamReader reader = new StreamReader(path))
            {
                string[] startByXY = reader.ReadLine().Split(' ');
                string line;
                

                int saveByX = int.Parse(startByXY[0]);
                int saveByY = int.Parse(startByXY[1]);
                Point point1 = new Point(saveByX, saveByY);
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "/////")
                    {
                        string str = reader.ReadLine();
                        if (str != null && str!= "/////")
                        {
                            string[] XY = str.Split(' ');
                            beginX = int.Parse(XY[0]);
                            beginY = int.Parse(XY[1]);
                            saveByX = beginX;
                            saveByY = beginY;
                            point1 = new Point(beginX, beginY);
                            Point point2 = new Point(beginX, beginY);
                            g.DrawLine(p, point1, point2);
                        }
                    }
                    else
                    {
                        string[] XandY = line.Split(' ');
                        beginX = int.Parse(XandY[0]);
                        beginY = int.Parse(XandY[1]);
                        Point point2 = new Point(beginX, beginY);
                        g.DrawLine(p, point1, point2);
                        point1 = new Point(saveByX, saveByY);
                        saveByX = int.Parse(XandY[0]);
                        saveByY = int.Parse(XandY[1]);
                    }

                }

            }

        }

     
    }
}
