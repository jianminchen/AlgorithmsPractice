using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeTwoSortedSinglyLinkedList
{
    /*
     * February 2, 2016 
     * Problem statement:
     * You have two singly linked lists that are already sorted, you have to merge them and 
     * return a the head of the new list without creating any new extra nodes. The returned 
     * list should be sorted as well
     * 
     * code reference: 
     * http://stackoverflow.com/questions/10707352/interview-merging-two-sorted-singly-linked-list
     * 
     * other reference: 
     * 1. http://juliachencoding.blogspot.ca/2016/01/sunday-algorithm-day-i.html
     * 
     * 2. http://www.geeksforgeeks.org/merge-two-sorted-linked-lists/
     * 
     */

    public class Node
    {
        public int value;

        public Node next;

        public Node(int v)
        {
            value = v; 
        }
    }

    class Solution 
    {
        static void Main(string[] args)
        {
            Node l1         = new Node(1);
            l1.next         = new Node(3);
            l1.next.next    = new Node(5); 

            Node l2 =  new Node(2); 
            l2.next         = new Node(4); 
            l2.next.next    = new Node(6);

            Node newList = MergeLists(l1, l2); 

        }

        /*
         * February 2, 2015
         * 
         * code reference:
         *  http://stackoverflow.com/questions/10707352/interview-merging-two-sorted-singly-linked-list
         * 
         * Try to use recursive function, easy and quickly, and bug free. 
         * two singly linked lists that are already sorted, assuming that 
         * sorting is ascending order 
         * 
         * Julia's analysis:
         * 1. Bug001: 
         * You have to make sure that function will not generate null exception;
         * 2. Assuming that two lists are sorted in ascending order; 
         * 3. Do not create any new extra node. 
         * 
         * Talk about recursive function design tips:
         * 1. First, check base cases - do not bring into null exception: list1.value 
         * 2. Divide and conquer, or only do the work for first node, and then, use recursive calls. 
         */
        public static Node MergeLists(Node list1, Node list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;

            if (list1.value <= list2.value)
            {
                list1.next = MergeLists(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeLists(list1, list2.next);
                return list2; 
            }
        }
    }
}
