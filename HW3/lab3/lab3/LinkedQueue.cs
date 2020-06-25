using System;
using System.Collections.Generic;
using System.Text;


namespace lab3
{
    public class LinkedQueue<T> : IQueueInterface<T>
    {
        private Node<T> Front;
        private Node<T> Rear; 

        public LinkedQueue()
        {
            Front = null;
            Rear = null; 
        }

        public bool IsEmpty()
        {
            if(Front == null && Rear == null)
            {
                return true; 
            }
            else
            {
                return false; 
            }
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new NotImplementedException();
            }
            return Front.data; 
        }

        public T Pop()
        {
            T nullptr = default(T);
            T tmp = nullptr;
            if (IsEmpty())
            {
                throw new NotImplementedException("Queue was empty when pop was invoked");
            }
            else if(Front == Rear)
            {
                tmp = Front.data;
                Front = null;
                Rear = null; 
            }
            else
            {
                tmp = Front.data;
                Front = Front.next; 
            }
            return tmp; 
        }

        public T Push(T element)
        {
            if (element == null)
            {
                throw new NotImplementedException();
            }
            if(IsEmpty())
            {
                Node<T> tmp = new Node<T>(element, null);
                Rear = Front = tmp; 
            }
            else
            {
                Node<T> tmp = new Node<T>(element, null);
                Rear.next = tmp;
                Rear = tmp; 
            }

            return element; 
        }

    }
}
