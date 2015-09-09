using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSearch
{
    public class GraphNode
    {
        public int val;
        public GraphNode next;
        public GraphNode[] neighbors;
        public Boolean visited;

        public GraphNode(int n)
        {
            val = n;
        }

        public GraphNode(int x, GraphNode[] n)
        {
            val = x;
            neighbors = n; 
        }

        public string toString()
        {
            return "value" + val.ToString(); 
        }
    }

    public class Queue
    {
        public GraphNode first, last;

        public void enqueue(GraphNode n)
        {
            if (first == null)
            {
                first = n;
                last = first;
            }
            else
            {
                last.next = n;

                last = last.next; 
                //last = n; 
            }
        }

        public GraphNode dequeue()
        {
            if (first == null)
                return null;

            //GraphNode returnNode = first;  ?
            GraphNode returnNode = new GraphNode(first.val, first.neighbors); 
            first = first.next;

            return returnNode; 
        }
    }

    class GraphSearch
    {
        //http://www.programcreek.com/2012/12/leetcode-clone-graph-java/ 

        static void Main(string[] args)
        {
            GraphNode n1 = new GraphNode(1);
            GraphNode n2 = new GraphNode(2);
            GraphNode n3 = new GraphNode(3);
            GraphNode n4 = new GraphNode(4);
            GraphNode n5 = new GraphNode(5);
            GraphNode n6 = new GraphNode(6);
            GraphNode n7 = new GraphNode(7);
            GraphNode n8 = new GraphNode(8);
            GraphNode n9 = new GraphNode(9);             

            n1.neighbors = new GraphNode[3] { n2, n3, n5};
            n2.neighbors = new GraphNode[2] { n1, n4};
            n3.neighbors = new GraphNode[3] { n1, n4, n5};
            n4.neighbors = new GraphNode[5] { n2, n3, n5, n6, n7};
            n5.neighbors = new GraphNode[3] { n1, n3, n4};
            n6.neighbors = new GraphNode[1] { n4 }; 
            n7.neighbors = new GraphNode[2] {n4, n8}; 
            n8.neighbors = new GraphNode[1] {n7}; 
            
            breathFirstSearch(n1, 8); 
        }

        public static void breathFirstSearch(GraphNode root, int x)
        {
            if(root.val == x) 
            {
                System.Console.WriteLine("find in root");
                return; 
            }

            Queue queue = new Queue(); 
            root.visited = true; 
            queue.enqueue(root); 

            while(queue.first!=null){

                GraphNode c = (GraphNode) queue.dequeue(); 

                foreach(GraphNode n in c.neighbors)
                {
                    if(!n.visited){
                        System.Console.WriteLine(n.val +" ");
                        n.visited = true; 

                        if(n.val == x)
                        {
                            System.Console.Write("Find "+n.val); 
                            return; 
                        }

                        queue.enqueue(n); 
                    }
                }
            }
        }
    }
}
