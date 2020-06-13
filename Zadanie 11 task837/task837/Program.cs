using System;
using System.Linq;
using System.Threading;

namespace task837
{
    internal class Program
    {
        public static char[,] matrix = new char[,]
        {
            {'p', 'r', 'v', 'k', 'a', 'k', 'd', 'e', 'l', 'a', '?'},
            {'p', 'r', 'v', 'k', 'a', 'k', 'd', 'e', 'l', 'a', '?'},
            {'p', 'r', 'v', 'k', 'a', 'k', 'd', 'e', 'l', 'a', '?'},
            {'p', 'r', 'v', 'k', 'a', 'k', 'd', 'e', 'l', 'a', '?'},
            {'p', 'r', 'v', 'k', 'a', 'k', 'd', 'e', 'l', 'a', '?'},
            {'p', 'r', 'v', 'k', 'a', 'k', 'd', 'e', 'l', 'a', '?'},
            {'p', 'r', 'v', 'k', 'a', 'k', 'd', 'e', 'l', 'a', '?'},
            {'p', 'r', 'v', 'k', 'a', 'k', 'd', 'e', 'l', 'a', '?'},
            {'p', 'r', 'v', 'k', 'a', 'k', 'd', 'e', 'l', 'a', '?'},
            {'p', 'r', 'v', 'k', 'a', 'k', 'd', 'e', 'l', 'a', '?'},
            {'p', 'r', 'v', 'k', 'a', 'k', 'd', 'e', 'l', 'a', '?'}
        };
        static void DisplayArray(char[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++) Console.Write("{0,3} ", a[i, j]);
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Дана матрица символов 11х11. Прочитать по спирали, начиная с центрального элемента (6, 6), тем самым зашифровав текст, затем расшифровать.");
            Console.WriteLine("Зашифрованный текст:");
            Console.WriteLine(reverseString(convertToStr(matrix)));
            Console.WriteLine("Расшифрованный текст");
            DisplayArray(convertToMatrix(reverseString(convertToStr(matrix))));
        }

        public static string convertToStr(char[,] matrix)
        {
            int i = 0, j = 11 - 1;

            int n = 11;
            string result = "";
                
            while (n != 0)
            {
                int k = 0;
                do { result += matrix[i, j--]; } while (++k < n - 1);

                for (k = 0; k < n - 1; k++) result += matrix[i++, j];
                for (k = 0; k < n - 1; k++) result += matrix[i, j++];
                for (k = 0; k < n - 1; k++) result += matrix[i--, j];

                ++i;
                --j;
                n = n < 2 ? 0 : n - 2;
            }

            return result;
        }

        public static string reverseString(string line)
        {
            char[] arr = line.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        
        public static char[,] convertToMatrix(string line)
        {
            string str = reverseString(line);
            char[,] matrix = new char[11,11];
            
            int i = 0, j = 11 - 1;
            int counter = 0;
            int n = 11;

            while (n != 0)
            {
                int k = 0;
                do
                {
                    matrix[i, j--] = str[counter];
                    counter++;
                } while (++k < n - 1);

                for (k = 0; k < n - 1; k++)
                {
                    matrix[i++, j] =  str[counter];
                    counter++;
                }

                for (k = 0; k < n - 1; k++)
                {
                    matrix[i, j++] = str[counter];
                    counter++;
                }

                for (k = 0; k < n - 1; k++)
                {
                    matrix[i--, j] = str[counter];
                    counter++;
                }

                ++i;
                --j;
                n = n < 2 ? 0 : n - 2;
            }

            return matrix;
        }
    }
}
