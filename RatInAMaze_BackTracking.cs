using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatInAMaze_BackTracking
{
    /*
     * naive algorithm 
     * the naive algorithm is to generate all paths from source to destination and one by one check if the generated path satisfies the constraints. 
     * 
     * while there are untried paths{
     * generate the next path
     *  if this path has all blocks as 1
     *  {
     *      print this path; 
     *  }
     * }
     * 
     * backtracking algorithm
     * 
     * if destination is reached
     *   print the solution matrix
     * else
     *   a) Mark current cell in solution matrix as 1. 
     *   b) Move forward in horizontal direction and recursively check if this move leads to a solution. 
     *   c) If the move chosen in the above step doesn't lead to a solution then move down and check if this move leads to a solution. 
     *   d) If none of the above solutions work then unmark this cell as 0 (BACKTRACK) and return false. 
     */
    public class RatInAMaze_BackTracking
    {
        public const int N = 4; 
        /*A utility function to print solution matrix sol[N][N]*/
        public static void printSolution(int[,] sol)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {                    
                    System.Console.Write(sol[i, j] + " "); 
                }
                System.Console.Write("\n"); 
            }
        }

        // a utility function to check if x, y is valid index for N*N maze

        public static bool isSafe(int[,] maze, int x, int y)
        {
            //if(x,y outside maze) return false
            if (x >= 0 && x < N && y >= 0 && y < N && maze[x, y] == 1)
                return true; 
            return false; 
        }

        /* this function solves the Maze problem using Backtracking. It mainly uses solveMazeUtil() to solve the problem. It returns false if no path is possible, otherwise return true and prints the path in the form of 1s. Please note that there may be more than one solutions, this function prints one of the feasible solutions. 
         */
        public static bool solveMaze(int[,] maze)
        {
            int[,] sol = new int[4,4]{{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0}};

            if (solveMazeUtil(maze, 0, 0, sol) == false)
            {
                System.Console.WriteLine("Solution doesn't exist");
                return false; 
            }

            printSolution(sol); 
            return true; 
        }

        /*
         * A recursive utility function to solve Maze problem 
         */
        public static bool solveMazeUtil(int[,] maze, int x, int y, int[,] sol)
        {
            // if(x,y is goal) return true
            if(x==(N-1) && y==(N-1))
            {
                sol[x,y]  = 1; 
                return true; 
            }

            // check if maze[x,y] is valid
            if (isSafe(maze, x, y))
            {
                // mark x, y as part of the solution path
                sol[x, y] = 1; 

                /* move forward in x direction*/
                if (solveMazeUtil(maze, x + 1, y, sol))
                    return true; 

                /* If moving in x direction doesn't give solution then
                   move down in y direction */
                if (solveMazeUtil(maze, x, y + 1, sol))
                    return true; 

                /* If none of the above movements work then BACKTRACK:
                   unmark x, y as part of solution path */
                sol[x, y] = 0; 
             }
           
             return false;                      
        }

        static void Main(string[] args)
        {
            int[,] maze = new int[4, 4] { { 1, 0, 0, 0 }, { 1, 1, 0, 1 }, {0,1,0,0 }, { 1,1,1,1} };
            solveMaze(maze);

            return; 
        }
    }
}
