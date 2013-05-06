using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Threading.Tasks;
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
            fractalsList.Items.Add(new Mandelbrot { Name = "Mandelbrot - standard 1", Xmin = -2.1, Xmax = 1.0, Ymin = -1.3, Ymax = 1.3 });
            fractalsList.Items.Add(new Mandelbrot { Name = "Mandelbrot - standard 2", Xmin = -1.41625852044, Xmax = -1.34883934224, Ymin = 0.0121250642032, Ymax = 0.0194777201008 });
            fractalsList.Items.Add(new Mandelbrot { Name = "Mandelbrot - standard 3", Xmin = -1.29746953237867, Xmax = -1.29368412662443, Ymin = -0.441966505864, Ymax = -0.4416893457808 });
            fractalsList.Items.Add(new Mandelbrot { Name = "Mandelbrot - View 1", Xmin = -0.8, Xmax = -0.7, Ymin = 0.1, Ymax = 0.2 });
            fractalsList.Items.Add(new Mandelbrot { Name = "Mandelbrot - View 2", Xmin = -0.795, Xmax = -0.78, Ymin = 0.138, Ymax = 0.15 });
            fractalsList.Items.Add(new Mandelbrot { Name = "Mandelbrot - View 2b", Xmin = -0.795123412341234, Xmax = -0.781234123412341, Ymin = 0.138123412341234, Ymax = 0.15123412341234 });
            fractalsList.Items.Add(new Mandelbrot
            {
                Name = "Mandelbrot - View 3",
                Xmin = -1.62828525881663,
                Xmax = -1.6282852577093,
                Ymin = 0.0219804615787984,
                Ymax = 0.0219804622437201
            });
            fractalsList.Items.Add(new MandelbrotBigFloat
                {
                    Name = "BigFloat Mandelbrot 1",
                    Xmin = -2.1m,
                    Xmax = 1.0m,
                    Ymin = -1.3m,
                    Ymax = 1.3m
                });
            fractalsList.Items.Add(new MandelbrotBigFloat
            {
                Name = "BigFloat Mandelbrot 2",
                Xmin = -1.41625852044m,
                Xmax = -1.34883934224m,
                Ymin = 0.0121250642032m,
                Ymax = 0.0194777201008m
            });
            fractalsList.Items.Add(new MandelbrotBigFloat
            {
                Name = "BigFloat Mandelbrot zoom",
                Xmin = -0.6052749178365117m,
                Xmax = -0.6052749178365141m,
                Ymin = 0.45183156022113447m,
                Ymax = 0.45183156022113286m
            });

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
            //fractal.Xmin = zoomXmin.Text;
            //fractal.Xmax = zoomXmax.Text;
            //fractal.Ymin = zoomYmin.Text;
            //fractal.Ymax = zoomYmax.Text;

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            toolStripProgressBar1.Visible = true;

            Task.Factory.StartNew(() =>
                {
                    fractalPictureBox.Image = _fractalRenderer.Render(fractal, fractalPictureBox.Width, fractalPictureBox.Height);
                }).ContinueWith(_ =>
                    {
                        BeginInvoke((Action) (() =>
                            {
                                stopwatch.Stop();
                                toolStripStatusLabel3.Text = stopwatch.Elapsed.ToString();
                                toolStripProgressBar1.Visible = false;
                            }));
                    });
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
            //zoomXmin.Text = CurrentFractal.Xmin;
            //zoomXmax.Text = CurrentFractal.Xmax;
            //zoomYmin.Text = CurrentFractal.Ymin;
            //zoomYmax.Text = CurrentFractal.Ymax;
        }
    }
}
