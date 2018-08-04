using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class DirectedGraph<T> : BaseGraph<T, DVertex<T>> where T : IComparable<T>
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

        public IEnumerable<DVertex<T>> Dijkstra(DVertex<T> start, DVertex<T> end)
        {
            if (!Vertices.Contains(start) && !Vertices.Contains(end))
            {
                return null;
            }

            var info = new Dictionary<DVertex<T>, (DVertex<T> founder, int distance)>();

            var queue = new PriorityQueue<DVertex<T>>(Comparer<DVertex<T>>.Create((a, b) => info[a].distance.CompareTo(info[b].distance)));

            for (int i = 0; i < Count; i++)
            {
                this[i].IsVisited = false;
                info.Add(this[i], (null, int.MaxValue));
            }

            info[start] = (null, 0);
            queue.Enqueue(start);

            while (!queue.IsEmpty())
            {
                var vertex = queue.Dequeue();
                vertex.IsVisited = true;

                //if infinite graph, break if you just popped the end

                //find tentative distances
                foreach (var edge in vertex.Neighbors)
                {
                    var neighbor = edge.EndingPoint;
                    int tentative = edge.Distance + info[vertex].distance;
                    if (tentative < info[neighbor].distance)
                    {
                        info[neighbor] = (vertex, tentative);
                        neighbor.IsVisited = false;
                    }

                    //if they are not in the queue AND have not been visited, add them to the queue
                    if (!queue.Contains(neighbor) && !neighbor.IsVisited)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            //start at end and build stack of founders back to beginning
            Stack<DVertex<T>> stack = new Stack<DVertex<T>>();

            //todo fix
            for (int i = info.Count - 1; i > -1; i--)
            {
                var temp = info.ElementAt(i);

                if (i == 0 || stack.Count != 0 && stack.Peek().Value.CompareTo(temp.Value.founder.Value) == 0)
                {
                    stack.Push(temp.Key);
                }
            }

            return stack;
        }
    }
}
