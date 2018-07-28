using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            UndirectedGraph<int> undirected = new UndirectedGraph<int>();
            
            for (int i = 0; i < 7; i++)
            {
                undirected.AddVertex(new Vertex<int>(i));
            }

            undirected.AddEdge(undirected[0], undirected[1]);
            undirected.AddEdge(undirected[1], undirected[2]);
            undirected.AddEdge(undirected[1], undirected[3]);
            undirected.AddEdge(undirected[2], undirected[3]);
            undirected.AddEdge(undirected[2], undirected[4]);
            undirected.AddEdge(undirected[4], undirected[6]);
            undirected.AddEdge(undirected[6], undirected[5]);               

            Console.WriteLine("Undirected Depth-First Search:");
            undirected.DepthFirstSearch(undirected[0]);

            Console.WriteLine("\nUndirected Breadth-First Traversal:");
            undirected.BreadthFirstTraversal(undirected[0]);

            DirectedGraph<int> directed = new DirectedGraph<int>();

            directed.AddVertex(new DVertex<int>(0));//0
            directed.AddVertex(new DVertex<int>(8));//1
            directed.AddVertex(new DVertex<int>(5));//2
            directed.AddVertex(new DVertex<int>(9));//3
            directed.AddVertex(new DVertex<int>(7));//4

            directed.AddEdge(directed[0], directed[1], 10); //0->8
            directed.AddEdge(directed[0], directed[2], 5);  //0->5
            directed.AddEdge(directed[1], directed[2], 2);  //8->5
            directed.AddEdge(directed[1], directed[3], 1);  //8->9
            directed.AddEdge(directed[2], directed[1], 3);  //5->8
            directed.AddEdge(directed[2], directed[3], 9);  //5->9
            directed.AddEdge(directed[2], directed[4], 2);  //5->7
            directed.AddEdge(directed[3], directed[4], 4);  //9->7
            directed.AddEdge(directed[4], directed[3], 6);  //7->9
            directed.AddEdge(directed[4], directed[0], 7);  //7->0

            Console.WriteLine("\nDirected Depth-First Search:");
            directed.DepthFirstSearch(directed[0]);

            Console.WriteLine("\nDirected Breadth-First Traversal:");
            directed.BreadthFirstTraversal(directed[0]);

            Console.ReadKey();
        }        
    }
}
