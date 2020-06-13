using System;

namespace task405
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //порядок матрицы
            int n;
            bool ok;
            Console.WriteLine("Даны натуральное число я, действительная квад-ратная матрица порядка я. Построить последовательность " +
                              "\nb1 ..., bn из нулей и единиц, в которой bi = 1 тогда итолько тогда, когда в i-й строке матрицы есть" +
                              "\n хотя быодин отрицательный элемент.");
            Console.WriteLine("Введите разраядность матрицы");
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out n);
                if (!ok)
                {
                    Console.WriteLine("Введите корректное значение!");
                }
            } while (!ok);
            int[,] matrix = new int[n,n];
            int[] result = new int[n];

            try
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"Введите {i + 1} строку массива");
                    string line = Console.ReadLine();
                    if (line.Split(' ').Length == n)
                    {
                        int[] tempArray = convertToArray(line, n);
                        for (int j = 0; j < n; j++)
                        {
                            matrix[i, j] = tempArray[j];
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Вы ввели строку неверной длины");
                        ok = false;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка! Некорректный ввод");
            }
            
            if (ok)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = 0;
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (matrix[i, j] < 0)
                        {
                            result[i] = 1;
                            break;
                        }
                    }
                }

                Console.WriteLine("Итоговая последовательность:");
                foreach (var item in result)
                {
                    Console.Write(item);
                }
            }
        }


        public static int[] convertToArray(string line, int n)
        {
            string[] arr = line.Split(' ');
            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = Int32.Parse(arr[i]);
            }

            return result;
        }
        
    }
}