using System;
using System.Globalization;

namespace Task1
{
    public class SimmetricMatrix<T> : Matrix<T>
    {
        private readonly T[,] matrix;

        public SimmetricMatrix(T[,] matrix)
        {
            this.matrix = matrix;
            N = (uint)matrix.Length;
        }

        public SimmetricMatrix(uint n)
        {
            N = n;
        } 
        protected override T GetElement(uint x, uint y) => matrix[x, y];
        protected override void SetElement(uint x, uint y, T value)
        {
            matrix[x, y] = value;
            matrix[y, x] = value;
        }

        protected override Matrix<T> Sum(Matrix<T> currentMatrix, Matrix<T> additionalMatrix)
        {
            T[,] matrix = new T[currentMatrix.N, currentMatrix.N];
            for (uint i = 0; i < matrix.Length; i++)
                for (uint j = 0; j < matrix.Length; j++)
                    matrix[i, j] = (dynamic)currentMatrix[i, j] + (dynamic)additionalMatrix[i, j];
            if (additionalMatrix is SimmetricMatrix<T>) return new SimmetricMatrix<T>(matrix);
            return new SquareMatrix<T>(matrix);
        }

        private bool IsSimmetric(T[,] matrix,int n)
        {
            for(int i=0; i < n ; i++)
                for(int j=0 ;j < n; j++)
                    if ((dynamic)matrix[i, j] != (dynamic)matrix[j, i])
                        return false;
            return true;
        }
    }
}