﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    internal class Stack<T> : IStack<T>
    {
        private T[] arr;
        public int Size { get; init; }
        public int Top { get; private set; } = 0;
        public Stack(int size)
        {
            Size = size;
            arr = new T[size];
        }
        public void Push(T value)
        {
            if(Top < Size)
            {
                arr[Top] = value;
                Top++;
                Console.WriteLine("Done......");
            }
            else
            {
                Console.WriteLine("Stack is already Full");
            }
        }
        public T Pop()
        {
            if(Top > 0)
            {
                Top--;
                return arr[Top];
            }
            else
            {
                return default;
            }
        }
        public T Last()
        {
            if (Top == 0)
            {
                return default;
            }
            else
                return arr[Top - 1];
        }

		public T GetByIndex(int idx)
		{
			return this[idx];
		}

		//indexer
		public T this[int ind]
        {
            get
            {
                if(ind < 0 || ind >= Size)
                    return default;
                else
                    return arr[ind];
            }
        }


        // Operator OverLoading
        public static Stack<T> operator +(Stack<T> left,Stack<T> right)
        {
            int size1 = left.Size;
            int size2 = right.Size;
            Stack<T> result = new Stack<T>(size1+size2);
            for(int i = 0; i < left.Top; i++)
            {
                result.Push(left.arr[i]);
            }
			for (int i = 0; i < right.Top; i++)
			{
				result.Push(right.arr[i]);
			}
            return result;
		}
    }
}
