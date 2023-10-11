using SelfBalancedTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);
            tree.Add(5);
            tree.Add(6);
            tree.Add(2);
            tree.Add(3);
            tree.Add(1);
            tree.Add(3);
            tree.Add(4);
            tree.Add(6);
            tree.Add(10);  

            foreach (var iten in tree.ValuesCollectionDescending)
            {
                Console.WriteLine(iten.ToString());
            }
            Console.ReadLine();
        }
    }
}
