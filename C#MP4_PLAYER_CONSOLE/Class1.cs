using System;
using ZXing;
using ZXing.QrCode;
using System.Drawing;
using System.Drawing.Imaging;

namespace ASCTwo
{
    class Class1
    {
        static Bitmap GenerateQRCode()
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

            var qr = new ZXing.BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;
            var result = new Bitmap(qr.Write("Anton is a shit coder"));

            Image bmp = new Bitmap(result);

            bmp.Save(@"C:\Users\00ARM-IT\Desktop\Hacker\QR.png", ImageFormat.Png);

            return result;
        }

        static void DecodeQRCode(Bitmap qrCode)
        {
            Bitmap bitmap = new Bitmap(qrCode);
            BarcodeReader reader = new BarcodeReader { AutoRotate = true };
            Result result = reader.Decode(bitmap);
            string decoded = result.ToString().Trim();
            Console.WriteLine(decoded);
        }

        static void Main(string[] args)
        {
            DecodeQRCode(GenerateQRCode());
        }
    }
}
