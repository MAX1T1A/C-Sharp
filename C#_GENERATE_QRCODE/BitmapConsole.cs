using System;
using ZXing;
using ZXing.QrCode;
using System.Drawing;
using System.Drawing.Imaging;

namespace QRCodeZX
{
    class BitmapConsole
    {
        public static Bitmap GenerateQRCode(string decQR)
        {
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();

            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 250,
                Height = 250,
            };
            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;

            var qr = new BarcodeWriter();
            qr.Options = options;
            qr.Format = BarcodeFormat.QR_CODE;
            var result = new Bitmap(qr.Write(decQR));

            Image bmp = new Bitmap(result);

            bmp.Save(@"C:\Users\00ARM-IT\Desktop\Hacker\QR.png", ImageFormat.Png);

            return result;
        }

        internal static string GenerateQRCode()
        {
            throw new NotImplementedException();
        }
    }
}
