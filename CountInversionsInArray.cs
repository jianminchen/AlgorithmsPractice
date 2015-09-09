using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountInversionsInArray
{
    class CountInversionsInArray
    {
        /* O(nxn), and it is not optimal; but it works */
        public static int getInvCount(int[] arr, int n)
        {
            int inv_count = 0;
            int i, j;

            for (i = 0; i < n - 1; i++)
                for (j = i + 1; j < n; j++)
                    if (arr[i] > arr[j])
                        inv_count++;

            return inv_count; 
        }


        static void Main(string[] args)
        {
            int[] arr = new int[5]{1,20,6,4,5};
            int result = getInvCount(arr, 5); 
            return; 
        }

        public static int mergeSort(int[] arr, int array_size)
        {
            int[] tmp = new int[array_size];

            return mergeSortJulia(arr, tmp, 0, array_size - 1); 
        }

        /* An auxiliary recursive function that sorts the input array and returns the number of inversions in the array. 
         */
        public static int mergeSortJulia(int[] arr, int[] temp, int start, int end)
        {
            int mid, inv_count = 0;

            if (end > start)
            {
                /*Divide the array into two parts and call 
                 _mergeSortAndCountInv() for each of the parts
                 */
                mid = (start + end) / 2;

                inv_count = mergeSortJulia(arr, temp, start, mid);
                inv_count += mergeSortJulia(arr, temp, mid + 1, end); 

                /*merge the two parts*/
                inv_count += merge(arr, temp, start, mid+1, end); 


            }

            return inv_count; 
        }

        /* This function merges two sorted arrays and returns inversion count in the arrays */
        public static int merge(int[] arr, int[] temp, int left, int mid, int right)
        {
            int i, j, k;
            int inv_count = 0;

            i = left; /* i is index for left subarray*/
            j = mid;  /* j is index for right subarray */
            k = left; /* k is index for resultant merged subarray */
            while((i<=mid-1) && (j<=right))
            {
                if(arr[i]<=arr[j])
                {
                    temp[k++] = arr[i++];
                }
                else{
                    temp[k++] = arr[j++];

                    inv_count += mid - i; 
                }
            }
    
            /* copy the remaining elements of left subarray 
             * (if there are any) to temp
             */
            while (i <= mid - 1)
                temp[k++] = arr[i++];

            /*  copy the remaining elements of righ subarray 
             *  (if there are any) to temp
             */
            while (j <= right)
                temp[k++] = arr[j++]; 

            /* copy back the merged elements to original array
             */
            for (i = left; i <= right; i++)
                arr[i] = temp[i];

            return inv_count; 
        }
    }
}
