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
            Edges = new List<Edge<T>>();
        }
        
        public override void AddVertex(DVertex<T> vertex)
        {
            if (Vertices.Contains(vertex))
            {
                throw new Exception("Vertex already exists");
            }

            Vertices.Add(vertex);
        }

        public override bool AddEdge(DVertex<T> a, DVertex<T> b, int distance)
        {
            if (GetEdge(a, b) != null)
            {
                return false;
            }

            a.Neighbors.Add(new Edge<T>(a, b, distance));
            Edges.Add(a.Neighbors[a.Count - 1]);
            return true;
        }
        

        public override bool RemoveVertex(DVertex<T> vertex)
        {
            if (!Vertices.Contains(vertex))
            {
                return false;
            }
            
            for (int i = 0; i < Edges.Count; i++)
            {
                if (Edges[i].StartingPoint == vertex)
                {
                    Edges.RemoveAt(i);
                    i--;
                }
                else if (Edges[i].EndingPoint == vertex)
                {
                    Edges[i].StartingPoint.Neighbors.RemoveAt(Edges[i].StartingPoint.Neighbors.FindIndex((a) => { return a.EndingPoint == vertex; }));                    
                    Edges.RemoveAt(i);
                    i--;
                }
            }

            Vertices.Remove(vertex);

            return true;
        }        

        public override bool RemoveEdge(DVertex<T> a, DVertex<T> b)
        {
            Edge<T> temp = GetEdge(a, b);
            if (temp == null)
            {
                return false;
            }

            a.Neighbors.Remove(temp);
            Edges.Remove(temp);
            return true;
        }

        public override DVertex<T> Search(T value)
        {
            return Vertices[Vertices.FindIndex((a) => { return a.Value.CompareTo(value) == 0; })];
        }

        public Edge<T> GetEdge(DVertex<T> a, DVertex<T> b)
        {            
            if (!(Vertices.Contains(a) && Vertices.Contains(b)))
            {
                return null;
            }

            for (int i = 0; i < Edges.Count; i++)
            {
                if (Edges[i].StartingPoint == a && Edges[i].EndingPoint == b)
                {
                    return Edges[i];
                }
            }

            return null;
        }

        public void DepthFirstSearch(DVertex<T> start)
        {
            depthFirstSearch(start);

            for (int i = 0; i < Count; i++)
            {
                this[i].IsVisited = false;
            }

            void depthFirstSearch(DVertex<T> current)
            {
                current.IsVisited = true;

                foreach (var neighbor in current.Neighbors)
                {
                    if (!neighbor.EndingPoint.IsVisited)
                    {
                        Console.WriteLine($"\t{current.Value}->{neighbor.EndingPoint.Value}");
                        depthFirstSearch(neighbor.EndingPoint);
                    }
                }

                return;
            }
        }
        
        public void BreadthFirstTraversal(DVertex<T> start)
        {
            breadthFirstTraversal(start, new Queue<DVertex<T>>(new DVertex<T>[] { start }));

            for (int i = 0; i < Count; i++)
            {
                this[i].IsVisited = false;
            }

            void breadthFirstTraversal(DVertex<T> current, Queue<DVertex<T>> queue)
            {
                current.IsVisited = true;

                foreach (var neighbor in current.Neighbors)
                {
                    if (!neighbor.EndingPoint.IsVisited && !queue.Contains(neighbor.EndingPoint))
                    {
                        queue.Enqueue(neighbor.EndingPoint);
                    }
                }
                
                queue.Dequeue();

                if (queue.Count == 0)
                {
                    return;
                }

                Console.WriteLine($"\t{current.Value}->{queue.Peek().Value}");

                breadthFirstTraversal(queue.Peek(), queue);
            }
        }

        public IEnumerable<Vertex<T>> Dijkstra(Vertex<T> start, Vertex<T> end)
        {
            throw new IndexOutOfRangeException();
        }
    }
}
