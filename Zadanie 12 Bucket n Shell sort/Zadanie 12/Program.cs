using System;
using System.Collections.Generic;
using System.Management.Instrumentation;

namespace Zadanie_12
{
    internal class Program
    {
        static void Swap(ref int a, ref int b) {
            int tmp = a;
            a = b;
            b = tmp;
        }
    
        static void QSort(int[] items, ref int compareCount, ref int forwardCount)
        {
            // Предварительная проверка элементов исходного массива
            //

            if (items == null || items.Length < 2)
                return;

            // Поиск элементов с максимальным и минимальным значениями
            //

            int maxValue = items[0];
            int minValue = items[0];    

            for (int i = 1; i < items.Length; i++)
            {
                if (items[i] > maxValue)
                    maxValue = items[i];

                if (items[i] < minValue)
                    minValue = items[i];

                compareCount += 2;
            }

            // Создание временного массива "карманов" в количестве,
            // достаточном для хранения всех возможных элементов,
            // чьи значения лежат в диапазоне между minValue и maxValue.
            // Т.е. для каждого элемента массива выделяется "карман" List<int>.
            // При заполнении данных "карманов" элементы исходного не отсортированного массива
            // будут размещаться в порядке возрастания собственных значений "слева направо".
            //

            List<int>[] bucket = new List<int>[maxValue - minValue + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            // Занесение значений в пакеты
            //

            for (int i = 0; i < items.Length; i++)
            {
                bucket[items[i] - minValue].Add(items[i]);
                forwardCount++;
            }

            // Восстановление элементов в исходный массив
            // из карманов в порядке возрастания значений
            //

            int position = 0;
            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i].Count > 0)
                {
                    compareCount++;
                    for (int j = 0; j < bucket[i].Count; j++)
                    {
                        items[position] = bucket[i][j];
                        position++;
                        forwardCount++;
                    }
                }
            }

        }
    
        static void Main() {
            
            Console.WriteLine("Сравнение сортировок: блочная и сортировка Шелла");
            
            int[] arr1 = { 3, 9, 4, 4, 1, 2, 3, 2, 8, 7};
            int[] arr2 = { 3, 9, 4, 4, 1, 2, 3, 2, 8, 7};
            
            int compareCount = 0;
            int forwardCount = 0;
            QSort(arr1, ref compareCount, ref forwardCount);
            printAnswer("Блочная сортировка", "Несортированный", forwardCount, compareCount);
            compareCount = 0;
            forwardCount = 0;
            QSort(arr1, ref compareCount, ref forwardCount);
            printAnswer("Блочная сортировка", "Сортированный по возрастанию", forwardCount, compareCount);
            compareCount = 0;
            forwardCount = 0;
            Array.Reverse(arr1);
            QSort(arr1, ref compareCount, ref forwardCount);
            printAnswer("Блочная сортировка", "Сортированный по убыванию", forwardCount, compareCount);

            compareCount = 0;
            forwardCount = 0;
            ShellSort(ref arr2, ref forwardCount, ref compareCount);
            printAnswer("Сортировка Шелла", "Несортированный", forwardCount, compareCount);
            
            compareCount = 0;
            forwardCount = 0;
            ShellSort(ref arr2, ref forwardCount, ref compareCount);
            printAnswer("Сортировка Шелла", "Сортированный по возрастанию", forwardCount, compareCount);
            
            compareCount = 0;
            forwardCount = 0;
            Array.Reverse(arr2);
            ShellSort(ref arr2, ref forwardCount, ref compareCount);
            printAnswer("Сортировка Шелла", "Сортированный по убыванию", forwardCount, compareCount);

        }
        
        public static void printArray(int[] array)
        {
            foreach (var VARIABLE in array)
            {
                Console.Write(VARIABLE + " ");
            }
            Console.WriteLine();
        }
        

        static void ShellSort(ref int[] array, ref int forwardCount, ref int compareCount)
        {
            //расстояние между элементами, которые сравниваются
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    compareCount++;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        forwardCount += 2;
                        j = j - d;
                    }
                }

                d = d / 2;
            }
            
        }

        public static void printAnswer(string sortName, string arrType, int forwardCount, int compareCount)
        {
            Console.WriteLine($"Сортировка: {sortName}\nМассив: {arrType}\nКоличество пересылок: {forwardCount}\nКоличество сравнений: {compareCount}");
            Console.WriteLine();
        }
    }
}