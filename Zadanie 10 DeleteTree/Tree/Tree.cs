using System;
using System.Data;
using System.Threading;

namespace Tre
{
    public class Tree
    {
        public Node Root;

        public Tree()
        {
            Root = null;
        }
        
        public Tree(int size)
        {
            Node p = new Node(100);
            Root = p;
            Root = MakeIdealTree(size, p);
        }              //создание сбалансированного дерева


        private static Node MakeIdealTree(int size, Node p)
        {
            Node r;
            int nl, nr;
            if (size == 0)
            {
                p = null;
                return p;
            }

            nl = size / 2;
            nr = size - nl - 1;
            Random rnd = new Random();
            Thread.Sleep(50);
            r = new Node(rnd.Next(100));

            r.Left = MakeIdealTree(nl, r.Left);
            r.Right = MakeIdealTree(nr, r.Right);
            return r;
        }
        
        private void ShowTree(Node p, int l)
        {
            if (p != null)
            {

                ShowTree(p.Left, l + 3);
                for (int i = 0; i < l; i++)
                    Console.Write("-");
                Console.WriteLine(p.Value);
                ShowTree(p.Right, l + 3);

            }
        }     //печать поддерьвьев
        public void Show()
        {
            if (Root == null)
            {
                Console.WriteLine("Пустое дерево");
            }
            else
                ShowTree(Root, 5);
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

        public void DeleteTree(ref Node node)
        {
            if (node == null)
            {
                return;
            }
            
            DeleteTree(ref node.Left);
            DeleteTree(ref node.Right);
            
            if (node.Left == null && node.Right == null)
            {
                node = null;
            }
        }
    }
}