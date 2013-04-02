using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZHAW.SoftwareProjekt.Fractals.Calculation.Tests
{
    [TestClass]
    public class MandelbrotTests
    {
        [TestMethod]
        public void Mandelbrot_GetRealXPosition_ReturnsCorrectValue()
        {
            var mandelbrot = new Mandelbrot { Name = "Testmandelbrot", Xmin = 0, Xmax = 1, Ymin = 0, Ymax = 1 };

            var x = mandelbrot.GetRealXPosition(50, 100);

            Assert.AreEqual(x, 0.5);
        }
    }
}
