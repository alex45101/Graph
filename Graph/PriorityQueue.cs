using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private T[] tree = new T[30];
        private IComparer<T> comparer;
        private int count;
        public int Count { get { return count + 1; } }
        public T this[int i]
        {
            get
            {
                if (i > -1 && i < count)
                {
                    return tree[i];
                }

                throw new ArgumentOutOfRangeException();
            }
        }

        public PriorityQueue(IComparer<T> comparer)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
            count = 0;
        }

        public void Enqueue(T value)
        {
            count++;

            if (count == tree.Length)
            {
                IncreaseTree();
            }

            tree[count] = value;

            HeapifyUp(count);
        }

        public T Dequeue()
        {
            Sort();
            T root = tree[1];

            tree[1] = tree[count];
            tree[count] = default(T);

            count--;

            HeapifyDown(1);

            return root;
        }

        //Heapify
        public void Sort()
        {
            for (int i = count / 2; i > 0; i--)
            {
                HeapifyDown(i);
            }
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public bool Contains(T item)
        {
            return tree.Contains(item);
        }

        private void HeapifyUp(int index)
        {
            int parent = index / 2;

            if (parent < 1 || comparer.Compare(tree[parent], tree[1]) == 0 || comparer.Compare(tree[index], tree[parent]) == 0)
            {
                return;
            }

            if (comparer.Compare(tree[index], tree[parent]) < 0)
            {
                T temp = tree[index];
                tree[index] = tree[parent];
                tree[parent] = temp;
            }

            HeapifyUp(parent);
        }

        private void HeapifyDown(int index)
        {
            int leftChild = index * 2;
            int rightChild = index * 2 + 1;

            int swapIndex = 0;

            if (leftChild > count || rightChild > count)
            {
                return;
            }

            if (comparer.Compare(tree[leftChild], tree[rightChild]) < 0)
            {
                swapIndex = leftChild;
            }
            else
            {
                swapIndex = rightChild;
            }

            if (comparer.Compare(tree[swapIndex], tree[index]) < 0)
            {
                T temp = tree[index];
                tree[index] = tree[swapIndex];
                tree[swapIndex] = temp;
            }

            HeapifyDown(swapIndex);
        }

        private void IncreaseTree()
        {
            T[] temp = new T[tree.Length * 2];
            tree.CopyTo(temp, 0);
            tree = temp;
        }

        public override string ToString()
        {
            string text = "";

            for (int i = 1; i < Count; i++)
            {
                text += tree[i] + " ";
            }

            return text;
        }
    }
}
