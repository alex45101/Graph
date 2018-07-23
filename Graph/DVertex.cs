using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class DVertex<T> : BaseVertex<T, Edge<T>>
    {
        public override Edge<T> this[int index]
        {
            get { return Neighbors[index]; }
            set { Neighbors[index] = value; }
        }

        public DVertex(T value)
            : base(value)
        { }
    }
}
