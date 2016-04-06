using System;
using System.Globalization;

namespace Task1
{
    public class SimmetricMatrix<T> : Matrix<T>
    {
        private readonly T[,] matrix;

        public SimmetricMatrix(T[,] matrix)
        {
            double tempSize = Math.Sqrt(matrix.Length);
            if((tempSize - (int)tempSize) != 0)
                throw new ArgumentException("Require square matrix");
            if(!IsSimmetric(matrix,(int)tempSize))
                throw new ArgumentException("Require simmetric matrix");
            N = (uint)tempSize;
            this.matrix = matrix;
        }

        public SimmetricMatrix(uint n)
        {
            N = n;
            matrix = new T[n,n];
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
            for (uint i = 0; i < currentMatrix.N; i++)
                for (uint j = 0; j < currentMatrix.N; j++)
                    matrix[i, j] = (dynamic)currentMatrix[i, j] + (dynamic)additionalMatrix[i, j];
            if (additionalMatrix is SimmetricMatrix<T>) return new SimmetricMatrix<T>(matrix);
            return new SquareMatrix<T>(matrix);
        }

        private bool IsSimmetric(T[,] matrix,int n)
        {
            try
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if ((dynamic)matrix[i, j] != (dynamic)matrix[j, i])
                            return false;
                return true;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Not implemented comparison operator");
            }
            
        }
    }
}