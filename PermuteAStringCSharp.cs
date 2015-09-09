using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermuteAStringCSharp
{
    class PermuteAStringCSharp
    {
        static void Main(string[] args)
        {
            char[] test = new char[3] {'A','B','C'};

            PermuteAStringCSharp.permuteAString(ref test, 0, 2);
        }

        static void swap(ref char a, ref char b )
        {
            char temp = a;

            a = b;
            b= temp;
        }
        static void permuteAString(ref char[] inputStr, int i, int n)
        {
            if (i == n)
            {
                System.Console.WriteLine(" output: " + new string(inputStr));
                
            }
            else
            {

                for (int count = i; count <= n; count++)
                {
                    swap(ref inputStr[i], ref inputStr[count]);

                    permuteAString(ref inputStr, i + 1, n);

                    swap(ref inputStr[i], ref inputStr[count]);
                }
            }
        }
    }
}
