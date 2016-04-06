using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    public class SquareMatrix<T> : Matrix<T>
    {
        private readonly T[,] matrix;
        public SquareMatrix(T[,] matrix)
        {
            double tempSize = Math.Sqrt(matrix.Length);
            if ((tempSize - (int)tempSize) != 0)
                throw new ArgumentException("Require square matrix");
            this.matrix = matrix;
            N = (uint)tempSize;
        }

        public SquareMatrix(uint n)
        {
            N = n;
            matrix = new T[n,n];
        }
        protected override Matrix<T> Sum(Matrix<T> lhs, Matrix<T> rhs)
        {
            T[,] matrix = new T[rhs.N, rhs.N];
            for (uint i = 0; i < rhs.N; i++)
                for (uint j = 0; j < rhs.N; j++)
                    matrix[i, j] = (dynamic)rhs[i, j] + (dynamic)lhs[i, j];
            return new SquareMatrix<T>(matrix);
        }

        protected override T GetElement(uint x, uint y) => matrix[x, y];
        protected override void SetElement(uint x, uint y, T value)
        {
            matrix[x, y] = value;
        }
    }
}
