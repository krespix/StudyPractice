using System;
using System.Linq;
using System.Threading;

namespace task837
{
    internal class Program
    {
        public static char[,] Matrix = new char[,]
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
            int n = InputNumber("Введите размерность матрицы", 2, 1000000);
            char[,] matrix = readMatrix(n);
            Console.WriteLine("Дана матрица символов 11х11. Прочитать по спирали, начиная с центрального элемента (6, 6), тем самым зашифровав текст, затем расшифровать.");
            Console.WriteLine("Зашифрованный текст:");
            Console.WriteLine(reverseString(convertToStr(matrix)));
            Console.WriteLine("Расшифрованный текст");
            DisplayArray(convertToMatrix(reverseString(convertToStr(matrix)), n));
        }

        public static string convertToStr(char[,] matrix)
        {
            int i = 0, j = matrix.GetLength(0) - 1;

            int n = matrix.GetLength(0);
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
        
        public static char[,] convertToMatrix(string line, int rank)
        {
            string str = reverseString(line);
            char[,] matrix = new char[rank,rank];
            
            int i = 0, j = rank - 1;
            int counter = 0;
            int n = rank;

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
        
        public static int InputNumber(string text, int left, int right)
        {
            int number = 0;
            var ok = false;
            Console.WriteLine(text);
            do
            {
                try
                {
                    number = Int32.Parse(Console.ReadLine());
                    if (number <= right && number >= left)
                        ok = true;
                    else
                    {
                        Console.WriteLine("Ошибка! Введено число за пределами границ!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Неверно введено число!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка! Некорректный ввод!");
                }
            } while (!ok);

            return number;
        }
        
        public static char InputChar(string text)
        {
            char number = ' ';
            var ok = false;
            Console.WriteLine(text);
            do
            {
                try
                {
                    ok = Char.TryParse(Console.ReadLine(), out  number);
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Неверно введено число!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка! Некорректный ввод!");
                }
            } while (!ok);

            return number;
        }
        
        public static char[,] readMatrix(int rank)
        {
            char[,] matrix = new char[rank, rank];
            for (int i = 0; i < rank; i++)
            {
                Console.WriteLine($"Введите элементы {i+1} строки");
                for (int j = 0; j < rank; j++)
                {
                    matrix[i, j] = InputChar("");
                }
            }

            return matrix;
        }
        
    }
}
