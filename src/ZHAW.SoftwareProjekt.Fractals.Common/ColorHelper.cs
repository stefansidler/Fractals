using System.Drawing;

namespace ZHAW.SoftwareProjekt.Fractals.Common
{
    public class ColorHelper
    {
        private static Color[] _colorMap;

        public static Color GetColor(double percent)
        {
            if (_colorMap == null)
            {
                _colorMap = new Color[256];
                for (int i = 0; i < _colorMap.Length; i++)
                {
                    _colorMap[i] = Color.FromArgb(i, 50, 255 - i);
                }
            }
            return _colorMap[(int) (percent * 255)];
        }
    }
}
