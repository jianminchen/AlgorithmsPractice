using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerOfN_blog
{
    class PowerOfN_blog
    {
        static void Main(string[] args)
        {
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
            if (x == 0) return 0; // Julia comment: add/miss this line of code, both will pass online judge

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

        /**
         * Recursive solution:
         * Best solution
         */
        public double pow(double x, int n)
        {
            if (x == 0)
                return 0;
            return power(x, n);
        }

        private double power(double x, int n)
        {
            if (n == 0)
                return 1;
            double left = power(x, n / 2);
            if (n % 2 == 0)
            {
                return left * left;
            }
            else if (n < 0)
            {
                return left * left / x;
            }
            else
            {
                return left * left * x;
            }
        }

        /**
         *  Naive solution:
         *  Naive solution - time complexity O(NxN)
         *  http://www.programcreek.com/2012/12/leetcode-powx-n/
         */        
        public double pow_naive(double x, int n) {
            if(x == 0) return 0;
            if(n == 0) return 1;

            double result=1;
            for(int i=1; i<=n; i++){
                result = result * x;
            }

            return result;
        }

    }
}
