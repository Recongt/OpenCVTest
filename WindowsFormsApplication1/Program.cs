using System;
using OpenCvSharp;

namespace OpenCV
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            using (CvCapture cap = CvCapture.FromCamera(2))
            using (CvWindow w = new CvWindow("OpenCV Example"))
            {
                while (CvWindow.WaitKey(10) < 0)
                {
                    using (IplImage src = cap.QueryFrame())
                    using (IplImage gray = new IplImage(src.Size, BitDepth.U8, 1))
                    using (IplImage dstCanny = new IplImage(src.Size, BitDepth.U8, 1))
                    {
                        src.CvtColor(gray, ColorConversion.BgrToGray);
                        Cv.Canny(gray, dstCanny, 50, 50, ApertureSize.Size3);
                        w.Image = dstCanny;
                    }
                }
            }
        }
    }
}