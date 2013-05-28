using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZHAW.SoftwareProjekt.Fractals.Calculation;

namespace ZHAW.SoftwareProjekt.Fractals.UI
{
    public partial class FractalsVisualizer : Form
    {
        private readonly IFractalRenderer _fractalRenderer;

        private Mandelbrot CurrentMandelbrot { get; set; }
        private MandelbrotBigFloat CurrentMandelbrotBigFloat { get; set; }

        public FractalsVisualizer(IFractalRenderer fractalRenderer)
        {
            _fractalRenderer = fractalRenderer;
            CurrentMandelbrot = new Mandelbrot
                {
                    Name = "Mandelbrot - standard",
                    Xmin = -2.1,
                    Xmax = 1.0,
                    Ymin = -1.3,
                    Ymax = 1.3
                };
            CurrentMandelbrotBigFloat = new MandelbrotBigFloat
                {
                    Name = "Mandelbrot - BigFloat",
                    Xmin = -2.1m,
                    Xmax = 1.0m,
                    Ymin = -1.3m,
                    Ymax = 1.3m
                };
            //CurrentMandelbrot = new Mandelbrot
            //    {
            //        Name = "blubb",
            //        Xmin = -1.78662498571429,
            //        Xmax = -1.78661186268222,
            //        Ymin = -3.03206997084615E-06,
            //        Ymax = 5.30612244897886E-06
            //    };
            //CurrentMandelbrotBigFloat = new MandelbrotBigFloat
            //    {
            //        Name = "blubb",
            //        Xmin = -1.78662498571429m,
            //        Xmax = -1.78661186268222m,
            //        Ymin = -3.03206997084615E-06m,
            //        Ymax = 5.30612244897886E-06m
            //    };
            CurrentMandelbrot = new Mandelbrot
                {
                    Name = "blubb",
                    Xmin = -1.78662403858534,
                    Xmax = -1.78662403858377,
                    Ymin = -4.08684051856092E-08,
                    Ymax = -4.0867685065834E-08
                };
            CurrentMandelbrotBigFloat = new MandelbrotBigFloat
                {
                    Name = "blubb",
                    Xmin = -1.78662403858534m,
                    Xmax = -1.78662403858377m,
                    Ymin = -4.08684051856092E-08m,
                    Ymax = -4.0867685065834E-08m
                };
        }

        public FractalsVisualizer()
            : this(new FractalRenderer())
        {
            InitializeComponent();
        }

        private void renderButton_Click(object sender, EventArgs e)
        {
            Render(CurrentMandelbrot, CurrentMandelbrotBigFloat);
        }

        private void fractalPictureBox_Click(object sender, EventArgs e)
        {
            //nativeFractalPictureBox.Image.Save("fractal.png", ImageFormat.Png);
        }

        private void Render(IFractal fractal1, IFractal fractal2)
        {
            // todo: error handling

            var maxIterations = int.Parse(maxIterationsText.Text);
            fractal1.MaxIterations = maxIterations;
            fractal2.MaxIterations = maxIterations;

            var stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            toolStripProgressBar1.Visible = true;

            Task.Factory.StartNew(() =>
                {
                    nativeFractalPictureBox.Image = _fractalRenderer.Render(fractal1, nativeFractalPictureBox.Width,
                                                                            nativeFractalPictureBox.Height);
                }).ContinueWith(_ =>
                    {
                        BeginInvoke((Action) (() =>
                            {
                                stopwatch1.Stop();
                                timeSpent1Label.Text = stopwatch1.Elapsed.ToString();
                            }));
                    });


            var stopwatch2 = new Stopwatch();
            stopwatch2.Start();

            Task.Factory.StartNew(() =>
                {
                    bigFloatFractalPictureBox.Image = _fractalRenderer.Render(fractal2, bigFloatFractalPictureBox.Width,
                                                                              bigFloatFractalPictureBox.Height);
                }).ContinueWith(_ =>
                    {
                        BeginInvoke((Action) (() =>
                            {
                                stopwatch2.Stop();
                                timeSpent2Label.Text = stopwatch2.Elapsed.ToString();
                                toolStripProgressBar1.Visible = false;
                            }));
                    });
        }

        private string GetRealCoordinates(IFractal fractal, Point mouseLocation)
        {
            return string.Format("{{X={0}, Y={1}}}",
                                 fractal.GetRealXPosition(mouseLocation.X, nativeFractalPictureBox.Width),
                                 fractal.GetRealYPosition(mouseLocation.Y, nativeFractalPictureBox.Height));
        }

        private void nativeFractalPictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ZoomIn(new Point(e.Location.X, e.Location.Y));
        }

        private void bigFloatFractalPictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ZoomIn(new Point(e.Location.X, e.Location.Y));
        }

        private void ZoomIn(Point newCenter)
        {
            double zoom = zoom10x.Checked ? 10 : zoom100x.Checked ? 100 : zoom1000x.Checked ? 1000 : 10;

            Render(CurrentMandelbrot.Zoom(zoom, newCenter, nativeFractalPictureBox.Width, nativeFractalPictureBox.Height),
                   CurrentMandelbrotBigFloat.Zoom(zoom, newCenter, bigFloatFractalPictureBox.Width,
                                                  bigFloatFractalPictureBox.Height));
        }

        private void bigFloatFractalPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = e.Location.ToString();
            toolStripStatusLabel2.Text = GetRealCoordinates(CurrentMandelbrotBigFloat, e.Location);
        }

        private void fractalPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = e.Location.ToString();
            toolStripStatusLabel2.Text = GetRealCoordinates(CurrentMandelbrot, e.Location);
        }
    }
}
