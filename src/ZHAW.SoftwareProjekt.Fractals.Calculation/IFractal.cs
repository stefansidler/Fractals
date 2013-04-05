using System;

namespace ZHAW.SoftwareProjekt.Fractals.Calculation
{
    public interface IFractal<T> : IFractal
    {
        string Name { get; set; }
        T Xmin { get; set; }
        T Xmax { get; set; }
        T Ymin { get; set; }
        T Ymax { get; set; }
    }

    public interface IFractal
    {
        double CalculateAtPosition(int xPos, int yPos, int resolutionX, int resolutionY);
        string GetRealXPosition(int x, int width);
        string GetRealYPosition(int y, int height);
    }
}
