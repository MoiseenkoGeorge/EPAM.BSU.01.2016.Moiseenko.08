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
            var book1 = new Book("1", "1");
            var book2 = new Book("2", "2");
            var book3 = new Book("3", "3");
            BinarySearchTree<Book> bookTree = new BinarySearchTree<Book>();
            bookTree.Insert(book1);
            bookTree.Insert(book2,null);
            bookTree.Insert(book3, new BookComparer());
            foreach (var item in bookTree.Postorder())
            {
                Console.WriteLine(item.Author + item.Name);
            }
            Console.ReadKey();
        }
    }
}
