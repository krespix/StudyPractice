using System;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Threading;

namespace task5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            decimal a1, a2, a3;
            int n;
            bool rise = false, notDown = false, ok;

            Console.WriteLine("1.	Ввести а1, а2, а3, N. Построить последовательность чисел " +
                              "\nак = (ак–1+1) / (ак-2 +2) * ак–3. Построить и напечатать N элементов последовательности " +
                              "\nи проверить, является ли она монотонно неубывающей или строго возрастающей.");
            
            a1 = InputNumber("Введите первый элемент");
            a2 = InputNumber("Введите второй элемент");
            a3 = InputNumber("Введите третий элемент");
            Console.WriteLine("Введите количество элементов:");
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out n);
                if (!ok)
                {
                    Console.WriteLine("Ошибка! Введено некорректное значение n. Повторите ввод");
                }
            } while (!ok);

            decimal[] arr = new Decimal[n];
            arr[0] = a1;
            arr[1] = a2;
            arr[2] = a3;

            for (int i = 3; i < n; i++)
            {
                arr[i] = (arr[i - 1] + 1) / (arr[i - 2] + 2) * arr[i - 3];
            }

            for (int i = 0; i < n - 1; i++)
            {
                if (arr[i] < arr[i + 1])
                {
                    rise = true;
                }
                else if (arr[i] <= arr[i + 1])
                {
                    notDown = true;
                    rise = false;
                }
                else
                {
                    notDown = false;
                    rise = false;
                    break;
                }
                
            }

            if (rise)
            {
                Console.WriteLine("Последовательность строго возрастающая");
            }
            else if (!rise && notDown)
            {
                Console.WriteLine("Последовательность неубывающая");
            }
            else
            {
                Console.WriteLine("Последовательность не монотонная");
            }
            
            Console.WriteLine("Последовательность:");
            foreach (var item in arr)
            {
                Console.Write(Decimal.Round(item, 2) + " ");
            }
        }

        public static decimal InputNumber(string text, int left = -100000000, int right = 10000000)
        {
            decimal number = 0;
            var ok = false;
            Console.WriteLine(text);
            do
            {
                try
                {
                    number = decimal.Parse(Console.ReadLine());
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
    }
}