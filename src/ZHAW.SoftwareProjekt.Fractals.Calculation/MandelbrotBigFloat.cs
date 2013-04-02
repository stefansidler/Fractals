using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHAW.SoftwareProjekt.Fractals.DataStructures;

namespace ZHAW.SoftwareProjekt.Fractals.Calculation
{
    public class MandelbrotBigFloat
    {
        private const int MaxIterations = 100;

        public string Name { get; set; }

        public BigFloat XminBig { get; set; }
        public BigFloat XmaxBig { get; set; }
        public BigFloat YminBig { get; set; }
        public BigFloat YmaxBig { get; set; }

        private BigFloat GetDeltaX(int resolutionX)
        {
            return ((XmaxBig - XminBig) / resolutionX);
        }

        private BigFloat GetDeltaY(int resolutionY)
        {
            return ((YmaxBig - YminBig) / resolutionY);
        }

        public double CalculateAtPosition(int xPos, int yPos, int resolutionX, int resolutionY)
        {
            BigFloat x0 = xPos;
            BigFloat y0 = yPos;
            x0 = GetRealXPosition(x0, resolutionX);
            y0 = GetRealYPosition(y0, resolutionY);

            var iterations = 0;
            BigFloat x = 0.0m;
            BigFloat y = 0.0m;
            while (iterations < MaxIterations && BigFloat.Sqrt((x * x) + (y * y)) < 2)
            {
                var xtemp = (x * x) - (y * y) + x0;
                y = 2 * x * y + y0;
                x = xtemp;

                iterations++;
            }

            return iterations / (double)MaxIterations;
        }

        public BigFloat GetRealXPosition(BigFloat x, int width)
        {
            return XminBig + (x * GetDeltaX(width));
        }

        public BigFloat GetRealYPosition(BigFloat y, int height)
        {
            return YmaxBig - (y * GetDeltaY(height));
        }
    }
}
