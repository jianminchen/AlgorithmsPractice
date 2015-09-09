using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetPartition
{
    class SetPartition
    {
        public static int MAXSETSIZE = 200;   // maximum set we can handle, 200, so that the amount of space O(200x200)
        public static int[][] result = new int[MAXSETSIZE + 1][];

        public static int[][] pValue = new int[MAXSETSIZE + 1][];

        public static class TestInput
        {
            public static int[] testOK = { 1, 1, 5, 2, 3, 10, 9, 8 };
            public static int[] testGood2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            public static int[] testGood1 = { 1, 1, 5, 2 };

            public static int[] test = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        }
        
        /*
         * Problem statement: 
         * Reference: 
         * 
         * Julia's comment: 
         * 
         */
        static void Main(string[] args)
        {
            int[] test = SetPartition.TestInput.test;
            int solutionSpace_SetSize = test.Length;

            // partition the set so that two sets are minimally different value; 
            int solutionSpace_SumOfSet = 0;

            foreach (int i in test)
                solutionSpace_SumOfSet += i;

            int target = (solutionSpace_SumOfSet+1) / 2 ;

            int targetValue = target;

            for (int i = 0; i < solutionSpace_SetSize + 1; i++)
            {
                result[i] = new int[targetValue];
                pValue[i] = new int[targetValue];
            }

            for (int i = 0; i < solutionSpace_SetSize + 1; i++)
            {
                pValue[i][0] = 1;   // empty set alway available, which value is zero
            }

            for (int i = 0; i < targetValue; i++)
                pValue[0][i] = 0;  // empty set, the value of sum is zero as well 

            pValue[0][0] = 1;  // not sure

            // go through the solution space - value first, and then subset; come out formula to reduce exponential solution to polynomial solution
            // build matrix from left to right, top to bottom; value from 1 to target, and set from 1 to whole set
            // think about if the last item in the set is in or not: contain a subset with value of j; (equal, not less than etc.)
            // if it is in, then, pValue[i-1][j-test[i-1]] = 1; in other words, "first i-1 elements a subset contains a subset with value of j-test[i-1]" - true
            // if it is not in, then pValue[i-1][j]=1 is true
            // think about array exception, and then add addtional checking using if statement
            for (int i = 1; i < solutionSpace_SetSize + 1; i++)
                for (int j = 1; j < targetValue; j++)
                {
                    pValue[i][j] = 0;

                    if (pValue[i - 1][j] > 0) pValue[i][j] = 1;

                    if (i >= 1)
                        if (j - test[i - 1] >= 0) pValue[i][j] = pValue[i - 1][j - test[i - 1]];
                }

            int k = 0;   // good place to place breakpoint here 

            // Now, work on the selection of subset process, take the last elment in - choose large set 
            int SumBestPartition = 0;
            int indexSet = 0;
            bool foundOne = false;

           
            // need to tell the value of S, and then, know how to choose the first set
            ArrayList firstSet = new ArrayList();

            for (int j = 1; j <= targetValue; j++)            
            {
                for (int i = 1; i <= solutionSpace_SetSize; i++)
                {
                    if (pValue[solutionSpace_SetSize + 1 - i][targetValue - j] == 1)
                    {
                        SumBestPartition = targetValue - j;
                        indexSet = solutionSpace_SetSize + 1 - i;
                        firstSet.Add(test[indexSet-1]);    // first node  

                        foundOne = true;
                        break;   // only break one for loop - need extra work from bool value foundOne 
                    }
                }
                if (foundOne)
                    break;
            }

            // and then choose the first set
            int test2 = SumBestPartition;            

            bool setIsComplete = false;   // breakpoint to check if the set is found successfully 

            int  currentPartition = SumBestPartition - test[indexSet-1];
            
            SumBestPartition -= test[indexSet-1]; 

            // find next point and then add into the set
            do{                
                for(int i=1;i<indexSet;i++)  // from top to down, pick the first one; otherwise, it will not be ok
                    {
                        if(pValue[i][currentPartition]==1)
                        {
                            firstSet.Add(test[i-1]); 
                            currentPartition -= test[i-1]; 
                            indexSet = i; 
                            break; 
                        }
                    }
                
            } while (currentPartition>0); 
            
            int checkFirstSet = 1;   // put breakpoint, test firstSet is making any sense. 
        }
    }    
}

