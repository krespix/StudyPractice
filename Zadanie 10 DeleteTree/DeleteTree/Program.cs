using System;
using Tre;

namespace DeleteTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Написать метод уничтожения дерева");
            
            Tree tree = new Tree(10);
            tree.Show();
            tree.DeleteTree(ref tree.Root);
            tree.Show();
        }
    }
}