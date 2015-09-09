using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedLinkedListToBalancedBST
{
    public class LNode
    {
        public LNode next;
        public int data;

        public LNode(int n)
        {
            this.data = n;
        }
        public static int countLNode(LNode header)
        {
            if (header == null)
                return 0;

            int count = 0;
            
            LNode temp = header;

            while (temp != null)
            {
                temp = temp.next;
                count++;
            }
            return count; 
        }

        public static void push(ref LNode head, int data)
        {
            LNode newNode = new LNode(data);
            newNode.next = head;
            head = newNode; 
        }

        public static void pushF(LNode head, int data)
        {
            LNode newNode = new LNode(data);
            newNode.next = head;
            head = newNode;
        }

        public static void printList(LNode node)
        {
            while (node != null)
            {
                System.Console.WriteLine(" "+node.data);
                node = node.next; 
            }
        }
    }

    public class TNode
    {
        TNode left;
        TNode right;
        public int data;

        public TNode(int data)
        {
            this.data = data;            
        }

        public static TNode listToTree(LNode header)
        {
            int n = LNode.countLNode(header);

            return listToTreeRecursiv(ref header, n); 
        }

        public static TNode listToTreeRecursiv(ref LNode header, int n)
        {
            //Base Case
            if (n <= 0)
                return null;            

            
            TNode left = listToTreeRecursiv(ref header,  n/2);

            TNode root = new TNode(header.data);
            root.left = left; 
            header = header.next;

            root.right  = listToTreeRecursiv(ref header, n - n / 2 - 1);            

            return root; 
        }

        public static TNode listToT(int[] array, int i, int n)
        {
            if (i > n)
                return null;

            TNode root = new TNode(array[i + (n - i) / 2]);
            root.left = listToT(array, i, i + (n - i) / 2-1);
            root.right = listToT(array, i + (n - i) / 2 + 1,n);
            return root; 
        }
        public static void preOrder(TNode node)
        {
            if (node == null)
                return;
            
            preOrder(node.left);
            Console.Write(" " + node.data);
            preOrder(node.right); 
        }
        
    }
    class SortedLinkedListToBalancedBST
    {
        static void Main(string[] args)
        {
            LNode head = null;
            
            LNode.push(ref head, 7);
            LNode.push(ref head, 6);
            LNode.push(ref head, 5);
            LNode.push(ref head, 4);
            LNode.push(ref head, 3);
            LNode.push(ref head, 2);
            LNode.push(ref head, 1);
            
            /*
            LNode.pushF( head, 7);
            LNode.pushF( head, 6);
            LNode.pushF( head, 5);
            LNode.pushF( head, 4);
            LNode.pushF( head, 3);
            LNode.pushF( head, 2);
            LNode.pushF( head, 1);
            */

            Console.WriteLine("Given Linked List");
           // LNode.printList(head);

           // TNode root = TNode.listToTree(head);

            Int32 [] array = { 1, 2, 3, 4, 5, 6, 7 };

            TNode root2 = TNode.listToT(array, 0,6); 

            Console.WriteLine("Preorder Traversal of constructed BST");
            TNode.preOrder(root2);
        }
    }
}
