using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;
namespace ConsoleApl
{
    class Program
    {
        static void Main()
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Insert(11);
            binarySearchTree.Insert(12);
            binarySearchTree.Insert(10);
            binarySearchTree.Insert(8);
            binarySearchTree.Insert(9);
            binarySearchTree.Insert(0);
            foreach(var item in binarySearchTree.Postorder())
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
