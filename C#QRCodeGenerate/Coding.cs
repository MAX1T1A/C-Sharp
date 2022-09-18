using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeGenerate
{
    class Coding
    {
        public static void ShitCoding(object[][] qrCode, string words, int x1, int x2, int y1, int y2, int y3)
        {
            var list = new List<int>();

            var oneList = new List<int> { 1, 2, 4, 8, 16, 32 };

            var twoList = new List<int> { 3, 5, 6, 9, 10, 12, 17, 18, 20, 24, 33 };
            var threeList = new List<int> { 7, 11, 13, 14, 19, 21, 22, 25, 26, 28 };
            var fourList = new List<int> { 15, 23, 27, 29, 30 };


            Dictionary<string, int> dict = new Dictionary<string, int>
            {
                ["а"] = 1,//  1
                ["б"] = 2,//  1
                ["в"] = 3,//  2 
                ["г"] = 4,//  1
                ["д"] = 5,//  2
                ["е"] = 6,//  2
                ["ё"] = 7,//  3
                ["ж"] = 8,//  1
                ["з"] = 9,//  2
                ["и"] = 10,// 2
                ["й"] = 11,// 3
                ["к"] = 12,// 2
                ["л"] = 13,// 3
                ["м"] = 14,// 3
                ["н"] = 15,// 4
                ["о"] = 16,// 1
                ["п"] = 17,// 2
                ["р"] = 18,// 2
                ["с"] = 19,// 3
                ["т"] = 20,// 2
                ["у"] = 21,// 3
                ["ф"] = 22,// 3
                ["х"] = 23,// 4
                ["ц"] = 24,// 2
                ["ч"] = 25,// 3
                ["ш"] = 26,// 3
                ["щ"] = 27,// 4
                ["ъ"] = 28,// 3
                ["ь"] = 29,// 4
                ["ы"] = 30,// 4
                ["э"] = 31,// 5
                ["ю"] = 32,// 1
                ["я"] = 33 // 2
            };


            //Заполнение list
            for (int i = 0; i < words.Length; i++)
            {
                if (dict.ContainsKey(words[i].ToString()))
                {
                    list.Add(dict[words[i].ToString()]);
                }
                else
                {
                    Console.WriteLine("Ошибка!");
                }
            }


            //Кодирование
            for (int i = 0; i < list.Count; i++)
            {
                //ONE
                if (oneList.Contains(list[i]))
                {
                    for (int j = 0; j < qrCode.Length; j++)
                    {
                        for (int x = 0; x < qrCode[j].Length; x++)
                        {
                            if ((j == x1 || j == x2) && (x == y1 || x == y2 || x == y3))
                            {
                                if ((qrCode[j][x].Equals(list[i]))) // +
                                {
                                    qrCode[j][x] = "#";
                                }
                            }
                        }
                    }
                }
                else if (twoList.Contains(list[i]))
                {
                    for (int n = 0; n < oneList.Count; n++)
                    {
                        for (int v = 0; v < oneList.Count; v++)
                        {
                            //TWO
                            if (oneList[n] + oneList[v] == list[i])
                            {
                                for (int k = 0; k < qrCode.Length; k++)
                                {
                                    for (int l = 0; l < qrCode[k].Length; l++)
                                    {
                                        if ((k == x1 || k == x2) && (l == y1 || l == y2 || l == y3))
                                        {
                                            if (qrCode[k][l].Equals(oneList[n]) || qrCode[k][l].Equals(oneList[v]))
                                            {
                                                qrCode[k][l] = "#";
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
                else if (threeList.Contains(list[i]))
                {
                    for (int p = 0; p < oneList.Count; p++)
                    {
                        for (int o = 0; o < oneList.Count; o++)
                        {
                            for (int h = 0; h < oneList.Count; h++)
                            {
                                //THREE
                                if (oneList[p] + oneList[o] + oneList[h] == list[i])
                                {
                                    for (int k = 0; k < qrCode.Length; k++)
                                    {
                                        for (int l = 0; l < qrCode[k].Length; l++)
                                        {
                                            if ((k == x1 || k == x2) && (l == y1 || l == y2 || l == y3))
                                            {
                                                if (qrCode[k][l].Equals(oneList[p]) || qrCode[k][l].Equals(oneList[o]) || qrCode[k][l].Equals(oneList[h]))
                                                {
                                                    qrCode[k][l] = "#";
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (fourList.Contains(list[i]))
                {
                    for (int q = 0; q < oneList.Count; q++)
                    {
                        for (int w = 0; w < oneList.Count; w++)
                        {
                            for (int e = 0; e < oneList.Count; e++)
                            {
                                for (int m = 0; m < oneList.Count; m++)
                                {
                                    //FOUR
                                    if (oneList[q] + oneList[w] + oneList[e] + oneList[m] == list[i])
                                    {
                                        for (int k = 0; k < qrCode.Length; k++)
                                        {
                                            for (int l = 0; l < qrCode[k].Length; l++)
                                            {
                                                if ((k == x1 || k == x2) && (l == y1 || l == y2 || l == y3))
                                                {
                                                    if (qrCode[k][l].Equals(oneList[q]) || qrCode[k][l].Equals(oneList[w]) || qrCode[k][l].Equals(oneList[e]) || qrCode[k][l].Equals(oneList[m]))
                                                    {
                                                        qrCode[k][l] = "#";
                                                    }
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int b = 0; b < oneList.Count; b++)
                    {
                        for (int t = 0; t < oneList.Count; t++)
                        {
                            for (int y = 0; y < oneList.Count; y++)
                            {
                                for (int u = 0; u < oneList.Count; u++)
                                {
                                    for (int g = 0; g < oneList.Count; g++)
                                    {
                                        //FIVE
                                        if (oneList[b] + oneList[t] + oneList[y] + oneList[u] + oneList[g] == list[i])
                                        {
                                            for (int k = 0; k < qrCode.Length; k++)
                                            {
                                                for (int l = 0; l < qrCode[k].Length; l++)
                                                {
                                                    if ((k == x1 || k == x2) && (l == y1 || l == y2 || l == y3))
                                                    {
                                                        if (qrCode[k][l].Equals(oneList[b]) || qrCode[k][l].Equals(oneList[t]) || qrCode[k][l].Equals(oneList[y]) || qrCode[k][l].Equals(oneList[u]) || qrCode[k][l].Equals(oneList[g]))
                                                        {
                                                            qrCode[k][l] = "#";
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}


