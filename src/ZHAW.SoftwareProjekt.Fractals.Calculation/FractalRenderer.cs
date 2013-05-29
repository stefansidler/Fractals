using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using ZHAW.SoftwareProjekt.Fractals.Common;

namespace ZHAW.SoftwareProjekt.Fractals.Calculation
{
    public class FractalRenderer : IFractalRenderer
    {
        public Bitmap Render(IFractal fractal, int width, int height)
        {
            var fractalImage = new Bitmap(width, height);

            BitmapData data = fractalImage.LockBits(new Rectangle(0, 0, fractalImage.Width, fractalImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            int stride = data.Stride;

            Parallel.For(0, width, w =>
            {
                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    for (int h = 1; h < height; h++)
                    {
                        var color = ColorHelper.GetColor(fractal.CalculateAtPosition(w, h, width, height));
                        ptr[(w * 3) + h * stride] = color.B;
                        ptr[(w * 3) + h * stride + 1] = color.G;
                        ptr[(w * 3) + h * stride + 2] = color.R;
                    }
                }
            });
            fractalImage.UnlockBits(data);

            return fractalImage;
        }
    }
}
