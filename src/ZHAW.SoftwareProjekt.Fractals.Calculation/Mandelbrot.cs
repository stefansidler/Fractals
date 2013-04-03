using System;

namespace ZHAW.SoftwareProjekt.Fractals.Calculation
{
    public class Mandelbrot : IFractal
    {
        private const int MaxIterations = 100;

        public string Name { get; set; }

        public string Xmin { get; set; }
        public string Xmax { get; set; }
        public string Ymin { get; set; }
        public string Ymax { get; set; }

        private double GetDeltaX(int resolutionX)
        {
            return ((double.Parse(Xmax) - double.Parse(Xmin)) / resolutionX);
        }

        private double GetDeltaY(int resolutionY)
        {
            return ((double.Parse(Ymax) - double.Parse(Ymin)) / resolutionY);
        }

        public double CalculateAtPosition(int xPos, int yPos, int resolutionX, int resolutionY)
        {
            double x0 = double.Parse(GetRealXPosition(xPos, resolutionX));
            double y0 = double.Parse(GetRealYPosition(yPos, resolutionY));

            var iterations = 0;
            var x = 0.0;
            var y = 0.0;
            while (iterations < MaxIterations && Math.Sqrt((x * x) + (y * y)) < 2)
            {
                var xtemp = (x * x) - (y * y) + x0;
                y = 2 * x * y + y0;
                x = xtemp;

                iterations++;
            }

            return iterations / (double)MaxIterations;
        }

        public string GetRealXPosition(int x, int width)
        {
            return (double.Parse(Xmin) + (x * GetDeltaX(width))).ToString();
        }

        public string GetRealYPosition(int y, int height)
        {
            return (double.Parse(Ymax) - (y * GetDeltaY(height))).ToString();
        }
    }
}