using System;
using System.Threading;

namespace task587
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool ok;
            decimal x;
            int q;
            int[] numberArr = new int[5];
            decimal fract;

            Console.WriteLine("Даны действительное число х, натуральное число q(x <= х < 1, q >= 2). Получить пять цифр " +
                              "\nq-ичного представ-ления числа х, т. е. получить последовательность целыхнеотрицательных" +
                              "\nа(-1) ..., a(-5) такую, что x = a(-1)q^-1 + ... + a(-5)*q^-5 + r, r < q^-5");
            Console.WriteLine();
            Console.WriteLine("Введите сначала число, затем систему счисления");

            do
            {
                ok = decimal.TryParse(Console.ReadLine(), out x);
                if (!ok || x < 0 || x >= 1)
                {
                    Console.WriteLine("Введите корректное значение x (x >= 0, x < 1)");
                }
            } while (!ok || x < 0 || x >= 1);
            
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out q);
                if (!ok || q < 2)
                {
                    Console.WriteLine("Введите корректное значение q (q >= 2)");
                }
            } while (!ok || q < 2);
            
            decimal temp = x;
            
            
            for (int i = 0; i < 5; i++)
            {
                fract = temp - Math.Floor(temp);
                temp = fract * q;
                numberArr[i] = (int) temp;
            }

            string result = "0,";
            int countZ = 0;
            for (int i = 0; i < numberArr.Length; i++)
            {
                result += numberArr[i];
            }

            result = result.TrimEnd('0');
            Console.WriteLine($"Число {x} в {q}-ичной системе счисления с точностью до 5 знака после запятой равно: {result}");
        }
    }
}