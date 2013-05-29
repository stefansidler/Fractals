using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZHAW.SoftwareProjekt.Fractals.Calculation;

namespace ZHAW.SoftwareProjekt.Fractals.UI.MandelbrotDemo
{
    public partial class MandelbrotVisualizer : Form
    {
        private IFractalRenderer _fractalRenderer;

        protected IFractal CurrentMandelbrot { get; set; }

        public MandelbrotVisualizer(IFractalRenderer fractalRenderer)
        {
            _fractalRenderer = fractalRenderer;

            CurrentMandelbrot = new Mandelbrot
            {
                Name = "Mandelbrot - standard",
                Xmin = -2.1,
                Xmax = 1.0,
                Ymin = -1.3,
                Ymax = 1.3,
                MaxIterations = 100
            };
        }

        public MandelbrotVisualizer() 
            : this(new FractalRenderer())
        {
            InitializeComponent();
        }

        private void Render(IFractal fractal)
        {
            var mandelbrot = (Mandelbrot) fractal;
            xminLabel.Text = mandelbrot.Xmin.ToString();
            xmaxLabel.Text = mandelbrot.Xmax.ToString();
            yminLabel.Text = mandelbrot.Ymin.ToString();
            ymaxLabel.Text = mandelbrot.Ymax.ToString();

            Task.Factory.StartNew(() =>
            {
                pictureBox1.Image = _fractalRenderer.Render(fractal, pictureBox1.Width,
                                                                        pictureBox1.Height);
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CurrentMandelbrot.MaxIterations = int.Parse(maxIterationsText.Text);
            Render(CurrentMandelbrot);
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ZoomIn(new Point(e.Location.X, e.Location.Y));
        }

        private void ZoomIn(Point newCenter)
        {
            double zoom = 100;

            Render(CurrentMandelbrot.Zoom(zoom, newCenter, pictureBox1.Width, pictureBox1.Height));
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            CurrentMandelbrot = new Mandelbrot
            {
                Name = "Mandelbrot - standard",
                Xmin = -2.1,
                Xmax = 1.0,
                Ymin = -1.3,
                Ymax = 1.3,
                MaxIterations = int.Parse(maxIterationsText.Text)
            };
            Render(CurrentMandelbrot);
        }
    }
}
