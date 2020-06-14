using System;
using Tre;

namespace DeleteTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Написать метод уничтожения дерева");
            bool ok;
            int n;
            Console.WriteLine("Введите количество элементов в дереве:");
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out n);
                if (!ok || n < 1)
                {
                    Console.WriteLine("Ошибка! Введено некорректное значение n. Повторите ввод");
                }
            } while (!ok || n < 1);
            Tree tree = new Tree(n);
            tree.Show();
            tree.DeleteTree(ref tree.Root);
            tree.Show();
        }
    }
}