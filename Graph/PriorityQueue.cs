using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class PriorityQueue<T> where T : IComparable
    {
        private T[] tree = new T[30];
        private IComparer<T> comparer;
        public int Count { get; private set; }
        public T this[int i]
        {
            get
            {
                if (i > -1 && i < Count)
                {
                    return tree[i];
                }

                throw new ArgumentOutOfRangeException();
            }
        }

        public PriorityQueue(IComparer<T> comparer)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
            Count = 0;
        }

        public void Enqueue(T value)
        {
            Count++;

            if (Count == tree.Length)
            {
                IncreaseTree();
            }

            tree[Count] = value;

            //HeapifyUp   
            HeapifyUp(Count);
        }

        public T Dequeue()
        {
            T root = tree[0];

            tree[0] = tree[Count - 1];
            tree[Count - 1] = default(T);

            //HeapifyDown

            return root;

        }

        //TODO Finish
        private void HeapifyUp(int index)
        {
            int parent = index / 2;

            if (comparer.Compare(tree[parent], tree[0]) == 0)
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

        private void IncreaseTree()
        {
            T[] temp = new T[tree.Length * 2];
            tree.CopyTo(temp, 0);
            tree = temp;
        }
    }
}
