using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeIsSymmetric
{
    public class Node
    {
        public Node left;
        public Node right;
        public int data; 

        public Node(int d)
        {
            this.data = d; 
        }

        public static bool isSymmetricTree(Node root)
        {
            if (root == null)
                return true;

            return isSymmetricTreeCore(root, root); 
        }

        /*
         * 1. empty node tree is symmetric
         * 2. Base case: if the binary tree has 3 nodes, left child value should be equal to right child value
         * 3. If the tree order level is more than 2, the left child of left child should be equal to right child of right child;
         * the right child of left child should be equal to left child of right child
         * 4. Recursively do the same thing 
         * 5. Check the code redundancy, and make sure that no redudant code; check the code logic 
         */
        public static bool isSymmetricTreeCore(Node lNode, Node rNode)
        {
            if (lNode == null && rNode == null)
                return true;    // empty tree is symmetric 

            if (lNode == null || rNode == null)
                return false;

            // base case, 3 nodes in the tree
            if (lNode.data != rNode.data)
                return false; 

            return isSymmetricTreeCore(lNode.left, rNode.right) &&
                   isSymmetricTreeCore(lNode.right, rNode.left); 
        }

        static void Main(string[] args)
        {
            Node root = new Node(6);

            root.left = new Node(8);
            root.right = new Node(8);
            root.left.left = new Node(9);
            root.left.right = new Node(10);
            root.right.left = new Node(10);
            root.right.right = new Node(7);

            bool result = isSymmetricTree(root);                
        }
    }
}
