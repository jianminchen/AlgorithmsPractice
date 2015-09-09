using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackTrackABinaryTree
{
    class BackTrackABinaryTree
    {
        public class BinaryTree
        {
            public BinaryTree leftChild = null;   // 1. add memeber access level: public 
            public BinaryTree rightChild = null;
            public bool isGoalNode = false;
            public String name;

            public BinaryTree(string name, BinaryTree left, BinaryTree right, bool isGoalNode)
            {
                this.name = name;
                leftChild = left;
                rightChild = right;
                this.isGoalNode = isGoalNode; 
            }

            public static BinaryTree makeTree()     // 2. makeTree should return root node as a binary tree does; put the method in the binary tree class
            {
                 BinaryTree root, a, b, c, d, e, f;
            c = new BinaryTree("C",null, null, false);
            d = new BinaryTree("D", null, null, false);
            e = new BinaryTree("E", null, null, true);
            f = new BinaryTree("F", null, null, false);
            a = new BinaryTree("A", c, d, false);
            b = new BinaryTree("B", e, f, false);
            root = new BinaryTree("Root", a, b, false);   // 3. root node set up 

                return root; 
            }
        }


        static void Main(string[] args)
        {

            BinaryTree root = BinaryTree.makeTree();

            bool result = BackTrackSolvable(root);

            System.Console.WriteLine("Result is"+result.ToString()); 
        }

        public static bool BackTrackSolvable(BinaryTree root)
        {
            if (root == null) return false;

            if (root.isGoalNode) return true;
           
            if (BackTrackSolvable(root.leftChild)) return true;
          
            if (BackTrackSolvable(root.rightChild)) return true;
          
            return false; 
        }
    }
}
