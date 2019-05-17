using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahanStackProject
{
    class MahanStack<T>
    {

        T[] l;
        int Top;
        public MahanStack(int Size)
        {
            l = new T[Size];
            Top = -1;
        }
        public void Push(T a)
        {
            if (Top < l.Length - 1)
            {
                Top++;
                l[Top] = a;
            }
            else
                throw new Exception("Stack is full");

        }
        public T Pop()
        {
            if (Top >= 0)
            {
                T h = l[Top];
                Top--;
                return h;
            }
            else
                throw new Exception("Stack is Empty");
        }
        public T GetTop()
        {
            if (Top >= -1)
            {
                T h = l[Top];
                return h;
            }
            else
                throw new Exception("Stack is Empty");
        }
    }
}
