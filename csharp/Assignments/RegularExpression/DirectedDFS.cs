using System;

namespace RegularExpression {
    public class DirectedDFS {

        private bool[] _marked;

        public DirectedDFS(Digraph graph, int size) {
            _marked = new bool[graph.GetVertices()];
            DFS(graph, size);
        }

        private void DFS(Digraph graph, int v) {
            _marked[v] = true;
            foreach (var w in graph.Adj(v)) {
                if (!_marked[w]) DFS(graph, w); {
                }
            }
        }

        public bool Marked(int v) {
            return _marked[v];
        }
    }
}