using System;
using System.Runtime.Remoting.Channels;


namespace task58b
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            double a;
            double result = 0;
            bool ok;
            
            Console.WriteLine("58. Дано действительное число а. Для функций f (х),графики которых представлены на рис. 1, f(а)." +
                              "\n y = (-1)/x^2, если x <= -1" +
                              "\n y = x^2, если -1 < x <= 2" +
                              "\n y = 4, если x > 2");
            
            Console.WriteLine("Введите а");
            do
            {
                ok = Double.TryParse(Console.ReadLine(), out a);
                if (!ok)
                {
                    Console.WriteLine("Ошибка! Введено некорректное значение а. Повторите ввод");
                }
            } while (!ok);

            if (a <= -1)
            {
                result = -1 / (a * a);
            }

            if (a > -1 && a < 2)
            {
                result = a * a;
            }

            if (a >= 2)
            {
                result = 4;
            }
            
            Console.WriteLine(result);
        }
    }
}