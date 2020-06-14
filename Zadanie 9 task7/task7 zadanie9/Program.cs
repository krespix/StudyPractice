using System;
using System.Runtime.ConstrainedExecution;

namespace task7_zadanie9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool ok;
            Console.WriteLine("Линейный список. Написать рекурсивные методы создания, поиска и удаления.");
            Console.WriteLine("Создание списка:");
            LinkedList list = new LinkedList();
            int n;
            Console.WriteLine("Введите n");
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out n);
                if (!ok || n < 1)
                {
                    Console.WriteLine("Ошибка! Введено некорректное значение n. Повторите ввод");
                }
            } while (!ok || n < 1);
            list.Add(n);
            Console.WriteLine("Текущий список:");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Удаление элементов:");
            Console.WriteLine("Введите элемент, который нужно удалить:");
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out n);
                if (!ok)
                {
                    Console.WriteLine("Ошибка! Введено некорректное значение n. Повторите ввод");
                }
            } while (!ok);
            list.Remove(n);
            Console.WriteLine("Текущий список:");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Введите элемент, который нужно найти:");
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out n);
                if (!ok)
                {
                    Console.WriteLine("Ошибка! Введено некорректное значение n. Повторите ввод");
                }
            } while (!ok);
            
            Console.WriteLine("Поиск элемента:");
            Console.WriteLine(list._search(n, list.firstPoint, out int index) + "\nindex = " + index);
        }
    }
}