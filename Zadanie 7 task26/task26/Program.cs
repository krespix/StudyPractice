using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

namespace task26
{
    internal class Program
    {
        public static List<int> codes = new List<int>();
        public static int currentNumber = 0;
        public static int currentCount = 0;
        public static int currentCode = 0;
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Построить префиксный троичный код с заданными длинами кодовых слов. Кодовые слова выписать в лексикографическом порядке.");
            
            List<int> codeNames = new List<int>();
            int input = 0;
            
            Console.WriteLine("Введите количество кодовых слов");
            int n = ReadNumber();
            Console.WriteLine("Введите длины кодовых слов");
            for (int i = 0; i < n; i++)
            {
                codeNames.Add(ReadNumber());
            }
            
            bool check = MacMilanCheck(codeNames);
            if (check)
            {
                codeNames.Sort();

                int count = 0;
                for (int i = codeNames.Count - 1; i > 0; i--)
                {
                    count++;
                    if (codeNames[i] != codeNames[i - 1] || i + 1 == codeNames.Count)
                    {
                        MakeIntCodes(codeNames[i], count);
                        Console.WriteLine($"CodeNAmes длина - {codeNames[i]}");
                        count = 0;
                    }
                }

                MakeIntCodes(codeNames[0], count + 1);

                if (codeNames[0] != codeNames[1])
                {
                    MakeIntCodes(codeNames[0], 1);
                }

                codes.Sort();
                Console.WriteLine("Кодовые слова");
                foreach (var item in codes)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Введенные длины слов не удовлетворяют условию Макмилана.");
            }
        }

        public static int ReadNumber()
        {
            int result;
            bool ok;
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out result);
                if (!ok || result < 1 || result > 100000000)
                {
                    Console.WriteLine("некорректный ввод!");
                }
            } while (!ok || result < 1 || result > 100000000);

            return result;
        }

        public static int Decrement(int number)
        {
            number = convertToDecimal(number);
            number--;
            return convertToTrio(number);
        }

        public static int convertToDecimal(int number)
        {
            int result = 0;
            int stepen = 1;
            while (number > 0)
            {
                int n = number % 10;
                result = result + n * stepen;
                stepen *= 3;
                number /= 10;
            }

            return result;
        }

        public static int convertToTrio(int number)
        {
            List<int> list = new List<int>();

            while (number > 0)
            {
                list.Add(number % 3);
                number /= 3;
            }

            int result = 0;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                result += list[i];
                result *= 10;
            }

            return result / 10;
        }
        
        public static bool MacMilanCheck(List<int> list)
        {
            list.Sort();
            int count = 0;
            double cheking = 0;

            for (int i = 0; i < list.Count - 1; i++)
            {
                count++;
                if (list[i] != list[i + 1])
                {
                    Console.WriteLine("1)" + count * Math.Pow(3, -list[i]));
                    cheking = cheking + count * Math.Pow(3, -list[i]);
                    count = 0;
                }
            }

            if (count > 1)
            {
                cheking = cheking + count * Math.Pow(3, -list[list.Count - 1]);
                Console.WriteLine("2)" + count * Math.Pow(3, -list[list.Count - 1]));
            }

            if (list[list.Count - 1] != list[list.Count - 2])
            {
                cheking = cheking + Math.Pow(3, -list[list.Count - 1]);
                Console.WriteLine("3)" +  Math.Pow(3, -list[list.Count - 1]));
            }
            
            Console.WriteLine(cheking);

            return cheking <= 1.00;
        }

        public static void MakeIntCodes(int numberCode, int count) //длина кодового слова и количество кодовых слов с такой длиной
        {
            int number;
            if (currentCount == 0)
            {
                currentCount = count;
                currentNumber = numberCode;
                currentCode = MakeNumber(numberCode);
                Console.WriteLine("1)" + currentCode);
            }
            else
            {
                for (int i = 0; i < currentNumber - numberCode; i++)
                {
                    currentCode /= 10;
                }
                Console.WriteLine("2)" + currentCode);
                currentCode = Decrement(currentCode);
                currentCount = count;
                currentNumber = numberCode;
                Console.WriteLine("3)" + currentCode);
            }
            int temp = currentCode;
            for (int i = 0; i < currentCount; i++)
            {
                currentCode = temp;
                Console.WriteLine($"CurrentCode - {currentCode}");
                codes.Add(currentCode);
                temp = Decrement(currentCode);
            }
        }

        public static int MakeNumber(int numberCode)
        {
            int result = 0;
            for (int i = 0; i < numberCode; i++)
            {
                result += 2;
                result *= 10;
            }

            return result / 10;
        }
    }
    
    
}