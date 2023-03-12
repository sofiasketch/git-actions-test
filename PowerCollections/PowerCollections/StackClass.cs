using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerCollections
{
    class StackFullException : Exception
    {
        public StackFullException(string message) : base(message)
        {
        }
    }

    class StackEmptyException : Exception
    {
        public StackEmptyException(string message) : base(message)
        {
        }
    }
    public class StackClass<T> : IEnumerable
    {
        private int count = 0;
        private int capacity;
        private T[] arr;

        // Свойства

        public int Count 
        { 
            get { return count;}
        }

        public int Capacity
        {
            get { return capacity; }
        }

        // Конструктор
        public StackClass()
        {
            this.capacity = 100;
            arr = new T[100];
        }

        public StackClass(int capacity)
        {
            this.capacity = capacity;
            arr = new T[capacity];
        }
        // Интерфейс
        public IEnumerator GetEnumerator()
        {
            T[] new_arr = new T[count];
            //int i_end = count - 1;
            int i_new_arr = 0;
            for (int i = count - 1; i >= 0; i--)
            {
                new_arr[i_new_arr] = arr[i];
                i_new_arr++;
            }
            return new_arr.GetEnumerator();
        }
        // Методы
        public void Push(T stackElement)
        {
            if (count >= capacity) throw new StackFullException("stack is full!");
            arr[count] = stackElement;
            count++;
        }

        public T Pop()
        {
            if (count == 0) throw new StackEmptyException("stack is empty!");
            count--;
            return arr[count];
        }

        public T Top()
        {
            if (count == 0) throw new StackEmptyException("stack is empty!");
            return arr[count - 1];
        }

        public T[] ToArray()
        {
            return arr.Reverse().ToArray();
        }
    }
}
