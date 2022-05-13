using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Grafpack
{
     abstract class Shape
    {
        
        private string type;
        public Point midPoint;
        // This is the base class for Shapes in the application. It should allow an array or LL
        // to be created containing different kinds of shapes.
        public Shape()   // constructor
        {
            
        }
        //Main draw Method overriden in each shape instance
        public virtual void Draw(Graphics g, Pen blackPen)
        { 
        }
        //Getters
        public new virtual string GetType()
        {
            return type;
        }
        public virtual Point GetMid()
        {
            return midPoint;
        }
        //Methods overriden in each shape class containing relevent code for each shape
        public virtual void Scale(float scaler)
        {

        }

        public virtual void Rotate(float Angle)
        {

        }

        public virtual void Move(float x, float y)
        { }
    }
}
