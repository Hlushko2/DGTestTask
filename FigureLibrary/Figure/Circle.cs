using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureLibrary
{
    public class Circle
    {
        Point begin = new Point(0, 0);
        public Point Begin { get { return begin; } set { begin = value; rec.Location = value; } }

        Point curentPoint;
        private Rectangle rec;
        public Rectangle Rec { get { return rec; } }
        
        public int Radius { get; }
        int numberMuvePoint;
        int numberMuve=1;
        double deltaX = 0;
        double deltaY = 0;
        private List<MyPoint> colectionPoint = new List<MyPoint>();
        public List<MyPoint> ColectionPoint { get { return colectionPoint; } }

        public Circle(int R)
        {
            rec = new Rectangle(0, 0, R, R);
        }
        public void AddPoint(MyPoint p)
        {
            colectionPoint.Add(p);
        }
        public void Drow(Graphics gr)
        {
            colectionPoint.ForEach((x)=> x.Drow(gr));
            gr.DrawEllipse(new Pen(Color.White, 3), Rec);
            gr.FillEllipse(Brushes.LightBlue, Rec);            
        }
        public void Muve(double speed)
        {
            if (numberMuve==1)
            {
                curentPoint = Begin;
                deltaX = (colectionPoint[numberMuvePoint].Begin.X - Begin.X) / speed;
                deltaY = (colectionPoint[numberMuvePoint].Begin.Y - Begin.Y) / speed;
                colectionPoint[numberMuvePoint].IsClicked = true;
            }

            Begin = new Point(curentPoint.X + (int)(deltaX*numberMuve), curentPoint.Y + (int)(deltaY* numberMuve));
            numberMuve++;
            if ((Begin.X < colectionPoint[numberMuvePoint].Begin.X + 1 &&
                Begin.X > colectionPoint[numberMuvePoint].Begin.X - 1) &&
                (Begin.Y < colectionPoint[numberMuvePoint].Begin.Y + 1 &&
                Begin.Y > colectionPoint[numberMuvePoint].Begin.Y - 1)
                )
            {
                colectionPoint[numberMuvePoint].IsClicked = false;
                numberMuvePoint = (numberMuvePoint < colectionPoint.Count - 1) ? numberMuvePoint + 1 : 0;
                numberMuve = 1;
            }
        }
    }
}
