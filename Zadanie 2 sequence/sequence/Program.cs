using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;


namespace sequence
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string fileData;
            using (StreamReader sr = new StreamReader("INPUT.TXT"))
            {
                fileData = sr.ReadToEnd();
            }

            string[] tempArray = fileData.Split('\n');
            string[] numbers = tempArray[1].Split(' ');
            List<int> a = new List<int>();
            List<int> b = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                a.Add(Int32.Parse(numbers[i]));
            }
            
            b.Add(a[0]);
            int bPos = 0;
            bool flag1 = false;
            bool flag2 = false;

            for (int i = 1; i < a.Count - 1; i++)
            {
                for (int j = i + 1; j < a.Count ; j++)
                {
                    if (a[i] < a[j])
                    {
                        flag1 = true;
                    }
                }

                for (int j = i - 1; j >= 0; j--)
                {
                    if (a[i] < a[j])
                    {
                        flag2 = true;
                    }
                }

                if (!(flag1 && flag2))
                {
                    b.Add(a[i]);
                }
                
                flag1 = false;
                flag2 = false;
            }
            b.Add(a[a.Count - 1]);

            string result = "";
            foreach (var item in b)
            {
                result += item;
                result += " ";
            }

            using (StreamWriter sw = new StreamWriter("OUTPUT.TXT", false, System.Text.Encoding.Default))
            {
                sw.WriteLine(b.Count);
                sw.WriteLine(result);
            }
        }
    }
}