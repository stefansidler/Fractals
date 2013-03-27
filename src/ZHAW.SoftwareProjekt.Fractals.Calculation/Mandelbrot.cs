using System;

namespace ZHAW.SoftwareProjekt.Fractals.Calculation
{
    public class Mandelbrot: IFractal
    {
        private const int MaxIterations = 100;

        public string Name { get; set; }

        public double Xmin { get; set; }
        public double Xmax { get; set; }
        public double Ymin { get; set; }
        public double Ymax { get; set; }

        private double GetDeltaX(int resolutionX)
        {
            return ((Xmax - Xmin) / resolutionX);
        }

        private double GetDeltaY(int resolutionY)
        {
            return ((Ymax - Ymin) / resolutionY);
        }

        public double CalculateAtPosition(double x0, double y0, int resolutionX, int resolutionY)
        {
            x0 = GetRealXPosition(x0, resolutionX);
            y0 = GetRealYPosition(y0, resolutionY);

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

        public double GetRealXPosition(double x, int width)
        {
            return Xmin + (x*GetDeltaX(width));
        }

        public double GetRealYPosition(double y, int height)
        {
            return Ymax -  (y*GetDeltaY(height));
        }
    }
}