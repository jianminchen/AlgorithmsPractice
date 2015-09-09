using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueChar
{
    class UniqueChar
    {
        static void Main(string[] args)
        {
            string test = "3455"; 

            Boolean out2 = isUniqueChars2(test); 

            if(out2)
                Console.WriteLine("Is unique"); 
            else 
                Console.WriteLine("Not unique");
        }

        public static Boolean isUniqueChars2(String str) {
            Boolean[] char_set = new Boolean[256];
            
            for (int i = 0; i < str.Length; i++) {

                int val = str[i];

                if (char_set[val]) return false;

                char_set[val] = true;
            }

            return true;
         }

        public static Boolean isUniqueChars2_SaveSpace(String str)
        {
            Boolean[] char_set = new Boolean[256];

            for (int i = 0; i < str.Length; i++)
            {

                int val = str[i];

                if (char_set[val]) return false;

                char_set[val] = true;
            }

            return true;
        }
    }
}
