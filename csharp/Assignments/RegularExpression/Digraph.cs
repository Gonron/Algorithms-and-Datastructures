using System.Collections.Generic;

namespace RegularExpression {
    public class Digraph {
        private int _vertices;
        private int _edges;
        private Bag<int>[] _adj;

        public Digraph(int vertices) {
            _vertices = vertices;
            _edges = 0;
            _adj = new Bag<int>[_vertices];
            for (var i = 0; i < _vertices; i++) {
                _adj[i] = new Bag<int>();
            }
        }

        public int GetVertices()  {  return _vertices;  }   
        public int GetEdges()  {  return _edges;  } 
        
        public void AddEdge(int v, int w) {
            _adj[v].Add(w);
            _edges++;
        }

        public IEnumerable<int> Adj(int v) {
            return _adj[v];
        }

        public Digraph Reverse(int v) {
            var graph = new Digraph(v);
            for (var i = 0; i < _vertices; i++) {
                foreach (var w in _adj[v]) {
                    graph.AddEdge(w, v);
                }
            }
            return graph;
        }
    }
}