using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafpack
{
    class Rectangle : Shape
    {
        private Point[] points = new Point[4]; //Points array of the 4 points of rectangle
        public new static Point midPoint;
        private string type;
        public Rectangle(Point pt1, Point pt2)
        {
            points[0] = pt1;
            points[1] = pt2;
            midPoint.X = (pt1.X + pt2.X) / 2;
            midPoint.Y = (pt1.Y + pt2.Y) / 2;
            type = "Rectangle";
            
            //Creation of other 2 points
            points[2].X = points[0].X;
            points[2].Y = points[1].Y;
            points[3].X = points[1].X;
            points[3].Y = points[0].Y;
        }
        public override string GetType() 
        {
            return type;
        }

        public override Point GetMid()
        {
            return midPoint;
        }
        public override void Draw(Graphics g, Pen blackPen) //Draw method for rectangle
        {
            // draw Rectangle
            g.DrawLine(blackPen, points[0].X, points[0].Y, points[2].X, points[2].Y);
            g.DrawLine(blackPen, points[2].X, points[2].Y, points[1].X, points[1].Y);
            g.DrawLine(blackPen, points[1].X, points[1].Y, points[3].X, points[3].Y);
            g.DrawLine(blackPen, points[3].X, points[3].Y, points[0].X, points[0].Y);
        }

        //Scaling method
        public override void Scale(float scaler)
        {
            //First we set the objects midpoint to the origin (0,0)
            this.MoveToOrigin();

            //Definition of scaler matrix
            float[,] scalerMatrix = { {scaler, 0},
                            {0, scaler }};

            //Multiply all points of the rectangle by the scaler matrix
            float[,] firstPoint = { { points[0].X, points[0].Y } };
            float[,] secondPoint = { { points[1].X, points[1].Y } };
            float[,] thirdPoint = { { points[2].X, points[2].Y } };
            float[,] fourthPoint = { { points[3].X, points[3].Y } };
            firstPoint = MatrixMultiplication.ScalerMultiplier(firstPoint, scalerMatrix);
            points[0].X = Convert.ToInt32(firstPoint[0, 0]);
            points[0].Y = Convert.ToInt32(firstPoint[0, 1]);

            secondPoint = MatrixMultiplication.ScalerMultiplier(secondPoint, scalerMatrix);
            points[1].X = Convert.ToInt32(secondPoint[0, 0]);
            points[1].Y = Convert.ToInt32(secondPoint[0, 1]);

            thirdPoint = MatrixMultiplication.ScalerMultiplier(thirdPoint, scalerMatrix);
            points[2].X = Convert.ToInt32(thirdPoint[0, 0]);
            points[2].Y = Convert.ToInt32(thirdPoint[0, 1]);

            fourthPoint = MatrixMultiplication.ScalerMultiplier(fourthPoint, scalerMatrix);
            points[3].X = Convert.ToInt32(fourthPoint[0, 0]);
            points[3].Y = Convert.ToInt32(fourthPoint[0, 1]);

            //we then move the object back to its original origin;
            this.MoveToOriginalPlacement();
        }
        public override void Rotate(float angle)
        {
            //First we set the objects midpoint to the origin (0,0)
            this.MoveToOrigin();

            //Next Definition of the scaler matrix
            float cosa = (float)Math.Cos(angle * Math.PI / 180.0);
            float sina = (float)Math.Sin(angle * Math.PI / 180.0);
            float negativeSina = sina * -1;
            //Definition of rotation matrix 
            float[,] rotationMatrix = { {cosa, sina}, 
                                {negativeSina, cosa } };

            float[,] firstPoint = { { points[0].X, points[0].Y } };
            float[,] secondPoint = { { points[1].X, points[1].Y } };
            float[,] thirdPoint = { { points[2].X, points[2].Y } };
            float[,] fourthPoint = { { points[3].X, points[3].Y } };

            firstPoint = MatrixMultiplication.RotationMultiplier(firstPoint, rotationMatrix);
            points[0].X = Convert.ToInt32(firstPoint[0, 0]);
            points[0].Y = Convert.ToInt32(firstPoint[0, 1]);

            secondPoint = MatrixMultiplication.RotationMultiplier(secondPoint, rotationMatrix);
            points[1].X = Convert.ToInt32(secondPoint[0, 0]);
            points[1].Y = Convert.ToInt32(secondPoint[0, 1]);

            thirdPoint = MatrixMultiplication.RotationMultiplier(thirdPoint, rotationMatrix);
            points[2].X = Convert.ToInt32(thirdPoint[0, 0]);
            points[2].Y = Convert.ToInt32(thirdPoint[0, 1]);

            fourthPoint = MatrixMultiplication.RotationMultiplier(fourthPoint, rotationMatrix);
            points[3].X = Convert.ToInt32(fourthPoint[0, 0]);
            points[3].Y = Convert.ToInt32(fourthPoint[0, 1]);


            //we then move the object back to its original origin;
            this.MoveToOriginalPlacement();

        }

        //Method to move object midpoint to 0,0 for transformations
        public void MoveToOrigin()
        {
            for (int i = 0; i < 4; i++)
            {
                points[i].X -= midPoint.X;
                points[i].Y -= midPoint.Y;
            }
        }

        //Method to move the object back to its original place
        public void MoveToOriginalPlacement()
        {
            for (int i = 0; i < 4; i++)
            {
                points[i].X += midPoint.X;
                points[i].Y += midPoint.Y;
            }
        }

        public override void Move(float x, float y) //Method to move a shape
        {
            int newX = Convert.ToInt32(x);
            int newY = Convert.ToInt32(y);
            for (int i = 0; i < 4; i++)
            {
                points[i].X += newX;
                points[i].Y += newY;
            }           

            midPoint.X = (points[0].X + points[1].X) / 2;
            midPoint.Y = (points[0].Y + points[1].Y) / 2;
        }

    }
}
