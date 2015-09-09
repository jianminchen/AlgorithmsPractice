using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isPlaindrome
{
    class isPlaindrome
    {
        static void Main(string[] args)
        {
            string test = "abcdcba";

            bool result = isPlainDrome(test); 
        }

        protected static bool isPlainDrome(string s)
        {
            if (s.Length <= 1) return true;

            return (s[0] == s[s.Length - 1]) && (isPlainDrome(s.Substring(1, s.Length - 2))); 
        }
    }
}
