using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorrisInOrderTraverse
{
    class MorrisInOrderTraverse
    {
        static void Main(string[] args)
        {
            var node1 = new Node();
            var node2 = new Node();
            var node3 = new Node();
            var node4 = new Node();
            var node5 = new Node();
            var node6 = new Node();
            var node7 = new Node();
            var node8 = new Node();
            var node9 = new Node();
            var node10 = new Node();

            node1.data = 1;
            node2.data = 2;
            node3.data = 3;
            node4.data = 4;
            node5.data = 5;
            node6.data = 6;
            node7.data = 7;
            node8.data = 8;
            node9.data = 9;
            node10.data = 10;

            node1.left = node2;
            node1.right = node3;

            node2.left = node4;
            node2.right = node5;

            node3.left = node6;
            node3.right = node7;

            node4.left = node8;
            node4.right = node9;

            node5.left = node10;

            inorderMorrisTraversal(node1); 

        }
        /* http://codingrecipies.blogspot.ca/2013/11/morris-inorder-traversal.html  */
        public static void inorderMorrisTraversal(Node root){
  
            if(root==null)
                return ;
  
            Node current=root;
            
            while(current!=null){
   
                if(current.left == null)
                {
                    System.Console.WriteLine(current.data); 
                    current = current.right;
                }
                else
                {
                    Node pre =  current.left;
                    while(pre.right != null && pre.right!=current)
                        pre = pre.right;
    
                    //pre = predessor of current node
    
                    if(pre.right==null) //make the link
                    {
                        pre.right = current ;
                        current = current.left;
                    }
                    else //Break the link
                    {
                        pre.right = null ;
                        System.Console.WriteLine(current.data);
                        current = current.right;
                    }
                }
            }
        }
    }

    internal class Node
    {
        public int data { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
        public override string ToString()
        {
            return data.ToString();
        }
    }
}


