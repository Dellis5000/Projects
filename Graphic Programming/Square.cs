using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Grafpack;

class Square : Shape
{
    //This class contains the specific details for a square defined in terms of opposite corners
    Point[] points = new Point[2];
    private string type;
    public new static Point midPoint;
    public Square( Point pt1, Point pt2)   // constructor
    {
        points[0] = pt1;
        points[1] = pt2;
        midPoint.X = (pt1.X + pt2.X) / 2;
        midPoint.Y = (pt1.Y + pt2.Y) / 2;
        type = "Square";        

    }

    public override string GetType()
    {
        return type;
    }

    public override Point GetMid()
    {
        return midPoint;
    }

    // You will need a different draw method for each kind of shape. Note the square is drawn
    // from first principles. All other shapes should similarly be drawn from first principles. 
    // Ideally no C# standard library class or method should be used to create, draw or transform a shape
    // and instead should utilse user-developed code.
    public override void Draw(Graphics g, Pen blackPen)
    {
        // This method draws the square by calculating the positions of the other 2 corners
        double xDiff, yDiff, xMid, yMid;   // range and mid points of x & y  

        // calculate ranges and mid points
        xDiff = points[1].X - points[0].X;
        yDiff = points[1].Y - points[0].Y;
        xMid = (points[1].X + points[0].X) / 2;
        yMid = (points[1].Y + points[0].Y) / 2;

        // draw square
        g.DrawLine(blackPen, (int)points[0].X, (int)points[0].Y, (int)(xMid + yDiff / 2), (int)(yMid - xDiff / 2));
        g.DrawLine(blackPen, (int)(xMid + yDiff / 2), (int)(yMid - xDiff / 2), (int)points[1].X, (int)points[1].Y);
        g.DrawLine(blackPen, (int)points[1].X, (int)points[1].Y, (int)(xMid - yDiff / 2), (int)(yMid + xDiff / 2));
        g.DrawLine(blackPen, (int)(xMid - yDiff / 2), (int)(yMid + xDiff / 2), (int)points[0].X, (int)points[0].Y);
    }

    public override void Scale(float scaler)
    {
        //First we set the objects midpoint to the origin (0,0)
        this.MoveToOrigin();

        //Definition of scaler matrix
        float[,] scalerMatrix = { {scaler, 0},
                            {0, scaler }};

        //Multiply both points of the square by the scaler matrix
        float[,] firstPoint = { { points[0].X, points[0].Y } };
        float[,] secondPoint = { { points[1].X, points[1].Y } };
        firstPoint = MatrixMultiplication.ScalerMultiplier(firstPoint, scalerMatrix);
        points[0].X = Convert.ToInt32(firstPoint[0,0]);
        points[0].Y = Convert.ToInt32(firstPoint[0, 1]);

        secondPoint = MatrixMultiplication.ScalerMultiplier(secondPoint, scalerMatrix);
        points[1].X = Convert.ToInt32(secondPoint[0, 0]);
        points[1].Y = Convert.ToInt32(secondPoint[0, 1]);

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
        float[,] rotationMatrix = { {cosa, sina},
                                {negativeSina, cosa } };

        float[,] firstPoint = { { points[0].X, points[0].Y } };
        float[,] secondPoint = { { points[1].X, points[1].Y } };

        firstPoint = MatrixMultiplication.RotationMultiplier(firstPoint, rotationMatrix);
        points[0].X = Convert.ToInt32(firstPoint[0, 0]);
        points[0].Y = Convert.ToInt32(firstPoint[0, 1]);       

        secondPoint = MatrixMultiplication.RotationMultiplier(secondPoint, rotationMatrix);
        points[1].X = Convert.ToInt32(secondPoint[0, 0]);
        points[1].Y = Convert.ToInt32(secondPoint[0, 1]);


        //we then move the object back to its original origin;
        this.MoveToOriginalPlacement();

    }

    //Method to move object midpoint to 0,0 for transformations
    public void MoveToOrigin() 
    {
        points[0].X -= midPoint.X;
        points[0].Y -= midPoint.Y;
        points[1].X -= midPoint.X;
        points[1].Y -= midPoint.Y;
    }

    //Method to move the object back to its original place
    public void MoveToOriginalPlacement()
    {
        points[0].X += midPoint.X;
        points[0].Y += midPoint.Y;
        points[1].X += midPoint.X;
        points[1].Y += midPoint.Y;
    }

    public override void Move(float x, float y) //method to move a square
    {
        int newX = Convert.ToInt32(x);
        int newY = Convert.ToInt32(y);
        points[0].X += newX;
        points[0].Y += newY;
        points[1].X += newX;
        points[1].Y += newY;

        midPoint.X = (points[0].X + points[1].X) / 2;
        midPoint.Y = (points[0].Y + points[1].Y) / 2;
    }

}