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
using System.Windows.Forms.DataVisualization.Charting;

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
            a = -2; // Левая сторона графика
            b = 2;  // Правая сторона графика
            h = 0.5;    // Шаг сетки графика
            x = a;  // Задаём оси x ограничение слева

            // === График параболы ===
            while (x <= b)
            {
                y = x * x;
                this.chart1.Series[0].Points.AddXY(x, y);
                x += h;
            }

            // === Точка ===
            x = 1.2;
            y = x * x;
            this.chart1.Series[1].MarkerSize = 10;  // Задаём размер точки
            this.chart1.Series[1].MarkerStyle = MarkerStyle.Circle; // Задаём стиль точки (круглый)
            this.chart1.Series[1].Points.AddXY(x, y);   // Рисуем точку с координатами
            
        }

        // === копирование изображения графика ===
        private void button2_Click(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                chart1.SaveImage(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                Bitmap bm = new Bitmap(ms);
                Clipboard.SetImage(bm);
            }
        }

        // === Сохранение изображения ===
        private void button1_Click(object sender, EventArgs e)
        {
            chart1.SaveImage("Graphic_image", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
