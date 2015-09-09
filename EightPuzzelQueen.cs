using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightPuzzelQueen
{
    public class EightPuzzleQueen2
    {
        public static int SixQueen()
        {
            int[] columnIndex = new int[6] { 0, 1, 2, 3, 4, 5 };

            int count = 0;

            permutation(columnIndex, 6, 0, ref count);

            return count;
        }

        public static int EightQueen()
        {
            int[] columnIndex = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };

            int count = 0;

            permutation(columnIndex, 8, 0, ref count);

            return count; 
        }

        public static int TenQueen()
        {
            int[] columnIndex = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

            int count = 0;

            permutation(columnIndex, 10, 0, ref count);

            return count;
        }


        // using back track algorithm to check one by one, and go through all the cases
        public static void permutation(int[] columnIndex, int length, int index, ref int count)
        {
            int i, temp;

            // terminal case, go through the last row already
            if (index == length)
            {
                if (check(columnIndex, length) != 0)
                    count++;
            }
            else
            {
                for (i = index; i < length; ++i)
                {
                    // swap value at two columns, i and index
                    temp = columnIndex[i];
                    columnIndex[i] = columnIndex[index];
                    columnIndex[index] = temp;

                    permutation(columnIndex, length, index + 1, ref count); 
                    
                    // back track, and, swap value at two columns, i and index
                    temp = columnIndex[index];
                    columnIndex[index] = columnIndex[i];
                    columnIndex[i] = temp; 
                }
            }
        }
        
        // If there are two queens on the diagonal, it returns 0, otherwise it returns 1
        public static int check(int[] columnIndex, int length)
        {       
            // nxn comparison, 
            for(int i=0;i<length; i++)
                for (int j = i + 1; j < length; j++)
                {
                    if(((i+columnIndex[i])==(j+columnIndex[j]) || (columnIndex[i]-columnIndex[j])==(i-j)))
                        return 0; 
                }
            return 1; 
        }

        static void Main(string[] args)
        {

            int count = EightQueen();

            //int count10 = EightPuzzelQueen.EightPuzzleQueen2.TenQueen(); 

           // int count6 = EightPuzzelQueen.EightPuzzleQueen2.SixQueen(); 
        }
    }

    public class EightPuzzelQueen
    {
        
    }
}
