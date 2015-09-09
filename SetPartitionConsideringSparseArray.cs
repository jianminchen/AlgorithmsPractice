using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetPartitionConsideringSparseArray
{
    class SetPartitionConsideringSparseArray
    {
        public static int SETSIZE = 200;   // maximum set we can handle, 200, so that the amount of space O(200x200)
        public static int[][] result = new int[SETSIZE + 1][];

        public static int[][] pValue = new int[SETSIZE + 1][];

        /*
         * Sept. 5, 2015 
         * 
         * Problem statement:
         * Analysis:
         * 
         * How to understand the code? 
         * Thought process? 
         * Simple test case to go over? 
         * Warm up process: how to give user a clear idea what to solve in the function? 
         * When practising the code, try to provide a list of references, so it is easy to evaluate
         * the idea is great, and implementation is also ok. 
         * 
         * time complexity, space complexity: 
         * 
         * code is too long? Need improvement? 
         */

        static void Main(string[] args)
        {
            int[] test = { 1, 1, 5, 2, 3, 10, 9, 8 };
            int[] testGood2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int[] testGood3 = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            int[] testGood1 = { 1, 1, 5, 2 };

            SETSIZE = test.Length;

            // partition the set so that two sets are minimally different value; 
            int sum = 0;

            foreach (int i in test)
                sum += i;

            int target = sum / 2 + 1;

            int arraySize_J = target + 1;

            for (int i = 0; i < SETSIZE + 1; i++)
            {
                result[i] = new int[arraySize_J];
                pValue[i] = new int[arraySize_J];
            }

            for (int i = 0; i < SETSIZE + 1; i++)
            {
                pValue[i][0] = 1;
            }

            for (int i = 0; i < arraySize_J; i++)
                pValue[0][i] = 0;

            pValue[0][0] = 1;

            for (int i = 1; i < SETSIZE + 1; i++)
                for (int j = 1; j < arraySize_J; j++)
                {
                    pValue[i][j] = 0;

                    if (pValue[i - 1][j] > 0) pValue[i][j] = 1;

                    if (i >= 1)
                        if (j - test[i - 1] >= 0) pValue[i][j] = pValue[i - 1][j - test[i - 1]];
                }

            int k = 0;

            int SumBestPartition = 0;
            int indexSet = 0;
            bool foundOne = false;
            // need to tell the value of S, and then, know how to choose the first set
            ArrayList firstSet = new ArrayList();

            for (int i = 1; i <= SETSIZE; i++)
            {
                for (int j = 1; j <= arraySize_J; j++)
                {
                    if (pValue[SETSIZE + 1 - i][arraySize_J - j] == 1)
                    {
                        SumBestPartition = arraySize_J - j;
                        indexSet = SETSIZE + 1 - i;
                        firstSet.Add(test[indexSet - 1]);    // first node  
                        foundOne = true;
                        break;
                    }
                }
                if (foundOne)
                    break;
            }

            // and then choose the first set
            int test2 = SumBestPartition;

            bool setIsComplete = false;

            int currentPartition = SumBestPartition - test[indexSet - 1];

            SumBestPartition -= test[indexSet - 1];

            // find next point and then add into the set
            do
            {
                for (int i = 1; i < indexSet; i++)
                {
                    if (pValue[i][currentPartition] == 1)
                    {
                        firstSet.Add(test[i - 1]);
                        currentPartition -= test[i - 1];
                        indexSet = i;
                        break;
                    }
                }

            } while (currentPartition > 0);


            int checkFirstSet = 1;
        }
    }
}
