using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    internal class Stack
    {
        private int[] arr;
        public int Size { get; init; }
        public int Top { get; private set; } = 0;
        public Stack(int size)
        {
            Size = size;
            arr = new int[size];
        }
        public void Push(int value)
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
        public int Pop()
        {
            if(Top > 0)
            {
                Top--;
                return arr[Top];
            }
            else
            {
                return -1;
            }
        }
        public int Last()
        {
            if (Top == 0)
            {
                return -1;
            }
            else
                return arr[Top - 1];
        }

        //indexer
        public int this[int ind]
        {
            get
            {
                if(ind < 0 || ind >= Size)
                    return -1;
                else
                    return arr[ind];
            }
        }


        // Operator OverLoading
        public static Stack operator +(Stack left,Stack right)
        {
            int size1 = left.Size;
            int size2 = right.Size;
            Stack result = new Stack(size1+size2);
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
