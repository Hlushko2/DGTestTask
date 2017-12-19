using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureLibrary
{
    public class MyPoint
    {
        public bool IsClicked { get; set; }
        Point begin;
        public Point Begin { get { return begin; }  }
        private Rectangle rec;
        public Rectangle Rec { get { return rec; } }
        public MyPoint(Point p)
        {
            begin = p;
            rec = new Rectangle(p.X, p.Y, 8, 8);
        }
        public void Drow(Graphics gr)
        {
            gr.DrawEllipse(new Pen(Color.White, 2), Rec);
            if (IsClicked)
                gr.FillEllipse(Brushes.Red, Rec);
        }
    }
}
