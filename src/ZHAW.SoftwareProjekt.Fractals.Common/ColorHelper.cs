using System;
using System.Collections;
using System.Drawing;
using System.IO;

namespace ZHAW.SoftwareProjekt.Fractals.Common
{
    public class ColorHelper
    {
        private static Color[] _colorMap;

        public static Color GetColor(double percent)
        {
            if (_colorMap == null)
            {
                // random color ------------>
                //_colorMap = new Color[256];
                //for (int i = 0; i < _colorMap.Length; i++)
                //{           
                //    _colorMap[i] = Color.FromArgb((i * 10 + i) % 255,
                //                                  (i * 50 + i) % 255,
                //                                  (i * 100 + i) % 255);
                //}
                // <-------------

                // Colors from file -------->
                //const string pathToColorMapFile = "Colors/color1.ColorMap";
                const string pathToColorMapFile = "Colors/color2.ColorMap";
                _colorMap = GetColors(pathToColorMapFile);
                // <-------------
            }
            return _colorMap[(int) (percent * 255)];
        }


        private static Color[] GetColors(string path)
        {
            try
            {
                var c = new Color[256];
                var sr = new StreamReader(path);
                var lines = new ArrayList();
                var s = sr.ReadLine();
                while (s != null)
                {
                    lines.Add(s);
                    s = sr.ReadLine();
                }
                int i;
                for (i = 0; i < Math.Min(256, lines.Count); i++)
                {
                    var curC = (string)lines[i];
                    var temp = Color.FromArgb(int.Parse(curC.Split(' ')[0]), int.Parse(curC.Split(' ')[1]), int.Parse(curC.Split(' ')[2]));
                    c[i] = temp;
                }
                for (var j = i; j < 256; j++)
                {
                    c[j] = Color.White;
                }
                return c;
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid ColorMap file.", ex);
            }
        }
    }
}
