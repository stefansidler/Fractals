using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ZHAW.SoftwareProjekt.Fractals.Calculation;

namespace ZHAW.SoftwareProjekt.Fractals.UI
{
    public partial class FractalsVisualizer : Form
    {
        private readonly ICalculateFractals _fractalsCalcuator;

        public FractalsVisualizer(ICalculateFractals fractalsCalculator)
        {
            _fractalsCalcuator = fractalsCalculator;
        }

        public FractalsVisualizer() : this(new CalculateFractals())
        {
            InitializeComponent();

            //RenderRandomImage();
            RenderMandelbrot();
        }

        private void RenderMandelbrot()
        {
            var fractal = new Bitmap(fractalPictureBox.Width, fractalPictureBox.Height);

            for (int w = 1; w < fractal.Width; w++)
            {
                for (int h = 1; h < fractal.Height; h++)
                {
                    fractal.SetPixel(w, h, _fractalsCalcuator.CalculateMandelbrotAtPosition(w, h, 100, fractal.Width, fractal.Height));
                }
            }

            fractalPictureBox.Image = fractal;
        }

        private void RenderRandomImage()
        {
            var rand = new Random(DateTime.Now.Millisecond);

            var fractal = new Bitmap(fractalPictureBox.Width, fractalPictureBox.Height);
            for (int x = 1; x < fractal.Width; x++)
            {
                for (int y = 1; y < fractal.Height; y++)
                {
                    fractal.SetPixel(x, y, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)));
                }
            }

            fractalPictureBox.Image = fractal;
        }

        private void fractalPictureBox_Click(object sender, EventArgs e)
        {
            fractalPictureBox.Image.Save("test.png", ImageFormat.Png);
        }
    }
}
