using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convertSortedListToBST_Blog
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    class convertSortedListToBST_Blog
    {
        /**
         * Leetcode:  singly linked list to a height balanced BST
         * 
         * study the sample code: http://codeganker.blogspot.ca/2014/04/convert-sorted-list-to-binary-search.html 
         Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.
         */
        static void Main(string[] args)
        {
            /**
             * Latest update: April 15, 2015 
             * test case: list 1->2->3->4->5->6->7
             * output, BST: 
             *    4
             *  2   6
             * 1 3 5 7 
             * 
             * The code is ok, and passes leetcode online judge
             */
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(4);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(6);
            head.next.next.next.next.next.next = new ListNode(7);

            TreeNode root = sortedListToBST(head);  
           
            /**
             * Latest update: April 15, 2015
             * Took me 3 hours to figure out what the bug is. Find my weakness, ha..ha..haa..!
             * Test case: 1->2->3
             * result: BST
             *   1
             * 1   2
             */
            ListNode head2 = new ListNode(1);
            head2.next = new ListNode(2);
            head2.next.next = new ListNode(3);
            TreeNode rootBug = sortedListToBST_Bug(head2); 
        }

        public static ListNode global;
        public static TreeNode sortedListToBST(ListNode head)
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
            global = head;
            return helper(0, count - 1);
        }

        private static TreeNode helper(int l, int r)
        {
            if (l > r)
                return null;
            int m = (l + r) / 2;

            TreeNode left = helper(l, m - 1);
            TreeNode root = new TreeNode(global.val);
            root.left = left;

            // create second variable, do not change list itself.
            global = global.next;
            root.right = helper(m + 1, r);
            return root;
        }

        public static TreeNode sortedListToBST_Bug(ListNode head)
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
            return helper_bug(head, 0, count - 1);
        }
        private static TreeNode helper_bug(ListNode list, int l, int r)
        {
            if (l > r)
                return null;
            int m = (l + r) / 2;
            TreeNode left = helper_bug(list, l, m - 1);
            TreeNode root = new TreeNode(list.val);
            root.left = left;
            list = list.next;
            root.right = helper_bug(list, m + 1, r);
            return root;
        }
    }    
}
