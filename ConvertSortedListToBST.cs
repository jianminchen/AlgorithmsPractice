using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertSortedListToBST
{   
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
   
    public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
    }

    class ConvertSortedListToBST
    {
        /* study the sample code: http://codeganker.blogspot.ca/2014/04/convert-sorted-list-to-binary-search.html 
         Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.
         */
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
         //   head.next.next.next = new ListNode(4);
         //   head.next.next.next.next = new ListNode(5);
         //   head.next.next.next.next.next = new ListNode(6);
         //   head.next.next.next.next.next.next = new ListNode(7);

            TreeNode root = sortedListToBST(head); 
        }

        public static  TreeNode sortedListToBST(ListNode head)
        {
            if (head == null)
                return null;
            ListNode cur = head;
            int count = 0;
            while (cur != null)
            {
                cur = cur.next;
                count++;
            }

            return helper(head, 0, count - 1);
        }

        private static TreeNode helper(ListNode list, int l, int r)
        {
            if (l > r )
                return null;             

            int m = (l + r) / 2;

            TreeNode left = helper(list, l, m - 1);           

            TreeNode root = new TreeNode(list.val);
            root.left = left;
            list = list.next;            

            root.right = helper(list, m + 1, r);

            return root;
        }
    }   
}
