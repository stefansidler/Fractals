using System.Drawing;
using ZHAW.SoftwareProjekt.Fractals.Calculation;
using ZHAW.SoftwareProjekt.Fractals.Common;

namespace ZHAW.SoftwareProjekt.Fractals.UI
{
    public class FractalRenderer : IFractalRenderer
    {
        public Bitmap Render(IFractal fractal, int width, int height)
        {
            var fractalImage = new Bitmap(width, height);

            for (int w = 1; w < fractalImage.Width; w++)
            {
                for (int h = 1; h < fractalImage.Height; h++)
                {
                    fractalImage.SetPixel(w, h, ColorHelper.GetColor(fractal.CalculateAtPosition(w, h, fractalImage.Width, fractalImage.Height)));
                }
            }

            return fractalImage;
        }
    }
}
