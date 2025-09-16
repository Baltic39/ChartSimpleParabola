using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChartSimpleParabola
{
    public partial class Form1 : Form
    {
        private double h;
        private int a, b;
        private double x, y;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            a = -2;
            b = 2;
            h = 0.5;
            x = a;

            while (x <= b)
            {
                y = x * x;
                this.chart1.Series[0].Points.AddXY(x, y);
                x += h;
            }

            x = 1.2;
            y = x * x;
            this.chart1.Series[1].Points.AddXY(x, y);
                
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                chart1.SaveImage(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                Bitmap bm = new Bitmap(ms);
                Clipboard.SetImage(bm);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.SaveImage("Graphic_image", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
