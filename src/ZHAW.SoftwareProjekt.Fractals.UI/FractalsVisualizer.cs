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
        }

        private void LoadFractals()
        {
            fractalsList.DisplayMember = "Name";
            fractalsList.Items.Add(new Mandelbrot { Name = "Mandelbrot - standard", Xmin = -2.1, Xmax = 1.0, Ymin = -1.3, Ymax = 1.3 });
            fractalsList.Items.Add(new Mandelbrot { Name = "Mandelbrot - View 1", Xmin = -0.8, Xmax = -0.7, Ymin = 0.1, Ymax = 0.2 });
            fractalsList.Items.Add(new Mandelbrot { Name = "Mandelbrot - View 2", Xmin = -0.795, Xmax = -0.78, Ymin = 0.138, Ymax = 0.15 });

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
            // todo: error handling
            fractal.Xmin = double.Parse(zoomXmin.Text);
            fractal.Xmax = double.Parse(zoomXmax.Text);
            fractal.Ymin = double.Parse(zoomYmin.Text);
            fractal.Ymax = double.Parse(zoomYmax.Text);

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

        private void fractalPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = e.Location.ToString();

            toolStripStatusLabel2.Text = string.Format("{{X={0}, Y={1}}}",
                                                       CurrentFractal.GetRealXPosition(e.X, fractalPictureBox.Width),
                                                       CurrentFractal.GetRealYPosition(e.Y, fractalPictureBox.Height));
        }

        private void fractalsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            zoomXmin.Text = CurrentFractal.Xmin.ToString();
            zoomXmax.Text = CurrentFractal.Xmax.ToString();
            zoomYmin.Text = CurrentFractal.Ymin.ToString();
            zoomYmax.Text = CurrentFractal.Ymax.ToString();
        }
    }
}
