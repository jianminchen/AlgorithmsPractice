using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoStringAreAnagramStrings
{
    class TwoStringAreAnagramStrings
    {
        Hashtable collection = new Hashtable();

        public static class testCases
        {
            public static string[] test = {"test","tset"};
            public static string[] testFail = { "test", "ts1et" }; 
        }
        
        static void Main(string[] args)
        {
            bool value = isAnagram(TwoStringAreAnagramStrings.testCases.test);
            bool failValue = isAnagram(TwoStringAreAnagramStrings.testCases.testFail);
            System.Console.WriteLine("result is " + value.ToString()); 
        }

        public static bool isAnagram(string[] test)
        {
            Hashtable tmp = new Hashtable();

            int count = 0; 
            foreach (string s in test)
            {
                if (count == 0)
                {
                    foreach (char c in s)
                    {
                        string key = c.ToString();
                        if (tmp.Contains(key))
                        {
                            int value = (int)tmp[key];
                            tmp[key] = value + 1;
                        }
                        else
                        {
                            tmp.Add(key, 1); 
                        }
                    }
                }

                if (count == 1)
                {
                    foreach (char c in s)
                    {
                        string key = c.ToString();

                        if (!tmp.Contains(key)) return false;
                        else
                        {
                            int value = (int)tmp[key];

                            if (value - 1 < 0) return false; 
                            tmp[key] = value - 1; 
                        }
                    }

                    // at the end, check tmp each value ==0
                    
                    foreach (DictionaryEntry entry in tmp)
                    {
                        int value = (int)entry.Value;

                        if (value > 0) return false; 
                        // redundant check
                        if (value < 0)
                        {
                            return false; // unreachable code 
                        }
                    }
                    return true; 
                }

                count++; 
            }
            return false; 
        }

    }
}
