
using System;
using System.Data;
using AirlineRoutingSystem.basics;

namespace AirlineRoutingSystem {
    public class Dijkstra {
        private WeightedGraph _graph;
        private int _source;
        private int[] _edgeTo;
        private double[] _distTo;
        private PriorityQueue<Path> _pqMin = new PriorityQueue<Path>(1_000);

        public Dijkstra(WeightedGraph graph, int source) {
            _graph = graph;
            _source = source;
            var V = graph.V;
            _edgeTo = new int[V];
            _distTo = new double[V];
            
            for (var v = 0; v < V; v++) {
                _edgeTo[v] = -1;
                _distTo[v] = double.MaxValue;
            }
            
            _edgeTo[source] = source;
            _distTo[source] = 0;
            _pqMin.Enqueue(new Path(source, 0.0));
            Build();
        }

        public class Path : IComparable<Path> {
            public int v;
            double weight;

            public Path(int v, double weight) {
                this.v = v;
                this.weight = weight;
            }

            public int CompareTo(Path other) {
                if (weight < other.weight) return -1;
                if (weight > other.weight) return 1;
                return 0;
            }
        }

        private void Build() {
            while (!_pqMin.IsEmpty()) {
                var path = _pqMin.Dequeue();
                Relax(path);
            }
        }

        private void Relax(Path path) {
            var adj = _graph.Adjacents(path.v);
            foreach (var edge in adj) {
                var newDistance = _distTo[edge.From] + edge.Weight;
                if (_distTo[edge.To] > newDistance) {
                    _distTo[edge.To] = newDistance;
                    _edgeTo[edge.To] = edge.From;
                    _pqMin.Enqueue(new Path(edge.To, newDistance));
                }
            }
        }

        public string ShowPathTo(int w) {
            var path = "" + w;
            while (_edgeTo[w] != w && _edgeTo[w] != -1) {
                w = _edgeTo[w];
                path = "" + w + " -> " + path;
            }
            return path;
        }

        public void Print() {
            for (var v = 0; v < _graph.V; v++) {
                Console.WriteLine("" + v + ": " + ShowPathTo(v));
            }
        }
    }
}