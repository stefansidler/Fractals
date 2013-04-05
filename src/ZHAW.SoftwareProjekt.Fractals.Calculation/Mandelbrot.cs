using System;

namespace ZHAW.SoftwareProjekt.Fractals.Calculation
{
    public class Mandelbrot : IFractal<double>
    {
        private const int MaxIterations = 100;

        public string Name { get; set; }

        public double Xmin { get; set; }
        public double Xmax { get; set; }
        public double Ymin { get; set; }
        public double Ymax { get; set; }

        private double GetDeltaX(int resolutionX)
        {
            return (Xmax - Xmin) / resolutionX;
        }

        private double GetDeltaY(int resolutionY)
        {
            return (Ymax - Ymin) / resolutionY;
        }

        public double CalculateAtPosition(int xPos, int yPos, int resolutionX, int resolutionY)
        {
            double x0 = RealXPosition(xPos, resolutionX);
            double y0 = RealYPosition(yPos, resolutionY);

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

        private double RealXPosition(int x, int width)
        {
            return Xmin + (x * GetDeltaX(width));
        }

        private double RealYPosition(int y, int height)
        {
            return Ymax - (y * GetDeltaY(height));
        }

        public string GetRealXPosition(int x, int width)
        {
            return RealXPosition(x, width).ToString();
        }


        public string GetRealYPosition(int y, int height)
        {
            return RealXPosition(y, height).ToString();
        }
    }
}