using System.Drawing;

namespace ZHAW.SoftwareProjekt.Fractals.Calculation
{
    public interface ICalculateFractals
    {
        Color CalculateMandelbrotAtPosition(double x, double y, int iterations, int resolutionX, int resolutionY);
    }
}
