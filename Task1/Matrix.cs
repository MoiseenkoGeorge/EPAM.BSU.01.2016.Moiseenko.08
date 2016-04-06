using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    public abstract class Matrix<T>
    {
        public event EventHandler<SetNewValueEventArgs<T>> NewValue;

        protected virtual void OnNewValue(SetNewValueEventArgs<T> e)
        {
            EventHandler<SetNewValueEventArgs<T>> temp = Volatile.Read(ref NewValue);
            temp?.Invoke(this, e);
        }
        public uint N { get; protected set; }
        protected abstract T GetElement(uint x, uint y);
        protected abstract void SetElement(uint x, uint y, T value);
        protected abstract Matrix<T> Sum(Matrix<T> currentMatrix, Matrix<T> additionalMatrix);
        public T this[uint x, uint y]
        {
            get
            {
                if (x > N - 1 || y > N - 1)
                    throw new IndexOutOfRangeException();
                return GetElement(x, y);
            }
            set
            {
                SetNewValueEventArgs<T> e = new SetNewValueEventArgs<T>((int)x, (int)y, GetElement(x, y), value);
                if (x > N - 1 || y > N - 1)
                    throw new IndexOutOfRangeException();
                SetElement(x,y,value);
                OnNewValue(e);
            }
        }
        public Matrix<T> Add(Matrix<T> matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException();
            if (this.N != matrix.N)
                throw new ArgumentException("matrix should be the same size");
            try
            {
                return Sum(this, matrix);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("not overloaded addition operator");
            }
        }
    }
}