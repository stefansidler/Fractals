using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;
using ZHAW.SoftwareProjekt.Fractals.Calculation;
using ZHAW.SoftwareProjekt.Fractals.Common;
using ZHAW.SoftwareProjekt.Fractals.UI.TaskScheduler;

namespace ZHAW.SoftwareProjekt.Fractals.UI
{
    public class FractalRenderer : IFractalRenderer
    {
        public Bitmap Render(IFractal fractal, int width, int height)
        {
            var fractalImage = new Bitmap(width, height);

            BitmapData data = fractalImage.LockBits(new Rectangle(0, 0, fractalImage.Width, fractalImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            int stride = data.Stride;

            Parallel.For(0, width, w =>
            {
                unsafe
                {
                    byte* ptr = (byte*)data.Scan0;

                    for (int h = 1; h < height; h++)
                    {
                        var color = ColorHelper.GetColor(fractal.CalculateAtPosition(w, h, width, height));
                        ptr[(w * 3) + h * stride] = color.B;
                        ptr[(w * 3) + h * stride + 1] = color.G;
                        ptr[(w * 3) + h * stride + 2] = color.R;
                    }
                }
            });
            fractalImage.UnlockBits(data);

            return fractalImage;

            //return SingleThread(fractal, width, height);
            //return Parallel1(fractal, width, height);
            //return Parallel2(fractal, width, height);
        }

        private Bitmap SingleThread(IFractal fractal, int width, int height)
        {
            var fractalImage = new Bitmap(width, height);

            for (int w = 1; w < width; w++)
            {
                for (int h = 1; h < height; h++)
                {
                    fractalImage.SetPixel(w, h,
                                          ColorHelper.GetColor(fractal.CalculateAtPosition(w, h,
                                                                                           width,
                                                                                           height)));
                }
            }

            return fractalImage;
        }

        private Bitmap Parallel1(IFractal fractal, int width, int height)
        {
            var fractalImage = new Bitmap(width, height);

            var tasks = new List<Task>();
            var ui = System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext();

            for (int w = 1; w < width; w++)
            {
                int w1 = w;
                for (int h = 1; h < height; h++)
                {
                    int h1 = h;
                    var compute = Task.Factory.StartNew(() => ColorHelper.GetColor(fractal.CalculateAtPosition(w1, h1, width, height)));
                    tasks.Add(compute);

                    var display = compute.ContinueWith(resultTask =>
                        {
                            lock (this)
                            {
                                fractalImage.SetPixel(w1, h1, compute.Result);
                            }
                        }, ui);
                }
            }

            Task.Factory.ContinueWhenAll(tasks.ToArray(), result =>
                {
                    //
                }, CancellationToken.None, TaskContinuationOptions.None, ui);
            return fractalImage;
        }

        private Bitmap Parallel2(IFractal fractal, int width, int height)
        {
            var fractalImage = new Bitmap(width, height);

            var lclts = new LimitedConcurrencyLevelTaskScheduler(4);
            var taskFactory = new TaskFactory(lclts);

            taskFactory.StartNew(() =>
                {
                    for (int w = 1; w < width; w++)
                    {
                        for (int h = 1; h < height; h++)
                        {
                            fractalImage.SetPixel(w, h,
                                                  ColorHelper.GetColor(fractal.CalculateAtPosition(w, h,
                                                                                                   width,
                                                                                                   height)));
                        }
                    }
                });

            return fractalImage;
        }
    }
}
