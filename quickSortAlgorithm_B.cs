using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quickSortAlgorithm_B
{
    /*
     * code reference:
     * https://shepherdyuan.wordpress.com/2014/08/03/sorting-algorithms/
     * 
     * blog: 
     * http://juliachencoding.blogspot.ca/2015/06/3-way-partition-problem-dutch-national.html
     * 
     * quick sort algorithm 
     */
    class Solution
    {
        static void Main(string[] args)
        {
            int[] A = { 1, 6, 2, 5, 4, 3 };

            quickSort(A, 0, 5);
        }

        /*
         * February 2, 2016
         * 
         * How to design this recurisve fucntion? 
         * Sort array using quick sort
         * 
         * Design tips and discussion:
         * 1. First, remember using recursive function, divide and conquer
         * 2. One array - for all the recursive function
         *    But each recursive will work on part of the array - left / right position
         * 3. Remember how to do 2-way partition - how to choose pivot - how to use pivot point value to divide 
         * into 2 partitions - left side - smaller values, right side - bigger values
         * 4. Partition - 
         *    two pointers - one pointer is to iterate whole array, except pivot point 
         *    second pointer - position of first node bigger than pivot value
         *    
         *   Actually, after the practice of February 2, 2016, Julia found out that two pointers can be designed much easy way:
         *   1. First pointer  - look for second partition part - right partition  - start position
         *   2. Second pointer - look for second partition part - right partition - end position 
         *   and also, in partition process, in-place swap is used. 
         *  
         *    Do not forget to swap second pointer value with pivot point value <- 
         * 5. Practice to write code using array - how to write code without a bug? 
         * 6. the output is stored in the input argument A[] 
         * 
         * Bug report: 
         * 1. still confuse the declaration: int[] A, not int A[] <- check C# 
         */
        public static void quickSort(int[] A, int left, int right)
        {
            if (left > right || left < 0 || right < 0) return;

            int index = partition(A, left, right);

            if (index != -1)
            {
                quickSort(A, left, index - 1);
                quickSort(A, index + 1, right);
            }
        }

        /*
         * February 2, 2016
         * 
         * Partition tips for design:
         * 1. use array int[] A to store the values
         * 2. choose pivot point smartly - use last value in the array here
         * 3. actually partition is to use two pointers, which are 2nd partition's start/ end position. 
         *    end position's pointer will iterate the array from start
         * 4. At last, put pivot point value between two partition, one swap 
         * 
         * Test case: 
         * int[] A = { 1, 6, 2, 5, 4, 3 };
         * Good thing about test case:
         * 1. one swap for partition for pivot point 3, one swap for put pivot value in-between
         *    6 and 2 swap
         *    6 and 3 swap 
         * 2. left partition 2 values, right partition 3 values. 
         */
        private static int partition(int[] A, int left, int right)
        {
            if (left > right) return -1;

            int p2Start = left;  // right partition - 2nd one's start position; 2nd one's end position will be right-1

            int pivot = A[right];    // choose last one to pivot, easy to code
            for (int i = left; i < right; i++)
            {
                if (A[i] < pivot)
                {
                    swap(A, i, p2Start);
                    p2Start++;
                }
            }

            swap(A, p2Start, right); // insert pivot point in two sections

            return p2Start;
        }

        private static void swap(int[] A, int left, int right)
        {
            int tmp = A[left];
            A[left] = A[right];
            A[right] = tmp;
        }
    }
}