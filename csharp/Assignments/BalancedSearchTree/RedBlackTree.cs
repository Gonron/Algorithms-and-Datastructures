using System;
using System.ComponentModel.Design;

namespace BalancedSearchTree {
    public class RedBlackTree<Key, Value> where Key : IComparable<Key> {
        private Node _root;

        private static bool RED = true;
        private static bool BLACK = false;

        private class Node {
            public Key Key;
            public Value Value;
            public Node Left, Right;
            public int N;
            public bool Color;

            public Node(Key Key, Value Value, int N, bool Color) {
                this.Key = Key;
                this.Value = Value;
                this.N = N;
                this.Color = Color;
            }
        }

        private static bool IsRed(Node n) {
            if (n == null) {
                return false;
            }

            return n.Color == RED;
        }

        private static Node RotateLeft(Node n) {
            var x = n.Right;
            n.Right = x.Left;
            x.Left = n;
            x.Color = n.Color;
            n.Color = RED;
            x.N = n.N;
            n.N = 1 + Size(n.Left) + Size(n.Right);
            return x;
        }

        private static Node RotateRight(Node n) {
            var x = n.Left;
            n.Left = x.Right;
            x.Right = n;
            x.Color = n.Color;
            n.Color = RED;
            x.N = n.N;
            n.N = 1 + Size(n.Left) + Size(n.Right);
            return x;
        }

        private static void FlipColors(Node n) {
            n.Color = RED;
            n.Left.Color = BLACK;
            n.Right.Color = BLACK;
        }

        public int Size() {
            return Size(_root);
        }

        private static int Size(Node n) {
            return n == null ? 0 : n.N;
        }

        public void Put(Key key, Value value) {
            _root = Put(_root, key, value);
            _root.Color = BLACK;
        }

        private static Node Put(Node n, Key key, Value value) {
            if (n == null) return new Node(key, value, 1, RED);

            var cmp = key.CompareTo(n.Key);

            if (cmp < 0) n.Left = Put(n.Left, key, value);
            else if (cmp > 0) n.Right = Put(n.Right, key, value);
            else n.Value = value;

            if (IsRed(n.Right) && !IsRed(n.Left)) n = RotateLeft(n);
            if (IsRed(n.Left) && IsRed(n.Left.Left)) n = RotateRight(n);
            if (IsRed(n.Left) && IsRed(n.Right)) FlipColors(n);

            n.N = Size(n.Left) + Size(n.Right) + 1;
            return n;
        }

        public Value Get(Key key) {
            if (key == null) throw new ArgumentException("Key is null");
            return Get(_root, key);
        }

        private static Value Get(Node n, Key key) {
            while (n != null) {
                var cmp = key.CompareTo(n.Key);
                if (cmp < 0) n = n.Left;
                else if (cmp > 0) n = n.Right;
                else return n.Value;
            }

            throw new Exception("Key: " + key + " Doesn't exists");
        }
        public int height() {
            return height(_root);
        }
        private static int height(Node x) {
            if (x == null) return -1;
            return 1 + Math.Max(height(x.Left), height(x.Right));
        }
    }
    
}