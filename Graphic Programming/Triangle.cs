using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Grafpack
{
    class Triangle : Shape
    {
        private Point[] points = new Point[3]; // Points array to store points of a triangle
        public new static Point midPoint; // Point to store shapes midpoint
        string type;
        public Triangle( Point pt1, Point pt2, Point pt3) // Traingle constructer
        {

            points[0] = pt1; // points stored in array
            points[1] = pt2;
            points[2] = pt3;
            midPoint.X = (points[0].X + points[1].X + points[2].X) / 3; // MidPoint calculated
            midPoint.Y = (points[0].Y + points[1].Y + points[2].Y) / 3;
            type = "Triangle";
            
        }
        public override Point GetMid()
        {
            return midPoint; //Method to return midpoint of triangle
        }
        public override string GetType()
        {
            return type;
        }

        public override void Draw(Graphics g, Pen pen) //Method draws the shape
        {               
            g.DrawLine(pen, (int)points[0].X, (int)points[0].Y, (int)points[1].X, points[1].Y); // Each line of triangle drawn
            g.DrawLine(pen, (int)points[1].X, (int)points[1].Y, (int)points[2].X, points[2].Y);
            g.DrawLine(pen, (int)points[2].X, (int)points[2].Y, (int)points[0].X, points[0].Y);

        }
        public override void Scale(float scaler)
        {
            //First we set the objects midpoint to the origin (0,0)
            this.MoveToOrigin();

            //Definition of scaler matrix
            float[,] scalerMatrix = { {scaler, 0}, 
                            {0, scaler }};

            //we can then multiply the 3 points by the scaler matrix to scale the object
            float[,] firstPoint = { { points[0].X, points[0].Y } };
            float[,] secondPoint = { { points[1].X, points[1].Y } };
            float[,] thirdPoint = { { points[2].X, points[2].Y } };

            firstPoint = MatrixMultiplication.ScalerMultiplier(firstPoint, scalerMatrix);
            points[0].X = Convert.ToInt32(firstPoint[0, 0]);
            points[0].Y = Convert.ToInt32(firstPoint[0, 1]);

            secondPoint = MatrixMultiplication.ScalerMultiplier(secondPoint, scalerMatrix);
            points[1].X = Convert.ToInt32(secondPoint[0, 0]);
            points[1].Y = Convert.ToInt32(secondPoint[0, 1]);

            thirdPoint = MatrixMultiplication.ScalerMultiplier(thirdPoint, scalerMatrix);
            points[2].X = Convert.ToInt32(thirdPoint[0, 0]);
            points[2].Y = Convert.ToInt32(thirdPoint[0, 1]);

            //we then move the object back to its original origin;
            this.MoveToOriginalPlacement();
        }

        public override void Rotate(float angle) //Rotation method
        {
            //First we set the objects midpoint to the origin (0,0)
            this.MoveToOrigin();

            //Definition of the rotation matrix
            float cosa = (float)Math.Cos(angle * Math.PI / 180.0);
            float sina = (float)Math.Sin(angle * Math.PI / 180.0);
            float negativeSina = sina * -1;
            float[,] rotationMatrix = { {cosa, sina},
                                {negativeSina, cosa } };

            //Calculation of new points when multiplied by rotation matrix
            float[,] firstPoint = { { points[0].X, points[0].Y } };
            float[,] secondPoint = { { points[1].X, points[1].Y } };
            float[,] thirdPoint = { { points[2].X, points[2].Y } };

            firstPoint = MatrixMultiplication.RotationMultiplier(firstPoint, rotationMatrix);
            points[0].X = Convert.ToInt32(firstPoint[0, 0]);
            points[0].Y = Convert.ToInt32(firstPoint[0, 1]);

            secondPoint = MatrixMultiplication.RotationMultiplier(secondPoint, rotationMatrix);
            points[1].X = Convert.ToInt32(secondPoint[0, 0]);
            points[1].Y = Convert.ToInt32(secondPoint[0, 1]);

            thirdPoint = MatrixMultiplication.RotationMultiplier(thirdPoint, rotationMatrix);
            points[2].X = Convert.ToInt32(thirdPoint[0, 0]);
            points[2].Y = Convert.ToInt32(thirdPoint[0, 1]);

            //we then move the object back to its original origin;
            this.MoveToOriginalPlacement();

        }

        //Method to move object midpoint to 0,0 for transformations
        public void MoveToOrigin()
        {
            for (int i = 0; i < 3; i++) //Loops through and moves all points to centre on midpoint (0,0)
            {
                points[i].X -= midPoint.X;
                points[i].Y -= midPoint.Y;
            }
        }

        //Method to move the object back to its original place
        public void MoveToOriginalPlacement()
        {
            for (int i = 0; i < 3; i++)
            {
                points[i].X += midPoint.X;
                points[i].Y += midPoint.Y;
            }
        }
        public override void Move(float x, float y) //Method to move a shape to a new midpoint
        {
            int newX = Convert.ToInt32(x);
            int newY = Convert.ToInt32(y);

            for (int i = 0; i < 3; i++) //Loops through all points
            {
                points[i].X += newX;
                points[i].Y += newY;
            }
            midPoint.X = (points[0].X + points[1].X + points[2].X) / 3; //Calculation of new midpoit
            midPoint.Y = (points[0].Y + points[1].Y + points[2].Y) / 3;
        }

    }
}
