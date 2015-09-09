using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiOfTower2
{
    class HanoiOfTower2
    {
        private static List<int> peg1 = new List<int>();
        private static List<int> peg2 = new List<int>();
        private static List<int> peg3 = new List<int>();

        private static int TESTSIZE = 8; 
        static void Main(string[] args)
        {
            for (int i = 0; i < TESTSIZE; i++)
                peg1.Add(TESTSIZE - i);

            //peg1.RemoveAt(1); 
            //peg1.Add(9);
            //int j = 1; 

            move(7, peg1, peg2, peg3);

            int k = 2;
            k++; 

        }

        /**
         * Latest update: July 2, 2015 
         * Problem statement:
         * 
         * 
         */
        private static void move(int n, List<int> source, List<int> dest, List<int> tmp)
        {
            if (n == 0)
                moveOne(source, dest);
            else
            {
                move(n - 1, source, tmp, dest);
                if (source.Count > 1)
                {
                    System.Console.WriteLine("My algorithm is wrong"); 
                }
                moveOne(source, dest);
                move(n - 1, tmp, dest, source); 
            }
        }

        private static void moveOne( List<int> source, List<int> dest)
        {
            int size = source.Count;
            if (size > 0)
            {
                int value = source[size-1]; 
                source.RemoveAt(size-1);   // only remove from the end of the list

                // enforce the rule: the value added has to be smaller than the current ones
                int test = dest.Count;
                if (test> 0)
                {
                    if (dest[test - 1] < value)
                    {
                        System.Console.WriteLine("Something is wrong");
                        return;
                    }
                }
                dest.Add(value); 
            }            
        }
    }
}
