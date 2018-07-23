using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class DirectedGraph<T> : IGraph<T, DVertex<T>> where T : IComparable
    {
        public List<DVertex<T>> Vertices { get; private set; }

        public DVertex<T> this[int index]
        {
            get { return Vertices[index]; }
            set { Vertices[index] = value; }
        }

        public int Count
        {
            get { return Vertices.Count; }
        }

        public DirectedGraph()
        {
            Vertices = new List<DVertex<T>>();
        }

        public void AddVertex(DVertex<T> vertex)
        {
            if (Vertices.Contains(vertex))
                throw new Exception("Vertex already exists");

            Vertices.Add(vertex);
        }

        public bool RemoveVertex(DVertex<T> vertex)
        {
            if (!Vertices.Contains(vertex))
            {
                return false;
            }
            
            //TODO finish

            return true;
        }

        public bool AddEdge(DVertex<T> a, DVertex<T> b)
        {
            throw new NotImplementedException();
        }

        public bool RemoveEdge(DVertex<T> a, DVertex<T> b)
        {
            throw new NotImplementedException();
        }

        public DVertex<T> Search(T value)
        {
            throw new NotImplementedException();
        }
    }
}
