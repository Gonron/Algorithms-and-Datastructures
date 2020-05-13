using System.Collections.Generic;

namespace AirlineRoutingSystem {
    public interface IGraph {
        
        int V { get; }
        int E { get; }
        void AddEdge(int v, int w);
        void AddUndirectedEdge(int v, int w) {
            AddEdge(v, w);
            AddEdge(w, v);
        }
        
        IEnumerable<int> Adjacents(int v);
    }
}