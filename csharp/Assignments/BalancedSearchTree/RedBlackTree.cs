using System;
using System.ComponentModel.Design;

namespace BalancedSearchTree {
    public class RedBlackTree<Key, Value> where Key : IComparable<Key> {
        private Node _root;

        private static bool RED = true;
        private static bool BLACK = false;

        private class Node {
            public Key key;
            public Value value;
            public Node left, right;
            public int size;
            public bool color;

            public Node(Key key, Value value, int size, bool color) {
                this.key = key;
                this.value = value;
                this.size = size;
                this.color = color;
            }
        }

        private static bool IsRed(Node n) {
            if (n == null) {
                return false;
            }

            return n.color == RED;
        }

        private static Node RotateLeft(Node n) {
            var x = n.right;
            n.right = x.left;
            x.left = n;
            x.color = n.color;
            n.color = RED;
            x.size = n.size;
            n.size = 1 + Size(n.left) + Size(n.right);
            return x;
        }

        private static Node RotateRight(Node n) {
            var x = n.left;
            n.left = x.right;
            x.right = n;
            x.color = n.color;
            n.color = RED;
            x.size = n.size;
            n.size = 1 + Size(n.left) + Size(n.right);
            return x;
        }

        private static void FlipColors(Node n) {
            n.color = RED;
            n.left.color = BLACK;
            n.right.color = BLACK;
        }

        public int Size() {
            return Size(_root);
        }

        private static int Size(Node n) {
            return n == null ? 0 : n.size;
        }

        public void Put(Key key, Value value) {
            _root = Put(_root, key, value);
            _root.color = BLACK;
        }

        private static Node Put(Node n, Key key, Value value) {
            if (n == null) return new Node(key, value, 1, RED);
            var cmp = key.CompareTo(n.key);
            
            if (cmp < 0) n.left = Put(n.left, key, value);
            else if (cmp > 0) n.right = Put(n.right, key, value);
            else n.value = value;
            
            if (IsRed(n.right) && !IsRed(n.left)) n = RotateLeft(n);
            if (IsRed(n.left) && IsRed(n.left.left)) n = RotateRight(n);
            if (IsRed(n.left) && IsRed(n.right)) FlipColors(n);

            n.size = Size(n.left) + Size(n.right) + 1;
            return n;
        }

        public Value Get(Key key) {
            if (key == null) throw new ArgumentException("Key is null");
            return Get(_root, key);
        }

        private static Value Get(Node n, Key key) {
            while (n != null) {
                var cmp = key.CompareTo(n.key);
                if (cmp < 0) n = n.left;
                else if (cmp > 0) n = n.right;
                else return n.value;
            }

            throw new Exception("Key: " + key + " Doesn't exists");
        }

        public int Height() {
            return Height(_root);
        }

        private static int Height(Node n) {
            if (n == null) return -1;
            return 1 + Math.Max(Height(n.left), Height(n.right));
        }
    }
}