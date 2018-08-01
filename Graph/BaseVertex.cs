using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public abstract class BaseVertex<TData, TEdge> : IComparable<BaseVertex<TData, TEdge>> where TData : IComparable<TData>
    {
        public TData Value;
        public List<TEdge> Neighbors;
        public bool IsVisited;

        public abstract TEdge this[int index] { get; set; }        

        public int Count
        {
            get { return Neighbors.Count; }
        }

        public BaseVertex(TData value)
        {
            Value = value;
            Neighbors = new List<TEdge>();
        }

        public int CompareTo(BaseVertex<TData, TEdge> obj)
        {
            return Value.CompareTo(obj.Value);
        }
    }
}
