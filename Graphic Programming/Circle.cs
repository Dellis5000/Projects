using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafpack
{
    class Circle : Shape
    {
        private double diameter, radius; //variables defined for storage
        Point[] points = new Point[2];
        Point plotPt, centre;
        private string type;
        public new static Point midPoint;

        public Circle(Point pt1, Point pt2)
        {
            points[0] = pt1;
            points[1] = pt2;
            centre.X = (points[0].X + points[1].X) / 2;
            centre.Y = (points[0].Y + points[1].Y) / 2;
            type = "Circle";
            midPoint = pt1;

            diameter = Math.Sqrt(Math.Pow(Convert.ToDouble((points[1].X - points[0].X)), 2) + Math.Pow(Convert.ToDouble((points[1].Y - points[0].Y)), 2));
            radius = diameter / 2;
        }
        public override string GetType()
        {
            return type;
        }
        public override Point GetMid()
        {
            return midPoint;
        }

        void putPixel(Graphics g, Point pixel, Pen pen)
        {
           
            if (pen.Color == Color.Red)
            {
                Brush aBrush = (Brush)Brushes.Red;
                // FillRectangle call fills at location x y and is 1 pixel high by 1 pixel wide
                g.FillRectangle(aBrush, pixel.X, pixel.Y, 1, 1);
            }
            else
            {
                Brush aBrush = (Brush)Brushes.Black;
                // FillRectangle call fills at location x y and is 1 pixel high by 1 pixel wide
                g.FillRectangle(aBrush, pixel.X, pixel.Y, 1, 1);
            }            
        }

        //Draw method Utilises the BresCircle code from Week 5 representation of geometrical shapes
        public override void Draw(Graphics g, Pen pen)
        {
            int x = 0;
            int y = Convert.ToInt32(radius);
            int d = 3 - 2 * Convert.ToInt32(radius);  // initial value

            while (x <= y)
            {
                // plot pixel in each octant
                plotPt.X = x + centre.X;
                plotPt.Y = y + centre.Y;
                putPixel(g, plotPt, pen);

                plotPt.X = y + centre.X;
                plotPt.Y = x + centre.Y;
                putPixel(g, plotPt, pen);

                plotPt.X = y + centre.X;
                plotPt.Y = -x + centre.Y;
                putPixel(g, plotPt, pen);

                plotPt.X = x + centre.X;
                plotPt.Y = -y + centre.Y;
                putPixel(g, plotPt, pen);

                plotPt.X = -x + centre.X;
                plotPt.Y = -y + centre.Y;
                putPixel(g, plotPt, pen);

                plotPt.X = -y + centre.X;
                plotPt.Y = -x + centre.Y;
                putPixel(g, plotPt, pen);

                plotPt.X = -y + centre.X;
                plotPt.Y = x + centre.Y;
                putPixel(g, plotPt, pen);

                plotPt.X = -x + centre.X;
                plotPt.Y = y + centre.Y;
                putPixel(g, plotPt, pen);

                // update d value 
                if (d <= 0)
                {
                    d = d + 4 * x + 6;
                }
                else
                {
                    d = d + 4 * (x - y) + 10;
                    y--;
                }
                x++;
            }
        }
        public override void Scale(float scaler)
        {
            //First we set the objects midpoint to the origin (0,0)
            this.MoveToOrigin();

            //we can then multiply these points by the scaler to scale the object
            //Definition of scaler matrix
            float[,] scalerMatrix = { {scaler, 0},
                            {0, scaler }};

            //Multiply both points of the circle by the scaler matrix
            float[,] firstPoint = { { points[0].X, points[0].Y } };
            float[,] secondPoint = { { points[1].X, points[1].Y } };

            firstPoint = MatrixMultiplication.ScalerMultiplier(firstPoint, scalerMatrix);
            points[0].X = Convert.ToInt32(firstPoint[0, 0]);
            points[0].Y = Convert.ToInt32(firstPoint[0, 1]);

            secondPoint = MatrixMultiplication.ScalerMultiplier(secondPoint, scalerMatrix);
            points[1].X = Convert.ToInt32(secondPoint[0, 0]);
            points[1].Y = Convert.ToInt32(secondPoint[0, 1]);
            

            //we then move the object back to its original origin;
            this.MoveToOriginalPlacement();

            //calculate the new diameter radius for the new points
            diameter = Math.Sqrt(Math.Pow(Convert.ToDouble((points[1].X - points[0].X)), 2) + Math.Pow(Convert.ToDouble((points[1].Y - points[0].Y)), 2));
            radius = diameter / 2;

        }
        //Method to move object midpoint to 0,0 for transformations
        public void MoveToOrigin()
        {
            for (int i = 0; i < 2; i++)
            {
                points[i].X -= centre.X; 
                points[i].Y -= centre.Y;
            }
        }

        //Method to move the object back to its original place
        public void MoveToOriginalPlacement()
        {
            for (int i = 0; i < 2; i++)
            {
                points[i].X += centre.X;
                points[i].Y += centre.Y;
            }
        }
        public override void Move(float x, float y) //Method for moving a shape used for both mouse click and user input
        {
            int newX = Convert.ToInt32(x);
            int newY = Convert.ToInt32(y);

            for (int i = 0; i < 2; i++) //set new points for all points stored in array
            {
                points[i].X += newX;
                points[i].Y += newY;
            }
            centre.X = (points[0].X + points[1].X) / 2; //calculate new centre
            centre.Y = (points[0].Y + points[1].Y) / 2;
            midPoint = points[0]; //calculate new midpoint

            diameter = Math.Sqrt(Math.Pow(Convert.ToDouble((points[1].X - points[0].X)), 2) + Math.Pow(Convert.ToDouble((points[1].Y - points[0].Y)), 2));
            radius = diameter / 2;
        }
    }           
    
}
