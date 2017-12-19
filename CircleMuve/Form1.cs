using FigureLibrary;
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

namespace CircleMuve
{
    public partial class Form1 : Form
    {
        Circle circle;
        Timer timer1 = new Timer();
        public Form1()
        {
            InitializeComponent();
            timer1.Tick += new EventHandler(TimerEventProcessor);

            // Sets the timer interval to 5 seconds.
            timer1.Interval = 100;
            timer1.Start();
            circle = new Circle(40);
            circle.AddPoint(new MyPoint(new Point(300, 200)));
            circle.AddPoint(new MyPoint(new Point(100, 200)));
            circle.AddPoint(new MyPoint(new Point(20, 70)));
            circle.AddPoint(new MyPoint(new Point(100, 100)));
        }

        private void TimerEventProcessor(object sender, EventArgs e)
        {
            circle.Muve(30);
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            circle.Drow(e.Graphics);
        }
    }
}
