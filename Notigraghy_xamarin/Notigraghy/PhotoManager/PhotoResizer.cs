﻿using Android.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Notigraghy.PhotoManager
{
    public static class PhotoResizer
    {
        public static byte[] ResizeImage(byte[] imageData, float width, float height, int quality)
        {
#if IS_IOS
            return ResizeImageIOS ( imageData, width, height, quality);
#endif
#if IS_ANDROID
            return ResizeImageAndroid ( imageData, width, height, quality );
#endif
        }


#if IS_IOS
        public static byte[] ResizeImageIOS (byte[] imageData, float width, float height, int quality)
        {
            UIImage originalImage = ImageFromByteArray (imageData);


            float oldWidth = (float)originalImage.Size.Width;
            float oldHeight = (float)originalImage.Size.Height;
            float scaleFactor = 0f;

            if (oldWidth > oldHeight)
            {
                scaleFactor = width / oldWidth;
            }
            else
            {
                scaleFactor = height / oldHeight;
            }

            float newHeight = oldHeight * scaleFactor;
            float newWidth = oldWidth * scaleFactor;

            //create a 24bit RGB image
            using (CGBitmapContext context = new CGBitmapContext (IntPtr.Zero,
                (int)newWidth, (int)newHeight, 8,
                (int)(4 * newWidth), CGColorSpace.CreateDeviceRGB (),
                CGImageAlphaInfo.PremultipliedFirst)) {

                RectangleF imageRect = new RectangleF (0, 0, newWidth, newHeight);

                // draw the image
                context.DrawImage (imageRect, originalImage.CGImage);

                UIKit.UIImage resizedImage = UIKit.UIImage.FromImage (context.ToImage ());

                // save the image as a jpeg
                return resizedImage.AsJPEG((float)quality).ToArray();
            }
        }

        public static UIKit.UIImage ImageFromByteArray(byte[] data)
        {
            if (data == null) {
                return null;
            }

            UIKit.UIImage image;
            try {
                image = new UIKit.UIImage(Foundation.NSData.FromArray(data));
            } catch (Exception e) {
                Console.WriteLine ("Image load failed: " + e.Message);
                return null;
            }
            return image;
        }
#endif

#if IS_ANDROID

        public static byte[] ResizeImageAndroid (byte[] imageData, float width, float height, int quality)
        {
        // Load the bitmap
        Bitmap originalImage = BitmapFactory.DecodeByteArray (imageData, 0, imageData.Length);

        float oldWidth = (float)originalImage.Width;
        float oldHeight = (float)originalImage.Height;
        float scaleFactor = 0f;

        if (oldWidth > oldHeight)
        {
            scaleFactor = width / oldWidth;
        }
        else
        {
            scaleFactor = height / oldHeight;
        }

        float newHeight = oldHeight * scaleFactor;
        float newWidth = oldWidth * scaleFactor;

        Bitmap resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int)newWidth, (int)newHeight, false);

        using (MemoryStream ms = new MemoryStream())
        {
        resizedImage.Compress (Bitmap.CompressFormat.Jpeg, quality, ms);
        return ms.ToArray ();
        }
        }

#endif
    }
}


