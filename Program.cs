using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;

namespace QRCodeGenerate
{
    class Program
    {
        static void Main(string[] args)
        {
            object[][] qrCode = new object[10][];

            qrCode[0] = new object[] { "#", "#", "#", "#", "#", "#", " ", "#", " ", "#" };
            qrCode[1] = new object[] { "#", " ", " ", " ", " ", "#", " ", 1, 2, 4 };
            qrCode[2] = new object[] { "#", " ", "#", "#", " ", "#", " ", 8, 16, 32 };
            qrCode[3] = new object[] { "#", " ", "#", "#", " ", "#", " ", 1, 2, 4 };
            qrCode[4] = new object[] { "#", " ", " ", " ", " ", "#", " ", 8, 16, 32 };
            qrCode[5] = new object[] { "#", "#", "#", "#", "#", "#", " ", 1, 2, 4 };
            qrCode[6] = new object[] { " ", " ", " ", " ", " ", " ", " ", 8, 16, 32 };
            qrCode[7] = new object[] { "#", 1, 2, 1, 2, 1, 2, 1, 2, 4 };
            qrCode[8] = new object[] { " ", 4, 8, 4, 8, 4, 8, 8, 16, 32 };
            qrCode[9] = new object[] { "#", 16, 32, 16, 32, 16, 32, "#", " ", "#" };


            Console.Write("Какое слвово(только русский афавит) вы хотите закодировать(от 1 до 7): ");
            string words = Console.ReadLine().ToLower();
            if (words.Length < 1 || words.Length > 7)
            {
                Console.WriteLine("В не диапазона!");
            }
            else
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (i == 0)
                    {
                        Coding.ShitCoding(qrCode, words[i].ToString(), 2, 1, 7, 8, 9);
                    }
                    if (i == 1)
                    {
                        Coding.ShitCoding(qrCode, words[i].ToString(), 4, 3, 7, 8, 9);
                    }
                    if (i == 2)
                    {
                        Coding.ShitCoding(qrCode, words[i].ToString(), 6, 5, 7, 8, 9);
                    }
                    if (i == 3)
                    {
                        Coding.ShitCoding(qrCode, words[i].ToString(), 8, 7, 7, 8, 9);
                    }
                    if (i == 4)
                    {
                        CodingHorizontal.EndWay(qrCode, words[i].ToString(), 6, 5, 7, 8, 9);
                    }
                    if (i == 5)
                    {
                        CodingHorizontal.EndWay(qrCode, words[i].ToString(), 4, 3, 7, 8, 9);
                    }
                    if (i == 6)
                    {
                        CodingHorizontal.EndWay(qrCode, words[i].ToString(), 2, 1, 7, 8, 9);
                    }
                }

                //Удаление лишних чисел
                double num;
                for (int i = 0; i < qrCode.Length; i++)
                {
                    for (int j = 0; j < qrCode[i].Length; j++)
                    {
                        if (double.TryParse(qrCode[i][j].ToString(), out num))
                        {
                            qrCode[i][j] = " ";
                        }
                    }

                }


                //Вывод QR-Code в консоль
                for (int i = 0; i < qrCode.Length; i++)
                {
                    for (int j = 0; j < qrCode[i].Length; j++)
                    {
                        Console.Write(qrCode[i][j] + " ");
                    }
                    Console.WriteLine();
                }

                Photo(qrCode);

            }

        }

        const int Pixel_Size = 20;
        public static void Photo(object[][] qrCode)
        {
            Bitmap Result = new Bitmap(qrCode.Length * Pixel_Size, qrCode.Length * Pixel_Size);
            Graphics Gr = Graphics.FromImage(Result);

            for (int y = 0; y < qrCode.Length; y++)
            {
                for (int x = 0; x < qrCode[y].Length; x++)
                {
                    if (qrCode[y][x].ToString() == "#")
                    {
                        Gr.FillRectangle(Brushes.Black, new Rectangle(new Point(x * Pixel_Size, y * Pixel_Size), new Size(Pixel_Size, Pixel_Size)));
                    }
                    
                }
            }
            Console.WriteLine("PNG Save");
            Result.Save(@"C:\Users\00ARM-IT\Desktop\Hacker\QRCode.png", ImageFormat.Png);
            
        }

    }
}
