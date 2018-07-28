using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public class Edge<T>
    {
        public DVertex<T> StartingPoint;
        public DVertex<T> EndingPoint;
        public int Distance;
        public bool IsVisited = false;

        public Edge(DVertex<T> startingPoint, DVertex<T> endingPoint, int distance)
        {
            StartingPoint = startingPoint;
            EndingPoint = endingPoint;
            Distance = distance;            
        }
    }
}
