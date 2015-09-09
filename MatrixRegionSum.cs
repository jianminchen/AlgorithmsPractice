using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixRegionSum
{
    class MatrixRegionSum
    {
        private static int SIZE_ROW = 200;
        private static int SIZE_COLUMN = 300;

        private static bool calculated = false; 
        private static int [][] sum = new int[SIZE_ROW][];

        public class testData
        {
            public static int[][] data = new int[SIZE_ROW][];

            public static void prepareData()
            {
                for (int i = 0; i < SIZE_ROW; i++)
                {
                    data[i] = new int[SIZE_COLUMN]; 
                }

                for(int i=0;i<SIZE_ROW;i++)
                    for (int j = 0; j < SIZE_COLUMN; j++)
                    {
                        Random no = new Random();
                        //data[i][j] = i + j + no.Next(0,100); // I may use the random number for testing
                        data[i][j] = 1; 
                    }
            }
        }

        /**
         * Matrix region sum 
         * Latest update: JUne 25, 2015
         * Problem statement:
         * This is a very elegant question which seems easy at first but requires some hard thinking to solve it efficiently: 
         * Given a matrix of integers and coordinates of a rectangular region within the matrix, find the sum of numbers 
         * falling inside the rectangle. Our program will be called multiple times with different rectangular regions from the 
         * same matrix. - See more at: 
         * http://www.ardendertat.com/2011/09/20/programming-interview-questions-2-matrix-region-sum/#sthash.J9f5QzBc.dpuf
         * blog: 
         * http://www.ardendertat.com/2011/09/20/programming-interview-questions-2-matrix-region-sum/
         * Action items:
         * 1. implement the simple one, 
         * O(m x n) algorithm: simple one 
         * 2. implment O(1) solution using cache 
         *    how many sum in the cache, instead of O(n^4), using O(n^2) (completed on 2013)
         *    
         * */


        static void Main(string[] args)
        {
            // prepare the memo using dynamic programming 
            prepareMemo(); 
            // get the value from precomputed memo - sum array

            if (checkInput(10, 10, 20, 20))
            {
                int matrixRegionSum = getValue(10, 10, 20, 20);
                System.Console.WriteLine("Output is " + Convert.ToString(matrixRegionSum));
            }            
        }
        
        public static bool checkInput(int top_row, int top_column, int bottom_row, int bottom_column)
        {
            if (top_row > bottom_row || top_column > bottom_column)
                return false;
            if (bottom_row >= SIZE_ROW || bottom_column >= SIZE_COLUMN)
                return false;

            if (top_row < 0 || top_column < 0 || bottom_row < 0 || bottom_column < 0)
                return false;
            return true; 
        }

        /**
         * Latest update: June 25, 2015
         * The region sum saved in cache is O(n x m), not O(n^2 X m^2); save space
         * Region sum S: 
         * AB
         * CD
         * In order to reduce the matrix saved in cache, use the formula to calculate D region sum:
         * 1. S1: get the whole sum: 
         *  AB
         *  CD
         * 2. S2: get AB
         * 3. S3: get 
         *        A
         *        C
         * 4. get S4: A
         * So, S= S1+S4 - S2 - S3
         */
        public static int getValue(int top_row, int top_column, int bottom_row, int bottom_column)
        {
            return sum[bottom_row][bottom_column]-sum[bottom_row][top_column]-sum[top_row][bottom_column]+sum[top_row][top_column];           
        }

        private static void prepareMemo()
        {
            // do it once, only once
            if (!calculated)
            {
                testData.prepareData();

                for (int i = 0; i < SIZE_ROW; i++)
                {
                    sum[i] = new int[SIZE_COLUMN];
                }

                for (int i = 0; i < SIZE_ROW; i++)
                    for (int j = 0; j < SIZE_COLUMN; j++)
                    {
                        if (i == 0)
                        {
                            if (j == 0)
                                sum[0][0] = testData.data[0][0];
                            else
                                sum[0][j] = sum[0][j - 1] + testData.data[0][j];
                        }
                        else if (j == 0)  // maybe I can combine top2 cases for clarity later
                        {
                            sum[i][0] = sum[i - 1][0] + testData.data[i][0];
                        }
                        else
                        {
                            // now it is safe to use j-1 or i-1
                            // use dynamic programming as possible 
                            sum[i][j] = sum[i][j - 1] + sum[i - 1][j] - sum[i - 1][j - 1] + testData.data[i][j]; 
                        }
                    }

                calculated = true; 
            }
        }
    }
}
