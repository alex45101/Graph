using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{    
    public class UndirectedGraph<T> : BaseGraph<T, Vertex<T>> where T : IComparable<T>
    {
        public List<Vertex<T>> Vertices { get; private set; }

        public Vertex<T> this[int index]
        {
            get { return Vertices[index]; }
            set { Vertices[index] = value; }
        }

        public int Count
        {
            get { return Vertices.Count; }
        }

        public UndirectedGraph()            
        {
            Vertices = new List<Vertex<T>>();
        }
        
        public override void AddVertex(Vertex<T> vertex)
        {
            if (Vertices.Contains(vertex))
            {
                throw new Exception("Vertex already exists");
            }

            Vertices.Add(vertex);
        }        

        public override bool RemoveVertex(Vertex<T> vertex)
        {
            for (int i = 0; i < vertex.Count; i++)
            {
                RemoveEdge(vertex, vertex.Neighbors[i]);
            }

            return Vertices.Remove(vertex);            
        }

        public override bool AddEdge(Vertex<T> a, Vertex<T> b, int distance = 0)
        {
            if (!(Vertices.Contains(a) && Vertices.Contains(b)))
            {
                return false;
            }

            Vertices[Vertices.IndexOf(a)].Neighbors.Add(b);
            Vertices[Vertices.IndexOf(b)].Neighbors.Add(a);

            return true;
        }

        public override bool RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            if (!(Vertices.Contains(a) && Vertices.Contains(b) && Vertices[Vertices.IndexOf(a)].Neighbors.Contains(b)))
            {
                return false;
            }

            Vertices[Vertices.IndexOf(a)].Neighbors.Remove(b);
            Vertices[Vertices.IndexOf(b)].Neighbors.Remove(a);
            return true;
        }

        public override Vertex<T> Search(T Value)
        {
            return Vertices[Vertices.FindIndex((a) => { return a.Value.CompareTo(Value) == 0; })];
        }

        public void DepthFirstSearch(Vertex<T> start)
        {
            depthFirstSearch(start);

            for (int i = 0; i < Count; i++)
            {
                this[i].IsVisited = false;
            }

            void depthFirstSearch(Vertex<T> current)
            {
                current.IsVisited = true;

                foreach (var vert in current.Neighbors)
                {
                    if (!vert.IsVisited)
                    {
                        Console.WriteLine($"\t{current.Value}->{vert.Value}");
                        depthFirstSearch(vert);
                    }
                }

                return;
            }
        }

        

        public void BreadthFirstTraversal(Vertex<T> start)
        {
            breadthFirstTraversal(start, new Queue<Vertex<T>>(new Vertex<T>[] { start }));

            for (int i = 0; i < Count; i++)
            {
                this[i].IsVisited = false;
            }

            void breadthFirstTraversal(Vertex<T> current, Queue<Vertex<T>> queue)
            {
                current.IsVisited = true;

                foreach (var vert in current.Neighbors)
                {
                    if (!vert.IsVisited && !queue.Contains(vert))
                    {
                        queue.Enqueue(vert);
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
    }
}
