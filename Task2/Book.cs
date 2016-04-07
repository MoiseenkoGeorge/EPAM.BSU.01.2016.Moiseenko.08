using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Book : IComparable<Book>
    {
        public string Name { get; private set; }
        public string Author { get; private set; }

        public int CompareTo(Book other)
        {
            return Author.CompareTo(other.Author);
        }
    }
}
