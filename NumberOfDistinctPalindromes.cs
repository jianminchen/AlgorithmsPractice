using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfDistinctPalindromes
{
    /********************************************
     * 
    (January 28, 2016)
     Problem statement: 
     Write a function to return count of total distinct palindrome substrings. 
     * 
    Come back to write down ideas:
    1. First of all, do not count duplicate.
    2. Brute force solution:
 any substring of O(N^2) substrings to see if it is a palindrome;
 Add the substring of palindrome to a hashset if it is not in the hashset.
  And return the length of hashset
    3. Use recursive solution - using subproblem to solve. Cannot filter out duplicate - not good
    4. Better solution - use center point of string - 2n + 1, and then, go over each one, add all palindromes substring.

  Requirement: write a C# code in 10 minutes for the solution, using brute force one.

    */
    class Solution
    {
        static void Main(string[] args)
        {           
            int count = numberOfDisinctPalindrome("aba");      //  result  is 3
            int test2 = numberOfDisinctPalindrome("ababa");    //  result  is 5 
        }

        public static int numberOfDisinctPalindrome(string s)
        {
            if (s == null || s.Length == 0)
                return 0; 

            // store key - substring - 
            int len = s.Length; 
            HashSet<string> myset = new HashSet<string>(); 
            for(int i=0;i<len;i++)
                for (int j = i; j < len; j++)
                { 
                    string tmpS = s.Substring(i, j-i+1);   

                    if(isPalindrome(tmpS))
                    {
                        if(!myset.Contains(tmpS))
                            myset.Add(tmpS); 
                    }
                }

            return myset.Count; 
        }
        

        /*
         * Julia - make code short
         */
        public static bool isPalindrome(string s)
        {
            if (s == null || s.Length == 0)
                return true;            
            
            for (int i = 0; i < s.Length/2 ; i++)
            {                
                if (s[i] != s[s.Length - 1 -  i ])                     
                    return false;                
            }

            return true; 
        }

        /*
         * Julia's comment: 
         * 1. count variable's scope is larger than necessary
         * 2. for loop is not full used. 
         */
        [Obsolete]
        public static bool isPalindromeFirst(string s)
        {
            if (s == null || s.Length == 0)
                return true;

            int count = 0;
            int len = s.Length;
            for (; ; )
            {
                if (count <= len / 2)
                {
                    if (s[count] == s[s.Length - count - 1])   // bug 01: -1, out-of-range error
                        count++;
                    else
                        return false;
                }
                else
                    return true;
            }
        }
    }
}
