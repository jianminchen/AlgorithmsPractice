using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLevelOrderPrint
{
    class TreeLevelOrderPrint
    {
        /*
         * Julia's comment:
         * 
         * Please document the practice time, the problem statement, and the solution reference. 
         * 
         *
         */
        int SIZEOFTREE = 100; 
        public static int[] binaryTree = new int[100];

        // TO make it simple, assume all the node's value is bigger than 0, and then, user -1 to represent missing node; therefore, 
        // the binary tree can be represented in an array as a complete tree; 
        public class TestData
        {
            public static int[] tree = {1,2,3,4,-1,5,6};
        }

        private static List<int> queue = new List<int>();  // using an array to simulate a queue behavior
        // always remove from the head 
        // if the new line, add a sentence "new Line"
        private static string NEWLINE = "new line"; 

        private static ArrayList output = new ArrayList();
        private static ArrayList outputCountEachTreeLine = new ArrayList(); 

        static void Main(string[] args)
        {
            treeLevelOrderPrint();
            System.Console.WriteLine("Show the result"); 
        }

        /*
         * Julia's comment: 
         * 1. There are so many ideas to implement the level order traversal, so 
         * this solution is provided from the book: (?)
   
         *  2. work on the code, to make it better
         *  3. Try to do some timing, then, count how many minutes to implement the idea.  
         * 
         */
        public static void treeLevelOrderPrint()
        {
             
            int tree_index = 0;

            int countLine = 0;

            int previous = 0;
            int current = 0;
            int next = 0; 
            
            do
            {
                if (tree_index == 0)
                {
                    int rootNodeValue = TestData.tree[0];

                    queue.Add(rootNodeValue);

                    outputCountEachTreeLine.Add(1);
                    current = 1;
                    previous = 0; 
                    next = 0;                   

                }

               
                {
                    tree_index++; 
                    if (tree_index < TestData.tree.Length)      // simulate left node 
                    {
                        if (TestData.tree[tree_index] >= 0)     // ensure that the node is not missing 
                        {
                            queue.Add(TestData.tree[tree_index]);
                            next++;
                        }                       
                    }

                    tree_index++;
                    if (tree_index < TestData.tree.Length)      // simulate right node
                     {
                         if (TestData.tree[tree_index] >= 0)    // ensure that the node is not missing 
                         {
                             queue.Add(TestData.tree[tree_index]);
                             next++;
                         }                         
                     }
                    
                    output.Add(queue[0]);
                   
                    queue.RemoveAt(0);
                    current--;                     

                    if (current == 0)
                    {
                        // add a new line - simulate using add a negative number
                        output.Add(-1);
                        current = next;   
                    }               
                }
                
                //count++;

            } while (queue.Count>0 ); 
        }
    }
}
