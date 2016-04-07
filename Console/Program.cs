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
            BinarySearchTree<int> binarySearchTreeInt = new BinarySearchTree<int>();
            binarySearchTreeInt.Insert(11,null);
            binarySearchTreeInt.Insert(12,null);
            binarySearchTreeInt.Insert(10,new IntComparer());
            binarySearchTreeInt.Insert(8);
            binarySearchTreeInt.Insert(9);
            binarySearchTreeInt.Insert(0);
            foreach(var item in binarySearchTreeInt.Postorder())
            {
                Console.WriteLine(item);
            }
            BinarySearchTree<string> binarySearchTreeString = new BinarySearchTree<string>();
            binarySearchTreeString.Insert("aaa", null);
            binarySearchTreeString.Insert("bbb");
            binarySearchTreeString.Insert("ccc",new MyStringComparer());
            foreach (var item in binarySearchTreeString.Postorder())
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
