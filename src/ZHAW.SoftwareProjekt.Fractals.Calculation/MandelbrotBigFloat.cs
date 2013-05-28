using System;
using System.Drawing;
using ZHAW.SoftwareProjekt.Fractals.DataStructures;

namespace ZHAW.SoftwareProjekt.Fractals.Calculation
{
    public class MandelbrotBigFloat : IFractal<BigFloat>
    {
        private const int MaxIterations = 500;
        private static double Abort = Math.Log(2);

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
            while (iterations < MaxIterations && (x * x) + (y * y) < 4)
            {
                var xtemp = (x * x) - (y * y) + x0;
                y = 2 * x * y + y0;
                x = xtemp;

                iterations++;
            }

            return iterations / (double)MaxIterations;
        }

        public IFractal Zoom(double factor, Point center, int width, int height)
        {
            var posX = RealXPosition(center.X, width);
            var posY = RealYPosition(center.Y, height);

            var x = Xmin - Xmax < 0 ? (Xmin - Xmax) * (-1) : Xmin - Xmax;
            var y = Ymin - Ymax < 0 ? (Ymin - Ymax) * (-1) : Ymin - Ymax;

            Xmin = posX - (x / (decimal)factor);
            Xmax = posX + (x / (decimal)factor);
            Ymin = posY - (y / (decimal)factor);
            Ymax = posY + (y / (decimal)factor);

            return this;
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
