using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class MyStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == y)
                return 0;
            else if (x.CompareTo(y) > 0) return 1;
            else return -1;

        }
    }
}
