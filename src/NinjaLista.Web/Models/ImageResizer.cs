using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;

namespace NinjaLista.Models
{
    public class ImageResizer
    {

        public void Resize(Stream file,string outputFileName,string width)
        {
            Image image = Image.FromStream(file);
            double newWidth = int.Parse(width);
            var current = image.Width;
            double scaleHeight = (newWidth / current);
            int newHeight = Convert.ToInt32(image.Height * scaleHeight);
            var thumbnailBitmap = new Bitmap((int)newWidth, (int)newHeight);
            Graphics thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
            thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

            var imageRectangle = new Rectangle(0, 0, (int)newWidth, (int)newHeight);
            thumbnailGraph.DrawImage(image, imageRectangle);

//            if (!Directory.Exists(outputFileName))
//                Directory.CreateDirectory(path);

            //File.WriteAllBytes(outputFileName, mediaItem.Content);
            thumbnailBitmap.Save(outputFileName, image.RawFormat);
                
        }
    }
}