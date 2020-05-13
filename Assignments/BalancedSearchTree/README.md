# Assignment #3 - Implement a Balanced Search Tree

In this assigment i've decided to implement a Red Black Tree, mainly because i found it difficult to find materials about 2-3 Trees on the internet. However there was lots of information about AA-, AVL-, Red Black- and 2-4-Trees.

Nonetheless, i'm planning to also implement a 2-3-Tree after next lesson.

## Rules of Red Black Trees (not in any particular order):

1. Every node is either RED or BLACK
2. The root node is BLACK
3. Every leaf node (null) is BLACK
4. Every RED node has two BLACK child nodes
5. Every path from node x to a leaf node has the same number of BLACK nodes (BLACK height)

## VIOLATIONS and SOLUTIONS:

**Case 1:**

1. Uncle is Red

**Solution for Case 1:**

1. Swap colors of Parent, Uncle, and Grandparent
2. Grandparent becomes the new node to check for violations

**Case 2:**

1. Uncle is Black
   2a. Node is a Left Child of a Right Child
   2b. Node is a Right Child of a Left Child

**Solution for Case 2:**
1a. Right rotate around Parent for 2a = Case 3
1b. Left rotate around Parent for 2b = Case 3

2. Parent becomes the new node to check for violations

**Case 3:**

1. Uncle is Black
   2a. Node is a Right Child of a Right Child
   2b. Node is a Left Child of a Left Child

**Solution for Case 3:**
1a. Left rotate around Grandparent for 2a
1b. Right rotate around Grandparent for 2b

2. Swap colors of Parent and Grandparent
3. Grandparent becomes the new node to check for violations

**INSERTION**
To insert a node, you begin at the root of the tree, and follow the rules of a Binary Search Tree, to insert the new node. The only difference is that you have to give the node a starting color (RED) and then after the insertion, check for violations (as described above).

**DELETION**
To delete a node, you follow the rules of deletion for Binary Search Trees. There are three scenarios:

Assuming we want to delete node x:

1. If node x has no children, then just delete node x.
2. If node x has one child, then replace node x with it's child, and delete node x.
3. If node x has two children, then replace node x with either its predecessor or successor, and delete node x.

For scenario 2 or 3 above, you would then check for violations at the node that replaced node x.

Link to [Youtube Video](https://www.youtube.com/watch?v=PhY56LpCtP4) that explains about Red-Black-Trees
