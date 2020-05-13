
using System;
using AirlineRoutingSystem.basics;

namespace AirlineRoutingSystem {
    public class DepthFirstSearch {
        private IGraph _graph;
        private int[] _visitedFrom;
        private IStack<Edge> _edges;

        public DepthFirstSearch(IGraph graph) {
            _graph = graph;
            _visitedFrom = new int[_graph.V];
            for (var v = 0; v < _visitedFrom.Length; v++) _visitedFrom[v] = -1;
            _edges = new ArrayStack<Edge>(1_000);
        }

        private class Edge {
            internal int From;
            internal int To;

            internal Edge(int from, int to) {
                From = from;
                To = to;
            }

            public override string ToString() {
                return "" + From + " -> " + To;
            }
        }

        private void Register(Edge edge) {
            if (_visitedFrom[edge.To] != -1) return;
            _edges.Push(edge);
            _visitedFrom[edge.To] = edge.From;
        }

        public void SearchFrom(int v) {
            Register(new Edge(v, v));
            while (!_edges.IsEmpty()) {
                var step = _edges.Pop();
                foreach (var w in _graph.Adjacents(step.To)) {
                    Register(new Edge(step.To, w));
                }
            }
        }

        public string ShowPathTo(int w) {
            var path = "" + w;
            while (_visitedFrom[w] != w  && _visitedFrom[w] != -1) {
                w = _visitedFrom[w];
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