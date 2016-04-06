using System;

namespace Task1
{
    public class SetNewValueEventArgs<T> : EventArgs
    {
        public int X { get; }
        public int Y { get; }
        public T OldValue { get; }
        public T NewValue { get; }

        public SetNewValueEventArgs(int x, int y, T oldValue, T newValue)
        {
            X = x;
            Y = y;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}