using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Edge<T>
    {
        public Vertex<T> StartingPoint;
        public Vertex<T> EndingPoint;
        public int Distance;
        public bool IsVisite = false;

        public Edge(Vertex<T> startingPoint, Vertex<T> endingPoint, int distance)
        {
            StartingPoint = startingPoint;
            EndingPoint = endingPoint;
            Distance = distance;            
        }
    }
}
