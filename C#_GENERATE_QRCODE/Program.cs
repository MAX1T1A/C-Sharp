using System;
using System.Windows.Forms;
using System.Drawing;
using ZXing;

namespace QRCodeZX
{
    class Program
    {

        private const double WIDTH_OFFSET = 2;
        private const int MAX_WIDTH = 100;

        [STAThread]
        static void Main(string[] args)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Images | *.png"
            };

            Console.Write("Enter the text you want to encode: ");

            string qrCodeText = "Путь файла";
            


            var bitmap = new Bitmap(BitmapConsole.GenerateQRCode(qrCodeText));
            bitmap = ResizeBitmap(bitmap);
            bitmap.ToGrayscale();

            var converter = new BitmapConverter(bitmap);
            var rows = converter.Convert();

            foreach (var row in rows)
                Console.WriteLine(row);


            Console.WriteLine("\n\n\n" + DecodeQRCode(BitmapConsole.GenerateQRCode(qrCodeText)).ToUpper());
            
        }

        private static Bitmap ResizeBitmap(Bitmap bitmap)
        {
            var newHeight = bitmap.Height / WIDTH_OFFSET * MAX_WIDTH / bitmap.Width;
            if (bitmap.Width > MAX_WIDTH || bitmap.Height > newHeight)
                bitmap = new Bitmap(bitmap, new Size(MAX_WIDTH, (int)newHeight));
            return bitmap;
        }

        public static string DecodeQRCode(Bitmap qrCode)
        {
            Bitmap bitmap = new Bitmap(qrCode);
            BarcodeReader reader = new BarcodeReader { AutoRotate = true };
            Result result = reader.Decode(bitmap);
            string decoded = result.ToString().Trim();
            return decoded;
        }
    }
}
