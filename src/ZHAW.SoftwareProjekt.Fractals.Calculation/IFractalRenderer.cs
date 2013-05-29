using System.Drawing;

namespace ZHAW.SoftwareProjekt.Fractals.Calculation
{
    public interface IFractalRenderer
    {
        Bitmap Render(IFractal fractal, int width, int height);
    }
}
