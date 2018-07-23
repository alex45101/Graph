using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Vertex<T> : BaseVertex<T, Vertex<T>>
    {
        public override Vertex<T> this[int index]
        {
            get { return Neighbors[index]; }
            set { Neighbors[index] = value; }
        }

        public Vertex(T value)
            : base(value)
        { }
    }
}
