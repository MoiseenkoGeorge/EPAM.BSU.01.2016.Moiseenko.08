using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace Task1.Tests
{
    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void EventInMatrix_Test()
        {
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(2);
            Subscriber<int> subscriber = new Subscriber<int>(squareMatrix);
            squareMatrix[0, 1] = 11;
            squareMatrix[1, 0] = 12;
        }
        [Test]
        [TestCase(0,1,ExpectedException = typeof(InvalidOperationException))]
        public void DiagonalMatrix_Test(int x,int y)
        {
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(2);
            diagonalMatrix[(uint)x, (uint)y] = 13;

        }

        [Test]
        [TestCase(1,1,Result = 6)]
        public int AdditionMatrix_Test(int x, int y)
        {
            var simmetricMatrix1 = new SimmetricMatrix<int>(2)
            {
                [0, 0] = 1,
                [0, 1] = 2,
                [1, 1] = 3
            };
            var simmetricMatrix2 = new SimmetricMatrix<int>(2)
            {
                [0, 0] = 1,
                [0, 1] = 2,
                [1, 1] = 3
            };
            var temp = simmetricMatrix2.Add(simmetricMatrix1);
            return temp[(uint)x, (uint)y];
        }
    }
}
