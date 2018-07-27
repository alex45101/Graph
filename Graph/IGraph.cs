using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public interface IGraph<TData, TEdge>
    {
        void AddVertex(TEdge vertex);
        bool RemoveVertex(TEdge vertex);
        bool AddEdge(TEdge a, TEdge b);        
        bool RemoveEdge(TEdge a, TEdge b);
        TEdge Search(TData value);             
    }
}
