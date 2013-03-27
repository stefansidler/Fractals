namespace ZHAW.SoftwareProjekt.Fractals.Calculation
{
    public interface IFractal
    {
        string Name { get; }
        double Xmin { get; set; }
        double Xmax { get; set; }
        double Ymin { get; set; }
        double Ymax { get; set; }
        double CalculateAtPosition(double x0, double y0, int resolutionX, int resolutionY);
        double GetRealXPosition(double x, int width);
        double GetRealYPosition(double y, int height);
    }
}
