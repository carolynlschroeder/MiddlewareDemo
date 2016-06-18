using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo.BusinessLogic
{
    public class BusinessMethods
    {

        public static byte[] ToByteArray(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                return ms.ToArray();
            }
        }

        public static Bitmap ResizeBitmap(string filePath, Size nzMax)
        {
            var b = Image.FromFile(filePath);

            var size = adaptProportionalSize(nzMax, b.Size);
            var result = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(
                    b,
                    new Rectangle(Point.Empty, result.Size),
                    new Rectangle(Point.Empty, b.Size),
                    GraphicsUnit.Pixel);
            }

            return result;
        }

        private static Size adaptProportionalSize(Size szMax, Size szReal)
        {
            int nWidth;
            int nHeight;
            double sMaxRatio;
            double sRealRatio;

            if (szMax.Width < 1 || szMax.Height < 1 || szReal.Width < 1 || szReal.Height < 1)
                return Size.Empty;

            sMaxRatio = (double)szMax.Width / (double)szMax.Height;
            sRealRatio = (double)szReal.Width / (double)szReal.Height;

            if (sMaxRatio < sRealRatio)
            {
                nWidth = Math.Min(szMax.Width, szReal.Width);
                nHeight = (int)Math.Round(nWidth / sRealRatio);
            }
            else
            {
                nHeight = Math.Min(szMax.Height, szReal.Height);
                nWidth = (int)Math.Round(nHeight * sRealRatio);
            }

            return new Size(nWidth, nHeight);
        }

    }
}
