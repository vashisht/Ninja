using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Drawing;
using NinjaLista.Services;

namespace Ninjalista.Controllers
{
    public class PhotoController : Controller
    {

        [OutputCache(Duration = 20, VaryByParam = "image")]
        public ActionResult SmallthumbnailIcon50(string image)
        {

            return GetThumbnailPhoto(image, 50);
        }

        [OutputCache(Duration = 20, VaryByParam = "image")]
        public ActionResult SmallthumbnailIcon90(string image)
        {

            return GetThumbnailPhoto(image, 90);
        }

        [OutputCache(Duration = 20, VaryByParam = "image")]
        public ActionResult RandomGallerySizeImage(string image)
        {

            return GetThumbnailPhoto(image, 260);
        }

        [OutputCache(Duration = 20, VaryByParam = "image")]
        public ActionResult SmallthumbnailIcon150(string image)
        {

            return GetThumbnailPhoto(image, 150);
        }

        public ActionResult FixedSizeImage(string image, int width, int height)
        {
            if (!System.IO.File.Exists(Server.MapPath(image)))
            {
                image = "/img/Default.png";
            }

            Image imgPhoto = Image.FromFile(Server.MapPath(image));
            var resizedPhoto = NinjaLista.Services.ImageProcessor.Crop(imgPhoto, width, height, NinjaLista.Services.ImageProcessor.AnchorPosition.Center);
            var s = new MemoryStream();

            resizedPhoto.Save(s,
                System.Drawing.Imaging.ImageFormat.Jpeg);
            return File(s.ToArray(), "image/jpeg");
        }

        public ActionResult SmallthumbnailIcon400(string image)
        {
            return GetThumbnailPhoto(image, 400);
        }

        private ActionResult GetThumbnailPhoto(string image, int size)
        {
            if (!System.IO.File.Exists(Server.MapPath(image)))
            {
                image = "/Content/Images/noimage.png";
            }
            var s = GetResizedImageStreamHighQuality(Server.MapPath(image), size);
            return File(s.ToArray(), "image/jpeg");
        }


        private MemoryStream GetResizedImageStreamHighQuality(string file, int maxDim)
        {
            
            using (Bitmap originalImage = new Bitmap(file))
            {
                int h = originalImage.Height;
                int w = originalImage.Width;
                int b = h > w ? h : w;
                double per = (b > maxDim) ? (maxDim * 1.0) / b : 1.0;
                h = (int)(h * per);
                w = (int)(w * per);

                Bitmap newImage = new Bitmap(originalImage, w, h);
                Graphics g = Graphics.FromImage(newImage);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, newImage.Width, newImage.Height);
                
                var s = new MemoryStream();

                newImage.Save(s,
                    System.Drawing.Imaging.ImageFormat.Jpeg);

                return s;
            }
        }
    }
}
