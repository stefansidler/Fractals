using System;
using System.Drawing;

namespace ZHAW.SoftwareProjekt.Fractals.Calculation
{
    public class CalculateFractals : ICalculateFractals
    {
        private Color[] _colorMap;

        public CalculateFractals()
        {
            _colorMap = new Color[256];
            for (int i = 0; i < _colorMap.Length; i++)
            {
                _colorMap[i] = Color.FromArgb(i, 50, 255);
            }
        }

        public Color CalculateMandelbrotAtPosition(double x, double y, int iterations, int resolutionX, int resolutionY)
        {
            const double xmin = -2.1;
            const double xmax = 1.0;
            const double ymin = -1.3;
            const double ymax = 1.3;

            double deltaX = ((xmax - xmin) / resolutionX);
            double deltaY = ((ymax - ymin) / resolutionY);

            x = xmin + (x*deltaX);
            y = ymin + (y*deltaY);

            var looper = 0;
            var x1 = 0.0;
            var y1 = 0.0;
            while (looper < iterations && Math.Sqrt((x1 * x1) + (y1 * y1)) < 2)
            {
                looper++;
                double xx = (x1 * x1) - (y1 * y1) + x;
                y1 = 2 * x1 * y1 + y;
                x1 = xx;
            }

            var perc = looper / (double)iterations;
            var val = ((int)(perc * 255));

            return GetColor(val);
        }

        private Color GetColor(int val)
        {
            return _colorMap[val];
        }
    }
}