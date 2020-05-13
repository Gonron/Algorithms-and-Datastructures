using System;
using System.Diagnostics;

namespace AirlineRoutingSystem {
    class Program {
        private static void Main(string[] args) {

            IGraph graph;
            WeightedGraph wGraph;
            var sw = new Stopwatch();
            
            #region BreadthFirstSearch

            Console.WriteLine("Breadth-First...");
            
            graph = new AdjacencyGraph(6);
            graph.AddUndirectedEdge(0, 5);
            graph.AddUndirectedEdge(0, 1);
            graph.AddUndirectedEdge(0, 2);
            graph.AddUndirectedEdge(2, 3);
            graph.AddUndirectedEdge(2, 4);
            graph.AddUndirectedEdge(3, 4);
            graph.AddUndirectedEdge(5, 3);

            sw.Start();
            
            var bfs = new BreadthFirstSearch(graph);
            bfs.SearchFrom(0);
            bfs.Print();

            sw.Stop();
            Console.WriteLine($"Total time for BFS: {sw.ElapsedMilliseconds} milliseconds");
            sw.Reset();
            
            #endregion

            #region DepthFirstSearch

            Console.WriteLine("\nDepth-First...");
            
            graph = new AdjacencyGraph(6);
            graph.AddUndirectedEdge(0, 5);
            graph.AddUndirectedEdge(0, 1);
            graph.AddUndirectedEdge(0, 2);
            graph.AddUndirectedEdge(2, 3);
            graph.AddUndirectedEdge(2, 4);
            graph.AddUndirectedEdge(3, 4);
            graph.AddUndirectedEdge(5, 3);

            sw.Start();
            
            var dfs = new DepthFirstSearch(graph);
            dfs.SearchFrom(0);
            dfs.Print();
            
            sw.Stop();
            Console.WriteLine($"Total time for DFS: {sw.ElapsedMilliseconds} milliseconds");
            sw.Reset();

            #endregion
            
            #region Djikstra

            Console.WriteLine("\nDijkstra Shortest Path...");

            wGraph = new WeightedGraph(6);
            wGraph.AddUndirectedEdge(0, 2, 3.0);
            wGraph.AddUndirectedEdge(0, 1, 2.0);
            wGraph.AddUndirectedEdge(0, 5, 1.0);
            wGraph.AddUndirectedEdge(2, 4, 4.0);
            wGraph.AddUndirectedEdge(2, 3, 3.0);
            wGraph.AddUndirectedEdge(3, 4, 5.0);
            wGraph.AddUndirectedEdge(5, 3, 2.0);

            sw.Start();
            
            var dijkstra = new Dijkstra(wGraph, 0);
            dijkstra.Print();
            
            sw.Stop();
            Console.WriteLine($"Total time for Dijkstra: {sw.ElapsedMilliseconds} milliseconds");
            sw.Reset();
            
            #endregion

            #region Djikstra 2

            Console.WriteLine("\nDijkstra Shortest Path - 2...");

            wGraph = new WeightedGraph(11);
            wGraph.AddUndirectedEdge(0,1,2.0);
            wGraph.AddUndirectedEdge(0,2,1.0);
            wGraph.AddUndirectedEdge(1,4,3.0);
            wGraph.AddUndirectedEdge(1,5,6.0);
            wGraph.AddUndirectedEdge(2,5,5.0);
            wGraph.AddUndirectedEdge(2,6,4.0);
            wGraph.AddUndirectedEdge(3,4,4.0);
            wGraph.AddUndirectedEdge(3,9,7.0);
            wGraph.AddUndirectedEdge(4,7,2.0);
            wGraph.AddUndirectedEdge(5,8,3.0);
            wGraph.AddUndirectedEdge(6,8,10.0);
            wGraph.AddUndirectedEdge(7,9,1.0);
            wGraph.AddUndirectedEdge(8,10,5.0);

            sw.Start();
            
            var dsp = new Dijkstra(wGraph, 0);
            dsp.Print();
            
            sw.Stop();
            Console.WriteLine($"Total time for Dijkstra: {sw.ElapsedMilliseconds} milliseconds");
            sw.Reset();

            #endregion
        }
    }
}