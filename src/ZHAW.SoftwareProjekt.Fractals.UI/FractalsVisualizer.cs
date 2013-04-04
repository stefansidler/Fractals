using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ZHAW.SoftwareProjekt.Fractals.Calculation;

namespace ZHAW.SoftwareProjekt.Fractals.UI
{
    public partial class FractalsVisualizer : Form
    {
        private readonly IFractalRenderer _fractalRenderer;

        private IFractal CurrentFractal
        {
            get { return (IFractal)fractalsList.SelectedItem; }
        }

        public FractalsVisualizer(IFractalRenderer fractalRenderer)
        {
            _fractalRenderer = fractalRenderer;
        }

        public FractalsVisualizer() : this(new FractalRenderer())
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
            fractalsList.Items.Add(new MandelbrotBigFloat
                {
                    Name = "BigFloat Mandelbrot",
                    Xmin = -2.1m,
                    Xmax = 1.0m,
                    Ymin = -1.3m,
                    Ymax = 1.3m
                });

            fractalsList.SelectedIndex = 0;
        }

        private void renderButton_Click(object sender, EventArgs e)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Render(CurrentFractal);

            stopwatch.Stop();
            toolStripStatusLabel3.Text = stopwatch.Elapsed.ToString();
        }

        private void fractalPictureBox_Click(object sender, EventArgs e)
        {
            fractalPictureBox.Image.Save("fractal.png", ImageFormat.Png);
        }

        private void Render(IFractal fractal)
        {
            // todo: error handling
            //fractal.Xmin = zoomXmin.Text;
            //fractal.Xmax = zoomXmax.Text;
            //fractal.Ymin = zoomYmin.Text;
            //fractal.Ymax = zoomYmax.Text;

            fractalPictureBox.Image = _fractalRenderer.Render(fractal, fractalPictureBox.Width, fractalPictureBox.Height);
        }

        private void fractalPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = e.Location.ToString();

            //toolStripStatusLabel2.Text = string.Format("{{X={0}, Y={1}}}",
            //                                           CurrentFractal.GetRealXPosition(e.X, fractalPictureBox.Width),
            //                                           CurrentFractal.GetRealYPosition(e.Y, fractalPictureBox.Height));
        }

        private void fractalsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //zoomXmin.Text = CurrentFractal.Xmin;
            //zoomXmax.Text = CurrentFractal.Xmax;
            //zoomYmin.Text = CurrentFractal.Ymin;
            //zoomYmax.Text = CurrentFractal.Ymax;
        }
    }
}
