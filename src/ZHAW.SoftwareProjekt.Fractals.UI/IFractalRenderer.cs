using System.Drawing;
using ZHAW.SoftwareProjekt.Fractals.Calculation;

namespace ZHAW.SoftwareProjekt.Fractals.UI
{
    public interface IFractalRenderer
    {
        Bitmap Render(IFractal fractal, int width, int height);
    }
}
