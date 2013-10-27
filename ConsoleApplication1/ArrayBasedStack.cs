using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayBasedStacks
{
    class Stack<T>
    {
       private T[] values;
        int top;

        public Stack()
        {
           // values=new T[];
            top = -1;
        }
        public Stack(int size)
        {
            values = new T[size];
            top = -1;
        }
        public void Push(T item)
        {
            values[++top] = item;

        }
        public T Pop()
        {
            if (isEmpty())
            {
                throw new Exception("Stack is Empty");
                
                
            }
            return values[top--];
            
        }
        public T Peek()
        {
            if (isEmpty())
            {
                throw new Exception("Stack is Empty");


            }
            return values[top];


        }
        public bool isEmpty()
        {
            if (top == -1)
                return true;
            
            return false; 
        
        }
        public bool isFull()
        {
            if (top > -1)
                return true;
            
            return false; }
        public int Count()
        {
            if (top != -1)
                return top + 1;
            
            return -1;
        
        }

        public void printStack()
        {


            for (int i = 0; i < top+1; i++)
            {
                Console.WriteLine("val "+(i+1)+":" + values[i]);
            }

        }
    }

}
