using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace longestSubstringPalindrome
{
    class longestSubstringPalindrome
    {
        /*
         * Problem statement: 
         * Solution thought process:
         * Research about the solutions online:
         * How many minutes need to understand the implementation? 
         * The practice is not very efficient, if the solution is not optimal; 
         * no discussion of ideas, and thought process etc. - Spet. 9, 2015 
         */
         public static string longestSubstringPalindrome(string s)
        {
            if(s==null)
                return s;

            if (s.Length <= 1)  // str len is 0, 1
                return s;
            int n = s.Length;
            
            int maxLength =1; 
            string maxStr = null;

            int[,] table = new int[n,n];  // C# learn how to declare two dimension array
            
            // length = 1 
            for (int i = 0; i < n; i++)            
                table[i,i] = 1;
           
            //length =2 
            for (int i = 0; i < n-1; i++)
            {
                table[i, i + 1] = 0;

                if (s[i] == s[i + 1])
                {
                    table[i, i + 1] = 1;
                    maxStr = s.Substring(i, 2);
                    maxLength = 2; 
                }              
            }

            //length>=3
            // O(nxn) time
            for(int k=3;k<=n;k++)   // k starting from 3, and maximum length = n; Range of length
                for (int i = 0; i < n-k+1; i++)   // make sure that last node will be in the boundary
                {
                    int firstNode = i;
                    int lastNode = i + k - 1;  // lastNode > firstNode since k>2; 

                  //  if (lastNode >= n)  // but lastNode should less than n, avoid code crash
                  //      break;  // the code is not optimal, it is better to cut the size

                    int secondNode = firstNode + 1; // boundarycheck, i<n-1; so secondNode<n, good; will not crash
                    int secondLastNode = lastNode - 1; // boundary check, k>2; so i+k-2>=1

                    table[firstNode, lastNode] = 0; 
                    if (s[firstNode] == s[lastNode] && table[secondNode, secondLastNode] == 1)
                    {
                        if (k > maxLength)
                            maxLength = k;

                        maxStr = s.Substring(i, k);
                        table[firstNode, lastNode] = 1;
                    }                       
                }
          
                return (maxLength>=2?maxStr:s.Substring(0,1)); 
        }

         static void Main(string[] args)
        {
            string testStr = "dabcba";
            string testStr2 = "abcdef";

            //string output = longestSubstringPalindrome(testStr);
            string output = simpleWayGetPalindrome_BetterCode(testStr);

            string anotherOutput = simpleWayGetPalindrome(testStr); 
        }

         public static string simpleWayGetPalindrome(string s)
         {
             if (s == null)
                 return s;

             if (s.Length <= 1)
                 return s;

             string maxReturn = s.Substring(0, 1);

             // time O(nxn) space O(n)
             for (int i = 0; i < s.Length; i++)
             {
                 // if i is center of the palindrome
                 // simple case: aba 
                 // start node: k = 0, comparing with i+(i-1), if 2i-1<length
                 // in other words, min (i-0, s.length-i); 
                 // other direction, from center to outward, i-1, i+1, and then continue
                 // stop when it is not equal 
                 // if i-1>0 and i+1 < s.length, and s[i-1]== s[i+1] 
                 // maxReturn = s.substring[i-1, 3]
                 // make it a loop: k=1, and increment by 1 
                 int k = 1;
                 while (i - k >= 0 && i + k < s.Length && s[i - k] == s[i + k])
                 {
                     int len = 1+2*k; 
                     if(maxReturn.Length < len)
                     {
                        maxReturn = s.Substring(i-k, len); 
                     }
                     k++; 
                 }

                 // if i and i+1 is center of the palindrome
                 // simple case: abba
                 // abba
                 // start from center, outward
                 // i, i+1 are center, so we compare i-1, i+2 if they are in the range, check if they are equal
                 // continue, if it is. 
                 if ((i + 1) < s.Length && s[i] == s[i + 1])
                 {
                     int offset = 1;
                     while ((i - offset) > 0 && (i + 1 + offset) < s.Length && s[i - offset] == s[i + 1 + offset])
                     {
                         int len = 2 + 2 * offset;
                         if (maxReturn.Length < len)
                         {
                             maxReturn = s.Substring(i-offset, len);
                         }
                         offset++;
                     }
                 }
             }

             return maxReturn; 
         }

        // 2:00pm - 3:00pm 
         public static string simpleWayGetPalindrome_BetterCode(string s)
         {
             if (s == null)
                 return s;

             if (s.Length <= 1)
                 return s;

             string maxReturn = s.Substring(0, 1);

             // time O(nxn) space O(n)
             for (int i = 0; i < s.Length; i++)
             {
                 string tmp = palindrome(s, i, i);
                 if (tmp.Length > maxReturn.Length)
                     maxReturn = tmp; 

                 // if i and i+1 is center of the palindrome
                 string tmp2 = palindrome(s, i, i + 1);
                 if (tmp.Length > maxReturn.Length)
                     maxReturn = tmp;                  
             }

             return maxReturn;
         }
         
         // assume end>=start
         // high priority check first, and then, boundary check, and then, complete the checking; 
         // but the code may crash, so the order has to be adjusted. 
         // from center to outward, two pointers
         public static string palindrome(string s, int start, int end)
         {             
             while (start >= 0 && end < s.Length && s[start]==s[end])  
             {                
                 start--;
                 end++; 
             }
           
             return s.Substring(start-1, end-start+1);  // test case: s="a", palindrome(s,0,0)
         }
    }
}
