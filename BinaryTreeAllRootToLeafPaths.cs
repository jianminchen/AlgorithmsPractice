using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeAllRootToLeafPaths
{    

    class BinaryTreeAllRootToLeafPaths
    {
        public class Node
        {
            public int data;
            public Node left;
            public Node right;

            public Node(int d)
            {
                this.data = d;
                this.left = null;
                this.right = null;
            }
        }

        static void Main(string[] args)
        {
            // write  a test case 
            Node root = new Node(10);
            root.left = new Node(8);
            root.left.left = new Node(3);
            root.left.right = new Node(5);

            root.right = new Node(2);
            root.right.left = new Node(2);

            int[] path = new int[1000];
            int pathLen = 0; 
            getBinaryTreeRootToLeafPaths(root,path, pathLen);

            Console.Write("Here is the end of testing"); 

        }

        public static void  getBinaryTreeRootToLeafPaths(Node n, int[] path, int pathLen)
        {
            // base case
            if (n == null)
                return;

            // current node - do some work - do not need to check base case
            path[pathLen] = n.data;
            pathLen++;

            // Next iteration - termination case 
            if (n.left == null && n.right == null)
            {
                PrintAll(path, pathLen);
            }
            else
            {
                // next iteration, do not do null point check, base case will take care of it
                // concern about array, local variables stuff 
                getBinaryTreeRootToLeafPaths(n.left, path, pathLen);
                getBinaryTreeRootToLeafPaths(n.right, path, pathLen); 
            }
        }

        public static void PrintAll(int[] path, int pathLen)
        {
            Console.Write("Here is the path "); 
            for (int i = 0; i < pathLen; i++)
            {
                Console.Write(path[i] + ";");
            }
            Console.WriteLine("the end"); 
        }
    }
}
