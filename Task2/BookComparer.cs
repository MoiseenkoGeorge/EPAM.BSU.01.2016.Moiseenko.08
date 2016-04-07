using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.CompareTo(y);
        }
    }
}
