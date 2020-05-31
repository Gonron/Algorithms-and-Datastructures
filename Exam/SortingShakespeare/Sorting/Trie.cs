using System;

namespace SortingShakespeare.Sorting {
    public class Trie {
        private static int _currIndex;

        public static void Sort(string[] arr) {
            Console.WriteLine(
                $"\nTime Complexity: \n- Best: O(1) \n- Worst: O(n) " +
                $"\nSpace Complexity: \n- n * (avg Lengths of word) * (size of alphabet) \n");
            
            var root = new TrieNode();
            foreach (var ele in arr) {
                root.Insert(root, ele, ele);
            }
            
            TrieToArray(root, arr);
        }

        private static void TrieToArray(TrieNode node, string[] arr) {
            if (node == null) return;
            // If the node actually has a value, add it/them to the array
            if (!string.IsNullOrEmpty(node.Value)) {
                for (var i = 0; i < node.Count; i++) {
                    arr[_currIndex++] = node.Value;
                }
            }

            foreach (var child in node.Children) {
                TrieToArray(child, arr);
            }
        }
        
        public class TrieNode {
            public readonly TrieNode[] Children;
            public int Count;
            public string Value;

            public TrieNode() {
                Count = 0;
                Value = "";
                Children = new TrieNode[28];
            }

            public void Insert(TrieNode node, string str, string value) {
                //Console.WriteLine(str);
                foreach (var c in str) {
                    var currIndex = GetHashValue(c);
                    //Console.WriteLine($"char: {c} HashValue: {currIndex}");
                    var childNode = node.Children[currIndex];
                    // If the current character does not exist in the array, insert it
                    if (childNode == null) {
                        node.Children[currIndex] = new TrieNode();
                    }
                    // Move to the next child
                    node = node.Children[currIndex];
                }

                if (string.IsNullOrEmpty(node.Value)) {
                    node.Value = value;
                }
                node.Count++;
            }

            public static void PrintTrie(TrieNode node) {
                if (node == null) return;
                if (!string.IsNullOrEmpty(node.Value))
                    Console.WriteLine($"{node.Value} {node.Count}");
                // here you can play with the order of the children
                foreach (var child in node.Children) {
                    PrintTrie(child);
                }
            }

            private static int GetHashValue(char c) {
                // Return 26 if char is '
                // Return 27 if char is -
                // Default return value is char - 97
                return c switch {
                    '\'' => 0,
                    '-' => 1,
                    _ => c - 95
                };
            }
        }
    }
}