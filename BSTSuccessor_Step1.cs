using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTSuccessor
{
    /*
     * 
     *  Given a node n in a binary search tree, explain and code the most efficient way to 
     *  find the successor of n.
        Analyze the runtime complexity of your solution.
     */
    public class Node
    {
        public Node left;
        public Node right;
        public Node parent;
        public int val; 
    }
    class BSTSuccessor_Step1
    {
        static void Main(string[] args)
        {
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
         */

        public static Node getSuccessor(Node nd)
        {
            if (nd == null)
                return null;

            if (nd.right == null)
            {
                if (nd.parent != null && nd.parent.left == nd)
                {
                    return nd.parent;
                }
                else
                    return null; 
            }
            else
                return nd.right;           
        }
    }
}
