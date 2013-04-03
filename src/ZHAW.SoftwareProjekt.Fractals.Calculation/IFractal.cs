namespace ZHAW.SoftwareProjekt.Fractals.Calculation
{
    public interface IFractal
    {
        string Name { get; set; }
        string Xmin { get; set; }
        string Xmax { get; set; }
        string Ymin { get; set; }
        string Ymax { get; set; }
        double CalculateAtPosition(int xPos, int yPos, int resolutionX, int resolutionY);
        string GetRealXPosition(int x, int width);
        string GetRealYPosition(int y, int height);
    }
}
