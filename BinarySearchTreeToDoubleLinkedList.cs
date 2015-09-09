using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeToDoubleLinkedList
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

        // using divide and conquer techniques; another solution is to use node rotation 
        public static void convertBSTToDLL(Node root, ref Node header)
        {
            if (root == null)
            {
                header = null;
                return; 
            }

            Node lastNode = null;

            convertBSTToDLLCore(root, ref lastNode);   
            
            // we need to get the header node; go upper to the last node and find the header
            header = lastNode;   // test cases: null, one node, more than one, ...
            while (lastNode != null && lastNode.left !=null)
            {                
                header = lastNode.left;
                lastNode = lastNode.left;
            }
        }

        public static void convertBSTToDLLCore(Node root, ref Node lastNodeInDLList)
        {
            if (root == null)
                return;

            Node currentNode = root;

            convertBSTToDLLCore(root.left, ref lastNodeInDLList);

            currentNode.left = lastNodeInDLList;

            if (lastNodeInDLList != null)  // avoid crash
                lastNodeInDLList.right = currentNode;


            lastNodeInDLList = currentNode;
            convertBSTToDLLCore(root.right, ref lastNodeInDLList); 


            return; 
        }

        static void Main(string[] args)
        {
            Node root = new Node(10);
            root.left = new Node(8);
            root.left.left = new Node(7);
            root.left.right = new Node(9);
            root.right = new Node(12);
            root.right.left = new Node(11);
            root.right.right = new Node(13);

            Node header = null;

            convertBSTToDLL(root, ref header); 
        }
    }
}
