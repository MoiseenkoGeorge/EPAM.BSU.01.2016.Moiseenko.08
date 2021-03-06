﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class DiagonalMatrix<T> : Matrix<T>
    {
        private readonly T[] matrix;
        public DiagonalMatrix(uint n)
        {
            N = n;
            matrix = new T[N];
        }
        public DiagonalMatrix(T[] matrix)
        {
            this.matrix = matrix;
            N = (uint)matrix.Length;
        }
        protected override T GetElement(uint x, uint y) => x == y ? matrix[x] : default(T);

        protected override void SetElement(uint x, uint y, T value)
        {
            if (x != y)
                throw new InvalidOperationException("Require diagonal element");
            matrix[x] = value;
        }

        protected override Matrix<T> Sum(Matrix<T> currentMatrix, Matrix<T> additionalMatrix)
        {

            if (additionalMatrix is DiagonalMatrix<T>)
            {
                T[] matrix = new T[additionalMatrix.N];
                for (uint i = 0; i < matrix.Length; i++)
                    matrix[i] = (dynamic) currentMatrix[i, i] + additionalMatrix[i, i];
                return new DiagonalMatrix<T>(matrix);
            }
            else
            {
                T[,] matrix = new T[currentMatrix.N,currentMatrix.N];
                for (uint i = 0; i < currentMatrix.N; i++)
                    for (uint j = 0; j < currentMatrix.N; j++)
                        matrix[i, j] = (dynamic)currentMatrix[i, j] + additionalMatrix[i, j];
                if(additionalMatrix is SimmetricMatrix<T>) return new SimmetricMatrix<T>(matrix);
                return new SquareMatrix<T>(matrix);
            }

        }
    }
}
