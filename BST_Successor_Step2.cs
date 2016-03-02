using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST_Successor_Step2
{
    public class Node
    {
        public Node left;
        public Node right;
        public Node parent;
        public int val;

        public Node(int v)
        {
            val = v; 
        }
    }

    class BST_Successor_Step2
    {
        static void Main(string[] args)
        {
            Node n1  = new Node(4);
            n1.left  = new Node(2);
            n1.right = new Node(6);
            n1.left.left = new Node(1);
            n1.left.right = new Node(3);

            n1.right.left = new Node(5);
            n1.right.right = new Node(7);

            // set parent 
            n1.parent = null;
            n1.left.parent = n1;
            n1.left.left.parent = n1.left;
            n1.left.right.parent = n1.left;

            // set parent 
            n1.right.parent = n1;
            n1.right.left.parent = n1.right;
            n1.right.right.parent = n1.right;

            Node p3 = getSuccessor(n1.left.right);
            Node p4 = getSuccessor(n1);

            Console.WriteLine("Node 3's succesor is " + p3.val);
            Console.WriteLine("Node 4's successor is " + p4.val); 
        }

        /*
         * step 1: 
         * work on simple test case
         * 
         *     4
         *  3     5
         *  
         * There are bugs in the thinking of successor 
         *  
         * For node 4, the successor is 5
         * For node 5, the successor is null, 
         * For node 3, the successor is 4
         * 
         * step 2:
         * 
         * Interviewer gives out hint, there are more than 2 cases to fail, and then, Julia gives out the tree based on the advice:
         * 
         *          4
         *     2          6
         *   1   3      5    7
         *   
         *   For node 3, the successor of 3 is 4. 
         *   For node 4, the successor of 4 is 6
         *   
         * And then, julia added her input: 
         *   
         *   For node 3, the successor of 3 is 4. // To fix the bug, add a function called checkRelationship() 
         *   while retrieving grandParent etc. 
         *   For node 4, the successor of 4 is 6  // To fix the bug, add a function called getLeftMostNode(Node nd)
         *   
         *  getLeftMostNode is easy, write the function first. 
         */

        public static Node getSuccessor(Node nd)
        {
            if (nd == null)
                return null;

            if (nd.right == null)
            {
                Node second; 
                while (nd.parent != null )
                {
                    second = nd; 
                    nd = nd.parent;

                    if (checkRelatinship(nd, second))
                    {
                        continue; 
                    }
                    else
                        return nd; 
                }

                return null; 
            }
            else
                return getLeftMostNode(nd.right);
        }

        private static Node getLeftMostNode(Node nd)
        {
            if (nd == null) return null;

            while (nd.left != null)
            {
                nd = nd.left; 
            }

            return nd; 
        }

        /*
         *          4
         *     2          6
         *   1   3  
         *   
         *  3 -> 2 -> 4
         */
        private static bool checkRelatinship(Node nd, Node second)
        {
            if (nd.right == second)
                return true;
            return false; 
        }
    }
}
