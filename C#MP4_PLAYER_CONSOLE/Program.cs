using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace ASCTwo
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

            string[] files = Directory.GetFiles("Путь к файлу с кадрами");

            int count = 0;
            while (true)
            {
                var bitmap = new Bitmap(files[count]);
                bitmap = ResizeBitmap(bitmap);
                bitmap.ToGrayscale();

                var converter = new BitmapToASCIIConverter(bitmap);
                var rows = converter.Convert();

                foreach (var row in rows)
                    Console.WriteLine(row);

                Console.SetCursorPosition(0, 0);

                if (count < files.Length)
                    count += 1;
                else
                    break;
                
            }
        }

        private static Bitmap ResizeBitmap(Bitmap bitmap)
        {
            var newHeight = bitmap.Height / WIDTH_OFFSET * MAX_WIDTH / bitmap.Width;
            if (bitmap.Width > MAX_WIDTH || bitmap.Height > newHeight)
                bitmap = new Bitmap(bitmap, new Size(MAX_WIDTH, (int)newHeight));
            return bitmap;
        } 

    }
}
