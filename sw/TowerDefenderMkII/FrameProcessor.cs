using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace TowerDefender
{
    public class FrameProcessor
    {
        //private RGB _color = new RGB(255, 255, 255);
        private RGB _color = new RGB(GlobalVar.Red, GlobalVar.Blue, GlobalVar.Green);
        private int thresh_val = 120;
        private AForge.Point center = new AForge.Point(240, 160);
        private LaserController _controller;
        private BlobCounter bc;
        private bool alreadyZeroized = false;

        public FrameProcessor(LaserController controller)
        {
            _controller = controller;
            var min_size_val = 8;

            bc = new BlobCounter();
            bc.FilterBlobs = true;
            bc.MinHeight = min_size_val;
            bc.MinWidth = min_size_val;
            bc.MaxHeight = min_size_val + 50;
            bc.MaxWidth = min_size_val + 50;
        }

        public Bitmap ProcessFrame(Bitmap frame)
        {
            var filter = new EuclideanColorFiltering();
            _color = new RGB(GlobalVar.Red, GlobalVar.Blue, GlobalVar.Green);
            filter.CenterColor = _color;
            filter.Radius = 20;
            filter.ApplyInPlace(frame);

            //var filter = new Grayscale(0.2125, 0.7154, 0.0721);
            //var thresh = new Threshold(thresh_val);
            //frame = filter.Apply(frame);
            //thresh.ApplyInPlace(frame);

            bc.ProcessImage(frame);
            Rectangle[] rects = bc.GetObjectsRectangles();

            if (rects.Length > 0)
            {
                AForge.Point closest = new AForge.Point(100000, 100000);

                foreach (var r in rects)
                {
                    var p = new AForge.Point(r.Left + r.Width / 2, r.Top + r.Height / 2);

                    var d2 = center.SquaredDistanceTo(closest);
                    var d1 = center.SquaredDistanceTo(p);

                    if (d1 < d2)
                    {
                        closest = p;
                    }
                }

                var closestDistance = center.SquaredDistanceTo(closest);
                var shouldFire = closestDistance < 100; //start firing when close (defualt=20)
                var delta = closest - center;
             //   _controller.Update(delta.X, delta.Y, shouldFire);

                GlobalVar.objectX = closest.X;
                GlobalVar.objectY = closest.Y;
                //send command to move

                if (GlobalVar.calibrationMode)
                {
                    if (GlobalVar.calibrationMoveComplete)
                    {

                        GlobalVar.xRatio = delta.X / 100;
                        //GlobalVar.xRatio = delta.X;

                        if (GlobalVar.xRatio < 0) { GlobalVar.xRatio *= -1; }
                    }
                    else
                    {
                        _controller.Calibrate();
                        GlobalVar.calibrationMoveComplete = true;
                    }
                }
                else
                {
                    _controller.Update(delta.X, delta.Y, shouldFire);
                    alreadyZeroized = false;
                }


                var g = Graphics.FromImage(frame);
                using (Pen p = new Pen(Color.Red))
                {
                    foreach (Rectangle r in rects)
                    {
                        g.DrawRectangle(p, r);
                        g.DrawString("+", new Font("Consolas", 10), Brushes.Red, r.X, r.Y);
                    }
                }
                using (Pen p = new Pen(Color.Green))
                {
                    g.DrawRectangle(p, closest.X - 2, closest.Y - 2, 5, 5);
                }

                GlobalVar.nothingTime = 0;
            }
            else
            {
                //     _controller.Hunt();
                GlobalVar.nothingTimerEnabled = true;
                if (GlobalVar.nothingTime == 150)
                {//10 = 1 second
                    if (!alreadyZeroized)
                    {
                        _controller.FastZeroize();
                        alreadyZeroized = true;
                    }
                }
                if (GlobalVar.nothingTime == 300)
                {//10 = 1 second
                    //GlobalVar.nothingTime = 0;

                    _controller.SlowZeroize();
                    alreadyZeroized = true;
                    GlobalVar.nothingTime = 0;

                }
                /*
                if (GlobalVar.nothingTime == 45)
                {//10 = 1 second
                    _controller.Hunt();
                    alreadyZeroized = false;
                }
                if (GlobalVar.nothingTime == 55)
                    _controller.Hunt();

                if (GlobalVar.nothingTime == 65)
                    _controller.Hunt();

                if (GlobalVar.nothingTime == 75)
                    _controller.Hunt();
                    
                if (GlobalVar.nothingTime == 85)
                    _controller.Hunt();
                
                if (GlobalVar.nothingTime == 90)
                  {
                    GlobalVar.nothingTime = 0;
                     _controller.Hunt();
                  }
                  
                 */

            }

            return frame;
        }

        public void SetColor(Color color)
        {
            _color = new RGB(color);
        }

        public void SetCenter(int p1, int p2)
        {
            center = new AForge.Point(p1, p2);
        }

        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }

    }
}
