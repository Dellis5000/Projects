using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafpack
{
    class MatrixMultiplication
    {
        public static float[,] m3 = { { 0, 0 } }; // used to store new point returned
        public static int incrementer;

        //Method containing matrix multiplication for scaling of a given point
        public static float[,] ScalerMultiplier(float[,] m1, float[,] m2)
        {
            //Loops used for matrix multiplication
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    m3[i, j] = 0;
                 
                    for (incrementer = 0; incrementer < 2; incrementer++) // Incrementer is used to access X and Y locations
                    {
                        m3[i, j] += m1[i, j] * m2[incrementer, j];
                    }
                }
            }

            return m3;
        }
        
        //Method containing calculations for rotation of a given point of a shape
        public static float[,] RotationMultiplier(float[,] m1, float[,] m2)
        {

            m3[0, 0] = (m1[0, 0] * m2[0, 0]) - (m1[0, 1] * m2[0, 1]);
            m3[0, 1] = (m1[0, 0] * m2[0, 1]) + (m1[0, 1] * m2[0, 0]);

            return m3;
        }
    }
}
