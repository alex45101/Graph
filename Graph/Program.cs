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

            PriorityQueue<int> queue = new PriorityQueue<int>(Comparer<int>.Create((a, b) => a.CompareTo(b)));

            for (int i = 10; i > 0; i--)
            {
                queue.Enqueue(i);
                Console.WriteLine(queue.ToString());
            }

            Console.WriteLine();
            
            for (int i = 0; i < 10; i++)
            {
                queue.Dequeue();
                Console.WriteLine(queue.ToString());
            }

            var vertices = (Stack<DVertex<int>>)directed.Dijkstra(directed[0], directed[4]);
            int count = vertices.Count;

            for (int i = 0; i < count; i++)
            {
                Console.Write($"{vertices.Pop().Value}{(i == count - 1 ? "\n" : "->") }");
            }

            DirectedGraph<string> houseThing = new DirectedGraph<string>();

            //https://brilliant.org/wiki/dijkstras-short-path-finder/

            houseThing.AddVertex(new DVertex<string>("Home"));      //0
            houseThing.AddVertex(new DVertex<string>("A"));         //1
            houseThing.AddVertex(new DVertex<string>("B"));         //2
            houseThing.AddVertex(new DVertex<string>("C"));         //3
            houseThing.AddVertex(new DVertex<string>("D"));         //4
            houseThing.AddVertex(new DVertex<string>("E"));         //5
            houseThing.AddVertex(new DVertex<string>("F"));         //6
            houseThing.AddVertex(new DVertex<string>("School"));    //7

            houseThing.AddEdge(houseThing[0], houseThing[1], 3);
            houseThing.AddEdge(houseThing[0], houseThing[2], 2);
            houseThing.AddEdge(houseThing[0], houseThing[3], 5);
            houseThing.AddEdge(houseThing[1], houseThing[4], 3);
            houseThing.AddEdge(houseThing[2], houseThing[4], 1);
            houseThing.AddEdge(houseThing[2], houseThing[5], 6);
            houseThing.AddEdge(houseThing[3], houseThing[5], 2);
            houseThing.AddEdge(houseThing[4], houseThing[6], 4);
            houseThing.AddEdge(houseThing[5], houseThing[6], 1);
            houseThing.AddEdge(houseThing[5], houseThing[7], 4);
            houseThing.AddEdge(houseThing[6], houseThing[7], 2);

            var housePath = (Stack<DVertex<string>>)houseThing.Dijkstra(houseThing[0], houseThing[7]);
            count = housePath.Count - 1;

            for (int i = 0; i < count; i++)
            {
                Console.Write($"{housePath.Pop().Value}{(i == count - 1 ? "\n" : "->") }");
            }

            Console.ReadKey();
        }        
    }
}
