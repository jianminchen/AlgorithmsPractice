using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoOddIntegers
{
    class TwoOddIntegers
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 1, 2, 2, 3, 3, 4, 5 };

            int x = 0, y = 0;

            twoOddInteger(arr, ref x, ref y);

            Console.WriteLine("x value is " + x);
            Console.WriteLine("y value is " + y);
            Console.WriteLine("y value is " + y);
        }

        static void twoOddInteger(int[] arr, ref int x, ref int y)
        {

            int xor = arr[0];

            x = y = 0;

            int xor_bit_1 = 0;

            // XOR all the integers in the array
            for (int i = 1; i < arr.Length; i++)
                xor = xor ^ arr[i];

            // Find rightmost bit is 1 
            // For example, x=6 (0110) and y = 15(1111), 
            // 6^15 = 0110, first bit is 1 - rightmost - 10 
           
            // bitwise complement - go through example
            // 0110 - x0r-1 = 0101 ->~ ...1010 -> & operator 
            int reverse = ~(xor - 1);   
            xor_bit_1 = xor & reverse;            

            for (int i = 0; i < arr.Length; i++)
            {
                if ((arr[i] & xor_bit_1) > 0)
                    x = x ^ arr[i];
                else
                    y = y ^ arr[i];
            }
        }
    }
}
