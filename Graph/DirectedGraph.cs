using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class DirectedGraph<T> : BaseGraph<T, DVertex<T>> where T : IComparable
    {
        public List<DVertex<T>> Vertices { get; private set; }
        public List<Edge<T>> Edges { get; private set; }

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
            : base()
        {
            Vertices = new List<DVertex<T>>();
        }
        
        public override void AddVertex(DVertex<T> vertex)
        {
            if (Vertices.Contains(vertex))
                throw new Exception("Vertex already exists");            

            Vertices.Add(vertex);
        }

        public override bool AddEdge(DVertex<T> a, DVertex<T> b, int distance)
        {
            if (!Vertices.Contains(a) && !Vertices.Contains(b) && GetEdge(a, b) == null)
                return false;

            Edges.Add(new Edge<T>(a, b, distance));
            return true;
        }

        //Fix this
        public override bool AddEdge(DVertex<T> a, DVertex<T> b)
        {
            throw new NotImplementedException();
        }

        public override bool RemoveVertex(DVertex<T> vertex)
        {
            if (!Vertices.Contains(vertex))
            {
                return false;
            }

            //TODO finish            

            return true;
        }        

        public override bool RemoveEdge(DVertex<T> a, DVertex<T> b)
        {
            Edge<T> temp = GetEdge(a, b);
            if (!Vertices.Contains(a) && !Vertices.Contains(b) && temp == null)
                return false;

            Edges.Remove(temp);

            return true;
        }

        public override DVertex<T> Search(T value)
        {
            throw new NotImplementedException();
        }

        public Edge<T> GetEdge(DVertex<T> a, DVertex<T> b)
        {
            if (!Vertices.Contains(a) && !Vertices.Contains(b))
                return null;

            for (int i = 0; i < Edges.Count; i++)
            {
                if (Edges[i].StartingPoint == a && Edges[i].EndingPoint == b)
                {
                    return Edges[i];
                }
            }

            return null;
        }
    }
}
