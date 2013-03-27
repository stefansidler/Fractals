using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ZHAW.SoftwareProjekt.Fractals.Calculation;
using ZHAW.SoftwareProjekt.Fractals.Common;

namespace ZHAW.SoftwareProjekt.Fractals.UI
{
    public partial class FractalsVisualizer : Form
    {
        private IFractal CurrentFractal
        {
            get { return (IFractal) fractalsList.SelectedItem; }
        }

        public FractalsVisualizer()
        {
            InitializeComponent();

            LoadFractals();

            //RenderRandomImage();
        }

        private void LoadFractals()
        {
            fractalsList.DisplayMember = "Name";
            fractalsList.Items.Add(new Mandelbrot {Xmin = -2.1, Xmax = 1.0, Ymin = -1.3, Ymax = 1.3});

            fractalsList.SelectedIndex = 0;
        }

        private void renderButton_Click(object sender, EventArgs e)
        {
            Render(CurrentFractal);
        }

        private void fractalPictureBox_Click(object sender, EventArgs e)
        {
            fractalPictureBox.Image.Save("fractal.png", ImageFormat.Png);
        }

        private void Render(IFractal fractal)
        {
            var fractalImage = new Bitmap(fractalPictureBox.Width, fractalPictureBox.Height);

            for (int w = 1; w < fractalImage.Width; w++)
            {
                for (int h = 1; h < fractalImage.Height; h++)
                {
                    fractalImage.SetPixel(w, h, ColorHelper.GetColor(fractal.CalculateAtPosition(w, h, fractalImage.Width, fractalImage.Height)));
                }
            }

            fractalPictureBox.Image = fractalImage;
        }

        private void RenderRandomImage()
        {
            var rand = new Random(DateTime.Now.Millisecond);

            var randomImage = new Bitmap(fractalPictureBox.Width, fractalPictureBox.Height);
            for (int x = 1; x < randomImage.Width; x++)
            {
                for (int y = 1; y < randomImage.Height; y++)
                {
                    randomImage.SetPixel(x, y, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)));
                }
            }

            fractalPictureBox.Image = randomImage;
        }

        private void fractalPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = e.Location.ToString();

            toolStripStatusLabel2.Text = string.Format("{{X={0}, Y={1}}}",
                                                       CurrentFractal.GetRealXPosition(e.X, fractalPictureBox.Width),
                                                       CurrentFractal.GetRealYPosition(e.Y, fractalPictureBox.Height));
        }
    }
}
