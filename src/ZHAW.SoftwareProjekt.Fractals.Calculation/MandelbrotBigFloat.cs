using System;
using ZHAW.SoftwareProjekt.Fractals.DataStructures;

namespace ZHAW.SoftwareProjekt.Fractals.Calculation
{
    public class MandelbrotBigFloat : IFractal<BigFloat>
    {
        private const int MaxIterations = 100;

        public string Name { get; set; }

        public BigFloat Xmin { get; set; }
        public BigFloat Xmax { get; set; }
        public BigFloat Ymin { get; set; }
        public BigFloat Ymax { get; set; }

        private BigFloat GetDeltaX(int resolutionX)
        {
            return ((Xmax - Xmin) / resolutionX);
        }

        private BigFloat GetDeltaY(int resolutionY)
        {
            return ((Ymax - Ymin) / resolutionY);
        }

        public double CalculateAtPosition(int xPos, int yPos, int resolutionX, int resolutionY)
        {
            BigFloat x0 = RealXPosition(xPos, resolutionX);
            BigFloat y0 = RealYPosition(yPos, resolutionY);

            var iterations = 0;
            BigFloat x = 0.0m;
            BigFloat y = 0.0m;
            double abort = 0.301029995663981;
            while (iterations < MaxIterations && 0.5*BigFloat.Log(((x * x) + (y * y))) < abort)
            {
                var xtemp = (x * x) - (y * y) + x0;
                y = 2 * x * y + y0;
                x = xtemp;

                iterations++;
            }

            return iterations / (double)MaxIterations;
        }

        private BigFloat RealXPosition(int x, int width)
        {
            return Xmin + (x * GetDeltaX(width));
        }

        private BigFloat RealYPosition(int y, int height)
        {
            return Ymax - (y * GetDeltaY(height));
        }

        public string GetRealXPosition(int x, int width)
        {
            return RealXPosition(x, width).ToString();
        }

        public string GetRealYPosition(int y, int height)
        {
            return RealYPosition(y, height).ToString();
        }
    }
}
