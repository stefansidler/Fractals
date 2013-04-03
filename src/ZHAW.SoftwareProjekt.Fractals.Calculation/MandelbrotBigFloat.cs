using ZHAW.SoftwareProjekt.Fractals.DataStructures;

namespace ZHAW.SoftwareProjekt.Fractals.Calculation
{
    public class MandelbrotBigFloat : IFractal
    {
        private const int MaxIterations = 15;

        public string Name { get; set; }

        public string Xmin { get; set; }
        public string Xmax { get; set; }
        public string Ymin { get; set; }
        public string Ymax { get; set; }

        private BigFloat GetDeltaX(int resolutionX)
        {
            return (((BigFloat)Xmax - Xmin) / resolutionX);
        }

        private BigFloat GetDeltaY(int resolutionY)
        {
            return (((BigFloat)Ymax - Ymin) / resolutionY);
        }

        public double CalculateAtPosition(int xPos, int yPos, int resolutionX, int resolutionY)
        {
            BigFloat x0 = xPos;
            BigFloat y0 = yPos;
            //x0 = GetRealXPosition(x0, resolutionX);
            //y0 = GetRealYPosition(y0, resolutionY);
            x0 = Xmin + (x0*GetDeltaX(resolutionX));
            y0 = Ymax - (y0*GetDeltaY(resolutionY));

            var iterations = 0;
            BigFloat x = 0.0m;
            BigFloat y = 0.0m;
            var abort = new BigFloat(2, 0);
            while (iterations < MaxIterations && BigFloat.Sqrt(((x * x) + (y * y))) < abort)
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
            return (Xmin + (x * GetDeltaX(width))).ToString();
        }

        public string GetRealYPosition(int y, int height)
        {
            return (Ymax - (y * GetDeltaY(height))).ToString();
        }
    }
}
