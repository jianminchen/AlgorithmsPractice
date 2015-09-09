using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerOfN
{
    class PowerOfN
    {
        public class Memo
        {
            public const int SIZE = 1000;
            public static double[] memo;

            public static void initializeMemo()
            {
                if (memo == null)
                    memo = new double[SIZE];

                for (int i = 0; i < SIZE; i++)
                    memo[i] = 0;
            }
        }

        public static class MemoHashtable
        {
            public static Hashtable table = new Hashtable();
            public static int count =0; 
            public static void clear()
            {
                MemoHashtable.table.Clear();
                count = 0; 
                
            }
        }

        static void Main(string[] args)
        {
            double a = 2;
            int b = 10;
            try
            {
                Memo.initializeMemo();
                double result = powerOfNUsingMemoArray(a, b);
                // double result2 = powerOfNUsingIterative(a,b); 
                System.Console.WriteLine("result is " + result.ToString());

                // another test

                //Memo.initializeMemo();
                //powerOfNUsingMemo(a + 1, b + 1);
                a = 1.00001;
                b = 1024 * 1024;
                PowerOfN.MemoHashtable.clear();
                double result2 = powerOfNUsingMemoHashtable(a, b);
                System.Console.WriteLine("result is " + result2.ToString());

                // test it on June 10, 2015
                {
                    a = 2;
                    b = 10;
                    double result3 = pow_2(a, b);
                }

                {
                    a = 2;
                    b = -3;
                    double result4 = pow_2(a, b);
                }
            }
            catch
            {

            }
        }

        public static bool checkRange(double baseValue, int n)
        {
            // we have to figure out if the range is in the range of double
            // since double is using 8 bytes, 64bits, we need the help here
            // we do the work later. 

            // secondly, we need to check the b is inside of Memo.memo size
            if (n > Memo.SIZE) return false;
            return true;
        }

        /**
         * Consider float point of d, we may break a into a =n +  number not bigger than 0.5 = denoted as c
         * and consider (n+c) power of b, and see if we can make a better approach
         * In terms of calculation ... 
         * 
         */

        /**
         * Soltion D: First, save power(a,1), power(a,2), ...., power(a,max=powerofM) into Memo;
         * And lookup the array, and calculate power(a,b) 
         * Or what we have to do is to construct the formula for b in binary format 
         *    then, we can use bit operation to do some work as well
         *    
         */
        public static double powerOfNUsingIterative(double baseValue, int n)
        {
            if (baseValue == 0) return 0;
            if (n == 0) return 1;

            if (n < 0) return 1.0 / powerOfNUsingIterative(baseValue, -n); 

            // now b>0
            double value = 1; 
            for (int i = 0; i < n; i++)
            {
                value = value * baseValue; 
            }

            return value; 
        }

        /**
         * Test case:  1.00001 power of 100000, how many times multiplcation in interative method, 100000 times; recursive, less than 100 times. 
         */
        public static double powerOfNUsingMemoHashtable(double baseValue, int n)
        {
            if (baseValue == 0)
            {
                return 0;
            }
            if (n == 0)
            {
                if (!MemoHashtable.table.Contains(0))
                    MemoHashtable.table.Add(0,1);

                return 1;
            }

            if (n < 0) return 1.0 / powerOfNUsingMemoHashtable(baseValue, -n);

            if (n == 1)
            {
                if (!MemoHashtable.table.Contains(1))
                    MemoHashtable.table.Add(1, baseValue);

                return baseValue;
            }
            //if (b == 2) return b * b;  // not need
            double value;
            int n1 = n / 2;
            if (MemoHashtable.table.Contains(n1))
            {
                value = (double)MemoHashtable.table[n1];
                MemoHashtable.count++; 
            }
            else
            {
                value = powerOfNUsingMemoHashtable(baseValue, n / 2);
                if (!MemoHashtable.table.Contains(n / 2))
                    MemoHashtable.table.Add(n / 2, value);
            }

            if (n % 2 == 0)
            {
                return value * value;
            }
            else
            {
                return value * value * baseValue;
            }
        }


        /**
         * Solution C: Need to design the function to return double a power of b
         * idealy, we like to calculate as less as possible
         * For example, 2 power 13, 13 = 1+4+8, 4 calculation of power, 2, 4=2*2, 8=4*2
         *              2 power 29, 29 = 16+8+4+1, and we like to save the calculation of 16, 8, 4 in memo to avoid redundant calculation
         *              using recursively call 
         *              for the case b will be very large, like 10,000, and a is close to 1
         *              if we use recursive call, the stack will have problem. Then, we may use memo to reduce the call to log b instead of b times
         *              Test case: 1.00001 power of 10000  - using array is not a good choice; sparse array
         *              Try one using hashtable 
         *              
         */
        public static double powerOfNUsingMemoArray(double baseValue, int n)
        {
            if (baseValue == 0)
            {
                return 0;
            }
            if (n == 0)
            {
                if (Memo.memo[0] != 1)
                    Memo.memo[0] = 1;

                return 1;
            }

            if (n < 0) return 1.0 / powerOfNUsingMemoArray(baseValue, -n);

            if (n == 1)
            {
                if (Memo.memo[1] != baseValue)
                    Memo.memo[1] = baseValue;

                return baseValue;
            }
            //if (b == 2) return b * b;  // not need
            double value;
            if (Memo.memo[n / 2] != 0)
                value = Memo.memo[n / 2];
            else
            {
                value = powerOfNUsingMemoArray(baseValue, n / 2);
                Memo.memo[n / 2] = value;
            }

            if (n % 2 == 0)
            {
                return value * value;
            }
            else
            {
                return value * value * baseValue;
            }
        }

        /**
         * Solution B: 
         * using recursive function
         * assumption: n>=0 // added on 10/9/2013
         * 
         */
        public static double powerOfN(double baseValue, int n)
        {
            if (baseValue == 0) return 0;
            if (n == 0) return 1;   // definition of power: 
            if (n == 1) return baseValue;
            // if (b == 2) return b * b;

            if (n % 2 == 0)
            {
                double value = powerOfN(baseValue, n / 2);  // try to reach O(logn) complexity instead of O(n)   // added on 10/9/2013
                return value * value; 
            }
            else
            {
                double value = powerOfN(baseValue, n / 2);
                return value * value * baseValue;  
            }
        }

        /**
         * Soultion A: 
         */
        public static double pow(double x, int n)
        {
            if (x == 0)
            {
                if (n == 0) return 1;
                else
                    return 0; 
            }

            if (n == 0) return 1;

            bool pos = true;
            if (n < 0)
            {
                pos = false;
                n = Math.Abs(n); 
            }

            double np = x;
            double res = 1;

            // using while, it is hard to figure out 
            // n = 7, res = x, n=3-> 
            while (n > 0)      
            {
                if (n % 2 == 1)
                {
                    res = res * np; 
                }
                np = np * np;
                n = n / 2;
            }
            

            // using for loop to understand better, but 7 is skipped 
            // i values: 1, 2, 4, 8, 16, 32, 
            /*
            for (int i = 1; i <= n; i = i * 2)  
            {
                res = res * np;
                np = np * np; 
            }
            if (n % 2 == 1)
                res = res * np; 
            */
            return pos ? res : 1 / res; 
        }

        /*
         * Latest update: June 10, 2015
         * Great idea to put math together, clear, correct; test it online by Leetcode 
         * This is a simple question, however the format is very important 
            x^n={
                 x^n= 1.0                  if n==0,
                 x^(n/2)* x^(n/2)          if n!=0 and n is even,
                 x^|n/2| * x^|n/2| * x     if n>0 and n is odd,
                 x^|n/2| * x^|n/2| * x^-1  if n<0 and n is odd,
            }
            Once it got this formula, then, the code become relatively easy.
 
            the time complexity is O(lgn)     hint: (half=pow(x,n/2))
         * http://rleetcode.blogspot.ca/2014/02/powx-n-java.html
         * */
        public static double pow_2(double x, int n)
        {

            // Start typing your C/C++ solution below

            // DO NOT write int main() function

            // n is even , then x^n=x^n/2*x^n/2

            //  n>0 and n is odd, x^n=x^n/2 * x^n/2 *x

            // n<0 and n is odd, x^n=x^n/2 *x^n/2 *x^-1

            if (x == 0) return 0; // add/miss this line of code, both will pass online judge

            if (n == 0)
            {

                return 1.0;

            }

            double half = pow_2(x, n / 2);

            if (n % 2 == 0)
            {

                return half * half;
            }

            else if (n > 0)
            {

                return half * half * x;
            }

            else
            {

                return half * half * (1 / x);
            }
        }
    }
}