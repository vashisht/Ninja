using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;

namespace NinjaLista.Web.CaptchaServices
{
    public class DefaultCaptchaService : ICaptchaService
    {
        private int width = 200;
        private int height = 100;
        private string familyName = "Verdana";
        private string text = "Dogsniffer";
        private readonly Random random = new Random();

        public Bitmap GetCaptcha(string captchaString)
        {
            text = captchaString;
            // Create a new 32-bit bitmap image.

            Bitmap bitmap = new Bitmap(
              this.width,
              this.height,
              PixelFormat.Format32bppArgb);

            // Create a graphics object for drawing.

            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, this.width, this.height);

            // Fill in the background.

            HatchBrush hatchBrush = new HatchBrush(
              HatchStyle.SmallConfetti,
              Color.LightGray,
              Color.White);
            g.FillRectangle(hatchBrush, rect);

            // Set up the text font.

            SizeF size;
            float fontSize = rect.Height + 1;
            Font font;
            // Adjust the font size until the text fits within the image.

            do
            {
                fontSize--;
                font = new Font(
                  this.familyName,
                  fontSize,
                  FontStyle.Bold);
                size = g.MeasureString(this.text, font);
            } while (size.Width > rect.Width);

            // Set up the text format.

            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            // Create a path using the text and warp it randomly.

            GraphicsPath path = new GraphicsPath();
            path.AddString(
              this.text,
              font.FontFamily,
              (int)font.Style,
              font.Size, rect,
              format);
            float v = 4F;
            PointF[] points =
      {
        new PointF(
          this.random.Next(rect.Width) / v,
          this.random.Next(rect.Height) / v),
        new PointF(
          rect.Width - this.random.Next(rect.Width) / v,
          this.random.Next(rect.Height) / v),
        new PointF(
          this.random.Next(rect.Width) / v,
          rect.Height - this.random.Next(rect.Height) / v),
        new PointF(
          rect.Width - this.random.Next(rect.Width) / v,
          rect.Height - this.random.Next(rect.Height) / v)
      };
            Matrix matrix = new Matrix();
            matrix.Translate(0F, 0F);
            path.Warp(points, rect, matrix, WarpMode.Perspective, 0F);

            // Draw the text.

            hatchBrush = new HatchBrush(
              HatchStyle.LargeConfetti,
              Color.LightGray,
              Color.DarkGray);
            g.FillPath(hatchBrush, path);

            // Add some random noise.

            int m = Math.Max(rect.Width, rect.Height);
            for (int i = 0; i < (int)(rect.Width * rect.Height / 30F); i++)
            {
                int x = this.random.Next(rect.Width);
                int y = this.random.Next(rect.Height);
                int w = this.random.Next(m / 50);
                int h = this.random.Next(m / 50);
                g.FillEllipse(hatchBrush, x, y, w, h);
            }

            // Clean up.

            font.Dispose();
            hatchBrush.Dispose();
            g.Dispose();

            
            return bitmap;
        }

        public Bitmap GetCaptcha(string captchaString, int width, int height)
        {
            this.width = width;
            this.height = height;

            return GetCaptcha(captchaString);
        }

















        // Define default min and max password lengths.
        private int DEFAULT_MIN_PASSWORD_LENGTH = 6;
        private int DEFAULT_MAX_PASSWORD_LENGTH = 6;

        // Define supported password characters divided into groups.
        // You can add (or remove) characters to (from) these groups.
        private string PASSWORD_CHARS_LCASE = "abcdefgijkmnopqrstwxyz";
        private string PASSWORD_CHARS_UCASE = "ABCDEFGHJKLMNPQRSTWXYZ";
        private string PASSWORD_CHARS_NUMERIC = "23456789";
        private string PASSWORD_CHARS_SPECIAL = "*$&!";

        /// <summary>
        /// Generates a random password.
        /// </summary>
        /// <returns>
        /// Randomly generated password.
        /// </returns>
        /// <remarks>
        /// The length of the generated password will be determined at
        /// random. It will be no shorter than the minimum default and
        /// no longer than maximum default.
        /// </remarks>
        public string GenerateRandomString()
        {
            return GenerateRandomString(DEFAULT_MIN_PASSWORD_LENGTH,
                            DEFAULT_MAX_PASSWORD_LENGTH);
        }

        /// <summary>
        /// Generates a random password of the exact length.
        /// </summary>
        /// <param name="length">
        /// Exact password length.
        /// </param>
        /// <returns>
        /// Randomly generated password.
        /// </returns>
        public string GenerateRandomString(int length)
        {
            return GenerateRandomString(length, length);
        }

