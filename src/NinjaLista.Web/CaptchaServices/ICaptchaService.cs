using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace NinjaLista.Web.CaptchaServices
{
    public interface ICaptchaService
    {
        Bitmap GetCaptcha(string captchaString);
        Bitmap GetCaptcha(string captchaString, int width, int height);

        string GenerateRandomString();
        string GenerateRandomString(int length);
        string GenerateRandomString(int minLength, int maxLength);
    }
}
