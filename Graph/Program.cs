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
            UndirectedGraph<int> graph = new UndirectedGraph<int>();
            
            for (int i = 0; i < 7; i++)
            {
                graph.AddVertex(new Vertex<int>(i));
            }

            graph.AddEdge(graph[0], graph[1]);
            graph.AddEdge(graph[1], graph[2]);
            graph.AddEdge(graph[1], graph[3]);
            graph.AddEdge(graph[2], graph[3]);
            graph.AddEdge(graph[2], graph[4]);
            graph.AddEdge(graph[4], graph[6]);
            graph.AddEdge(graph[6], graph[5]);               

            Console.WriteLine("Depth-First Search:");
            graph.DepthFirstSearch(graph[0]);

            Console.WriteLine("\nBreadth-First Traversal:");
            graph.BreadthFirstTraversal(graph[0]);                

            Console.ReadKey();
        }        
    }
}