        /// <summary>
        /// Generates a random password.
        /// </summary>
        /// <param name="minLength">
        /// Minimum password length.
        /// </param>
        /// <param name="maxLength">
        /// Maximum password length.
        /// </param>
        /// <returns>
        /// Randomly generated password.
        /// </returns>
        /// <remarks>
        /// The length of the generated password will be determined at
        /// random and it will fall with the range determined by the
        /// function parameters.
        /// </remarks>
        public string GenerateRandomString(int minLength,
                                      int maxLength)
        {
            // Make sure that input parameters are valid.
            if (minLength <= 0 || maxLength <= 0 || minLength > maxLength)
                return null;

            // Create a local array containing supported password characters
            // grouped by types. You can remove character groups from this
            // array, but doing so will weaken the password strength.
            char[][] charGroups = new char[][] 
        {
            PASSWORD_CHARS_LCASE.ToCharArray(),
            PASSWORD_CHARS_UCASE.ToCharArray(),
            PASSWORD_CHARS_NUMERIC.ToCharArray(),
            PASSWORD_CHARS_SPECIAL.ToCharArray()
        };

            // Use this array to track the number of unused characters in each
            // character group.
            int[] charsLeftInGroup = new int[charGroups.Length];

            // Initially, all characters in each group are not used.
            for (int i = 0; i < charsLeftInGroup.Length; i++)
                charsLeftInGroup[i] = charGroups[i].Length;

            // Use this array to track (iterate through) unused character groups.
            int[] leftGroupsOrder = new int[charGroups.Length];

            // Initially, all character groups are not used.
            for (int i = 0; i < leftGroupsOrder.Length; i++)
                leftGroupsOrder[i] = i;

            // Because we cannot use the default randomizer, which is based on the
            // current time (it will produce the same "random" number within a
            // second), we will use a random number generator to seed the
            // randomizer.

            // Use a 4-byte array to fill it with random bytes and convert it then
            // to an integer value.
            byte[] randomBytes = new byte[4];

            // Generate 4 random bytes.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);

            // Convert 4 bytes into a 32-bit integer value.
            int seed = (randomBytes[0] & 0x7f) << 24 |
                        randomBytes[1] << 16 |
                        randomBytes[2] << 8 |
                        randomBytes[3];

            // Now, this is real randomization.
            Random random = new Random(seed);

            // This array will hold password characters.
            char[] password = null;

            // Allocate appropriate memory for the password.
            if (minLength < maxLength)
                password = new char[random.Next(minLength, maxLength + 1)];
            else
                password = new char[minLength];

            // Index of the next character to be added to password.
            int nextCharIdx;

            // Index of the next character group to be processed.
            int nextGroupIdx;

            // Index which will be used to track not processed character groups.
            int nextLeftGroupsOrderIdx;

            // Index of the last non-processed character in a group.
            int lastCharIdx;

            // Index of the last non-processed group.
            int lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;

            // Generate password characters one at a time.
            for (int i = 0; i < password.Length; i++)
            {
                // If only one character group remained unprocessed, process it;
                // otherwise, pick a random character group from the unprocessed
                // group list. To allow a special character to appear in the
                // first position, increment the second parameter of the Next
                // function call by one, i.e. lastLeftGroupsOrderIdx + 1.
                if (lastLeftGroupsOrderIdx == 0)
                    nextLeftGroupsOrderIdx = 0;
                else
                    nextLeftGroupsOrderIdx = random.Next(0,
                                                         lastLeftGroupsOrderIdx);

                // Get the actual index of the character group, from which we will
                // pick the next character.
                nextGroupIdx = leftGroupsOrder[nextLeftGroupsOrderIdx];

                // Get the index of the last unprocessed characters in this group.
                lastCharIdx = charsLeftInGroup[nextGroupIdx] - 1;

                // If only one unprocessed character is left, pick it; otherwise,
                // get a random character from the unused character list.
                if (lastCharIdx == 0)
                    nextCharIdx = 0;
                else
                    nextCharIdx = random.Next(0, lastCharIdx + 1);

                // Add this character to the password.
                password[i] = charGroups[nextGroupIdx][nextCharIdx];

                // If we processed the last character in this group, start over.
                if (lastCharIdx == 0)
                    charsLeftInGroup[nextGroupIdx] =
                                              charGroups[nextGroupIdx].Length;
                // There are more unprocessed characters left.
                else
                {
                    // Swap processed character with the last unprocessed character
                    // so that we don't pick it until we process all characters in
                    // this group.
                    if (lastCharIdx != nextCharIdx)
                    {
                        char temp = charGroups[nextGroupIdx][lastCharIdx];
                        charGroups[nextGroupIdx][lastCharIdx] =
                                    charGroups[nextGroupIdx][nextCharIdx];
                        charGroups[nextGroupIdx][nextCharIdx] = temp;
                    }
                    // Decrement the number of unprocessed characters in
                    // this group.
                    charsLeftInGroup[nextGroupIdx]--;
                }

                // If we processed the last group, start all over.
                if (lastLeftGroupsOrderIdx == 0)
                    lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;
                // There are more unprocessed groups left.
                else
                {
                    // Swap processed group with the last unprocessed group
                    // so that we don't pick it until we process all groups.
                    if (lastLeftGroupsOrderIdx != nextLeftGroupsOrderIdx)
                    {
                        int temp = leftGroupsOrder[lastLeftGroupsOrderIdx];
                        leftGroupsOrder[lastLeftGroupsOrderIdx] =
                                    leftGroupsOrder[nextLeftGroupsOrderIdx];
                        leftGroupsOrder[nextLeftGroupsOrderIdx] = temp;
                    }
                    // Decrement the number of unprocessed groups.
                    lastLeftGroupsOrderIdx--;
                }
            }

            // Convert password characters into a string and return the result.
            return new string(password);
        }

















    }
}
