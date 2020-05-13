using System.Collections;
using System.Collections.Generic;

namespace AirlineRoutingSystem {
    public class WeightedGraph {
        public int V { get; }
        private List<Edge>[] _vertices;

        public WeightedGraph(int V) {
            this.V = V;
            _vertices = new List<Edge>[V];
            for (var v = 0; v < V; v++) _vertices[v] = new List<Edge>();
        }

        public class Edge {
            public int From;
            public int To;
            public double Weight;

            internal Edge(int from, int to, double weight) {
                From = from;
                To = to;
                Weight = weight;
            }
        }

        public void AddEdge(int v, int w, double weight) {
            var edge = new Edge(v, w, weight);
            _vertices[v].Add(edge);
        }
        
        public void AddUndirectedEdge(int v, int w, double weight) {
            AddEdge(v, w, weight);
            AddEdge(w, v, weight);
        }
        
        
        public IEnumerable<Edge> Adjacents(int v) {
            return _vertices[v];
        }
    }

    
}