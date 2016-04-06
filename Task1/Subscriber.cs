using System;

namespace Task1
{
    public class Subscriber<T>
    {
        public Subscriber(Matrix<T> matrix)
        {
            matrix.NewValue += ElementChanged;
        }
        private void ElementChanged<T>(Object sender, SetNewValueEventArgs<T> e)
        {
            Console.WriteLine("Subscriber has been notified about the event, EventInfo: Position - {0},{1} , prev Value - {2}, new Value - {3}", e.X,e.Y,e.OldValue,e.NewValue);
        } 
    }
}