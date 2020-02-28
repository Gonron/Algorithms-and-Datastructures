using System;
using System.Collections;
using System.Collections.Generic;
using PriorityQueue.interfaces;
using PriorityQueue.util;

namespace PriorityQueue {
    public class LinkedPriorityQueue<T> : IPriorityQueue<T> where T : IComparable<T> {
        private Node<T> root; 
        private int n;
        
        
        public bool IsEmpty() {
            return n == 0;
        }

        public int GetSize() {
            return n;
        }

        public void Enqueue(T item) {
            if (n == 0) {
                n++;
                root = new Node<T>(item,null);
            }
            else {
                var currentNode = root;
                for (int i = 0; i < n; i++) {
                    // New item is less then the first
                    if (i == 0 && Less(item, currentNode.Value)) {
                        var temp = currentNode;
                        root = new Node<T>(item, temp);
                        n++;
                        return;
                    }
                    // Reached the end of the queue
                    if (i == n - 1) {
                        currentNode.Next = new Node<T>(item,null);
                        n++;
                        return;
                    }
                    // Current item is less then next values, insert new item before next item
                    if (Less(item, currentNode.Next.Value)) {
                        var temp = currentNode.Next;
                        currentNode.Next = new Node<T>(item, temp);
                        n++;
                        return;
                    }
                    currentNode = currentNode.Next;
                }
            }
        }

        public T Dequeue() {
            var nodeToReturn = root;
            root = root.Next;
            n--;
            return nodeToReturn.Value;
        }

        public T Peek() {
            return root.Value;
        }
        
        private static bool Less(T a, T b) {
            return a.CompareTo(b) < 0;
        }
        
        public IEnumerator<T> GetEnumerator() {
            return new NodeIterator<T>(root);
        }
        
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}