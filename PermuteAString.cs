using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermuteAString
{
    class PermuteAString
    {
        public static ArrayList output = new ArrayList(); 

        static void Main(string[] args)
        {
            string test = "ABCD";

            PermuteAString("", test);

            test.Substring(0,0); 
            int i=3; 
        }

        static void PermuteAString(string prefix, string toPermute)
        {
            if (toPermute.Length == 0)
            {
                output.Add(prefix);
                return;
            }

            char ch; 
            for(int i=0;i<toPermute.Length;i++)
            {
                ch=toPermute[i];
                int len = toPermute.Length; 

                string newString="";

                if (i == 0) newString = toPermute.Substring(i + 1);
                else if (i > 0)
                {
                    newString = toPermute.Substring(0, i) + toPermute.Substring(i + 1, len - i - 1);
                }

                PermuteAString(prefix+ch.ToString(), newString);
            }

        }
    }
}
