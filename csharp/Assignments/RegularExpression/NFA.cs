using System;
using System.Linq;

namespace RegularExpression {
    public class NFA {
        private char[] _regx;
        private Digraph _graph;
        private int _states;

        public NFA(string regexp) {
            var ops = new Stack<int>();
            _regx = regexp.ToCharArray();
            _states = _regx.Length;
            _graph = new Digraph(_states + 1);

            for (var i = 0; i < _states; i++) {
                var lp = i;
                if (_regx[i] == '(' || _regx[i] == '|') {
                    ops.Push(i);
                }
                else if (_regx[i] == ')') {
                    var or = ops.Pop();
                    if (_regx[or] == '|') {
                        lp = ops.Pop();
                        _graph.AddEdge(lp, or + 1);
                        _graph.AddEdge(or, i);
                    }
                    else lp = or;
                }

                if (i < _states - 1 && _regx[i + 1] == '*') {
                    _graph.AddEdge(lp, i + 1);
                    _graph.AddEdge(i + 1, lp);
                }

                if (_regx[i] == '(' || _regx[i] == '*' || _regx[i] == ')') {
                    _graph.AddEdge(i, i + 1);
                }
            }
        }

        public bool Recognizes(string txt) {
            var pc = new Bag<int>();
            var dfs = new DirectedDFS(_graph, 0);
            for (var v = 0; v < _graph.GetVertices(); v++) {
                if (dfs.Marked(v)) pc.Add(v);
            }

            for (var i = 0; i < txt.Length; i++) {
                var match = new Bag<int>();
                foreach (var v in pc) {
                    if (v < _states) {
                        if (_regx[v] == txt[i] || _regx[v] == '.') {
                            match.Add(v + 1);
                        }
                    }
                }

                pc = new Bag<int>();
                dfs = new DirectedDFS(_graph, match.GetSize());
                for (var v = 0; v < _graph.GetVertices(); v++) {
                    if (dfs.Marked(v)) pc.Add(v);
                }
            }

            foreach (int v in pc) {
                if (v == _states) {
                    return true;
                }
            }   
            return false; 
        }
    }
}