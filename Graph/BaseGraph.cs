using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public abstract class BaseGraph<TData, TEdge>
    {
        public abstract void AddVertex(TEdge vertex);
        public abstract bool RemoveVertex(TEdge vertex);
        public abstract bool AddEdge(TEdge a, TEdge b);
        public abstract bool AddEdge(TEdge a, TEdge b, int distance);
        public abstract bool RemoveEdge(TEdge a, TEdge b);
        public abstract TEdge Search(TData value);
        
    }
}
