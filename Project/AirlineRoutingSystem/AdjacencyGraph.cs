using System;
using System.Collections.Generic;

namespace AirlineRoutingSystem {
    public class AdjacencyGraph : IGraph {
        public int V { get; }
        public int E { get; private set; }
        private readonly EdgeNode[] _vertices;

        public AdjacencyGraph(int v) {
            V = v;
            E = 0;
            _vertices = new EdgeNode[v];
        }

        public class EdgeNode {
            internal int V;
            internal EdgeNode Next;

            internal EdgeNode(int v, EdgeNode next) {
                V = v;
                Next = next;
            }
        }

        public void AddEdge(int v, int w) {
            var node = new EdgeNode(w, _vertices[v]);
            _vertices[v] = node;
            E++;
        }
        
        public IEnumerable<int> Adjacents(int v) {
            IList<int> adjacents = new List<int>();
            var node = _vertices[v];
            while (node != null) {
                adjacents.Add(node.V);
                node = node.Next;
            }
            return adjacents;
        }

        public override string ToString() {
            var text = "";
            for (var v = 0; v < V; v++) {
                text += "" + v + ": " + Adjacents(v) + "\n";
            }
            return text;
        }
    }
    
}