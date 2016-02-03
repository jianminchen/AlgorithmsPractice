using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCacheMissCount
{
    /*
     * code reference:
     * http://blog.csdn.net/lycorislqy/article/details/49218977
     * problem statement:
     * 
     * 
     * 
     * February 2, 2016
     * Java HashMap C# analog: Dictionary
     * http://stackoverflow.com/questions/687942/java-map-equivalent-in-c-sharp
     * 
     * Java List interface - C# analog
     * http://stackoverflow.com/questions/10115769/something-similar-to-c-sharp-net-generic-list-in-java
     * 
     * First use - Dictionary(int capacity) - Good practice!
     */
    public class LRUcache
    {

        static IDictionary<int, int> map;
        static LinkedList<int> list;
        int capacity;

        /*
         * C# double linked list - no capacity constructor 
         */
        public LRUcache(int capacity_val)
        {
            capacity = capacity_val;
            map = new Dictionary<int, int>(capacity);
            list = new LinkedList<int>();
        }

        private static void outputlist() 
        {
            string s = "[ "; 
            System.Console.Write("[ ");  

            for(int j=0; j < list.Count;j++)                
                s += list.ElementAt(j)+" ";              

            s +="]\n";

            System.Console.Write(s); 
        }

        /*
         * Java HashMap.Contains()
         * C# Dictionary.ContainsKey() - more expressive 
         * 
         * Java double linked list 
         * C# analog: 
         * LinkedList
         */
        private int set(int key, int i2)
        {            
            if (map.Count < capacity)
            {
                if (map.ContainsKey(key))
                {
                    map[key] = i2;
                    list.Remove(key);
                  //  list.AddBefore(key);  ? 
                }
                else
                {/*
                    map[key] = i2;
                    list.Add(key);
                  */
                }
            }
            else
            {  /*
                int lastkey = list[0];
                list.remove(0);
                map.remove(lastkey);

                list.add(key);
                map.put(key, i2);
                */
            }
            return key;
        }  
  



    }
    class Solution
    {
        static void Main(string[] args)
        {
        }

        public static void main(String[] args) {  
        // TODO Auto-generated method stub  
        int[] array = {4,3,4,2,3,1,4,2};  
        int max = 3;  
          
        LRUcache MemoA = new LRUcache(max);  
  
        for(int i = 0; i < array.Length; i++)  
        {  
            //MemoA.set(array[i], i);  
              
            //outputlist();  
        }  
        
            /*
        int findx = MemoA.get(4);  
        if(findx == -1)  
            System.out.println("Do not have now");  
        else  
        {  
            System.out.println("result is： "+findx);  
            outputlist();  
        }  
             * */
    }  
    }
}
