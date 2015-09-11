using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatInAMaze_BackTracking
{
    /*
     * Problem statement:
     * A Maze is given as N*N binary matrix of blocks where source block is 
     * the upper left most block i.e., maze[0][0] and destination block is 
     * lower rightmost block i.e., maze[N-1][N-1]. A rat starts from source 
     * and has to reach destination. The rat can move only in two directions: 
     * forward and down.
       
     * In the maze matrix, 0 means the block is dead end and 1 means the block 
     * can be used in the path from source to destination. Note that this is a 
     * simple version of the typical Maze problem. For example, a more complex 
     * version can be that the rat can move in 4 directions and a more complex 
     * version can be with limited number of moves.
     * 
     * Read the webpage and practice C# solution: 
     * http://www.geeksforgeeks.org/backttracking-set-2-rat-in-a-maze/
     * 
     * More reading: 
     * 1. http://algorithms.tutorialhorizon.com/backtracking-rat-in-a-maze-puzzle/
     * 
     * going four directions instead of two directions 
     * 
     * 2. https://www.cs.bu.edu/teaching/alg/maze/
     * 
     * 
     * 
     */

    /*
     * code reference: 
     * http://www.geeksforgeeks.org/backttracking-set-2-rat-in-a-maze/
     * 
     * Analysis from the above blog: 
     * 
     * naive algorithm 
     * the naive algorithm is to generate all paths from source to destination 
     * and one by one check if the generated path satisfies the constraints. 
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
     *   b) Move forward in horizontal direction and recursively check if this 
     *   move leads to a solution. 
     *   c) If the move chosen in the above step doesn't lead to a solution then 
     *   move down and check if this move leads to a solution. 
     *   d) If none of the above solutions work then unmark this cell as 0 (BACKTRACK) 
     *   and return false. 
     *   
     * julia's comment: 
     * 1. implement the naive solution later. 
     */
    public class RatInAMaze_BackTracking
    {
        static void Main(string[] args)
        {
            int[,] maze = new int[4, 4] { { 1, 0, 0, 0 }, { 1, 1, 0, 1 }, { 0, 1, 0, 0 }, { 1, 1, 1, 1 } };
            int[,] maze1 = new int[4, 4] { { 1, 1, 1, 1 }, { 1, 1, 0, 1 }, { 0, 1, 0, 0 }, { 1, 1, 1, 1 } };
            int[,] maze2 = new int[4, 4] { { 1, 1, 1, 1 }, { 1, 1, 0, 1 }, { 0, 1, 0, 0 }, { 1, 1, 1, 1 } };
            int[,] maze3 = new int[4, 4] { { 1, 1, 1, 1 }, { 1, 1, 0, 1 }, { 0, 0, 0, 1 }, { 1, 1, 1, 1 } };

            solveMaze(maze2, 3);

            return;
        }

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

        

        /* this function solves the Maze problem using Backtracking. It mainly uses 
         * solveMazeUtil() to solve the problem. It returns false if no path is possible, 
         * otherwise return true and prints the path in the form of 1s. Please note that 
         * there may be more than one solutions, this function prints one of the feasible solutions. 
         * 
         * julia's comment: 
         * 
         */
        public static bool solveMaze(int[,] maze, int no)
        {
            //int[,] sol = new int[4,4]{{0,0,0,0},{0,0,0,0},{0,0,0,0},{0,0,0,0}};
            int[,] sol = new int[N, N];            

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    sol[i, j] = 0; 

            switch(no)
            {
                case 1: 
                    if (solveMazeUtil(maze, 0, 0, sol) == false)
                    {
                        System.Console.WriteLine("Solution doesn't exist");
                        return false; 
                    }
                    break; 
                case 2:
                    if (solveMazeUtil_B(maze, 0, 0, sol) == false)
                    {
                        System.Console.WriteLine("Solution doesn't exist");
                        return false;
                    }
                    break; 
                case 3: 
                    if (solveMazeUtil_C(maze, 0, 0, sol) == false)
                    {
                        System.Console.WriteLine("Solution doesn't exist");
                        return false;
                    }
                    break; 

            }

            printSolution(sol); 
            return true; 
        }

        public static bool solveMaze_B(int[,] maze)
        {
            int[,] sol = new int[4, 4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            
            if (solveMazeUtil_B(maze, 0, 0, sol) == false)
            {
                System.Console.WriteLine("Solution doesn't exist");
                return false;
            }

            printSolution(sol);
            return true;
        }

        /*
         * A recursive utility function to solve Maze problem          
         * code reference:
         *  http://www.geeksforgeeks.org/backttracking-set-2-rat-in-a-maze/
         *  
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

        /* a utility function to check if x, y is valid index for N*N maze
        */
        public static bool isSafe(int[,] maze, int x, int y)
        {
            //if(x,y outside maze) return false
            if (x >= 0 && x < N && y >= 0 && y < N && maze[x, y] == 1)
                return true;
            return false;
        }

        /*
         * Julia's comment:
         * 1. make some code change: 
         * 2. add thought process. 
         *    review thought process, refine the process. 
         *    
        * A recursive utility function to solve Maze problem 
        * thought process: 
        * 1. Base case: reach the goal (N-1, N-1) 
        * 
        * 2. check if maze[x, y] is valid, if not, return false early, 
        * 
        * 3. Action: 
        *    mark x, y as part of the solution  <- need to undo the change in step 7 
        *   
        * 4, 5: 
        * step 4 and 5 can be switched in order ( right, down) or (down, right):
        *  If it is, then, move forward with two possible directions:
        *   step 4:  first try, in x direction, (can be down direction)
        *    return true if the path is found; 
        *     
        *   step 5: if moving in x direction doesn't give solution then move down in y direction, 
        *    return true if the path is found. 
         *    
        * 6. backtracking step, most important one. 
        *    If none of the above movements work then do backtracking, 
        *    unmark x, y as part of the solution path. 
         *   In other words, undo the step 3.          *   
         * 
         *7. return false; 
         *
        * So, in other words, 7 steps, 
        *     first step is base case, 
        *     and second step is checking maze[x,y] is valid, return false ealy if it is not.  
         *     
        *     Do some work, try to add (x,y) in the solution path, if true, return, otherwise, undo the change: 
        *        mark x, y as part of the solution path. 
        *        
        *     third step, try to move forward in two possible directions. 
        *     first try in x direction, if failed, then try second direction, y direction. 
         *     
        *     If both of tries fails, then back tracking, 
        *      
        *     unmark x, y as part of the solution path. 
         *    
         *    return false at the end of function. 
         *    
         * Try to have some debates here: 
         *  1. two arrays, one is maze array, one is solution array, both are two dimensional array. 
         *     Solution array is declared inside the function solveMaze_B
         *  2. What are easy mistakes on the coding: 
         *    1. isSafe checking not complete: check boundary, also check the value of position in the maze is reachable. 
         *    2. forget to do backtracking, so that the solution cannot be found
         *    3. function return false at the end - 'Not all pathes returns value - default is returning false, instead of true'
         *    4. various try of next move has 2 directions, some problem may have 4 cases. 
         *    5. use array to contain directions info, the code can be different, try it and see difference
         *        solveMazeUtil_C
        * 
        */
        public static bool solveMazeUtil_B(int[,] A, int x, int y, int[,] sol)
        {
            // step 1: base case 
            if (x == (N - 1) && y == (N - 1))
            {
                sol[x, y] = 1;
                return true;
            }

            // step 2: check if maze[x,y] is valid
            if (!isSafe(A, x, y))
                return false; 

            
            // step 3: mark x, y as part of the solution path  <- try the position as a solution
            sol[x, y] = 1;

            /* step 4:  move forward in x direction*/
            if (solveMazeUtil_B(A, x + 1, y, sol))         // one direction, can be right or down, choose one
                return true;

            /* step 5: If moving in x direction doesn't give solution then
                move down in y direction */
            if (solveMazeUtil_B(A, x, y + 1, sol))
                return true;

            /* step 6: If none of the above movements work then BACKTRACK:
                unmark x, y as part of solution path */
            sol[x, y] = 0;                                       /* <-  undo the change, because of failure */        
            /* step 7: return false */
            return false; 
        }

        /*
         * julia's comment: 
         * 
         * write my own version code, make some changes. And see what I learn through the new version. 
         * 
         * using array to include direction information 
         * some debates: 
         *  1.  using two dimension array to contain the direction info, and then, 
         *      go through array first dimension. 
         *   
         *   another way is to go through one by one, directions info is scattered around. 
         *   
         *  2. Get familiar with two dimension array usage. 
         */
        public static bool solveMazeUtil_C(int[,] A, int x, int y, int[,] sol)
        {
            // step 1: base case 
            if (x == (N - 1) && y == (N - 1))
            {
                sol[x, y] = 1;
                return true;
            }

            // step 2: check if maze[x,y] is valid
            if (!isSafe(A, x, y))
                return false;


            // step 3: mark x, y as part of the solution path  <- try the position as a solution
            sol[x, y] = 1;

            // step 4: all directions 
            int[,] directions = new int[2, 2] {{0,1}, {1,0}};

            int size = directions.GetLength(0);  // first dimension            

            for (int i = 0; i < size; i++)       // go through first dimension, not second one 
            {
                int tmpX = x + directions[i, 0]; 
                int tmpY = y + directions[i, 1]; 

                if(solveMazeUtil_C(A, tmpX, tmpY, sol) )
                    return true;  
            }           

            /* step 5: If none of the above movements work then BACKTRACK:
                unmark x, y as part of solution path */
            sol[x, y] = 0;                                       /* <-  undo the change, because of failure */

            /* step 6: return false */
            return false;
        }

        /*
         * good reading:  (9/10/2015)
         * https://www.cs.bu.edu/teaching/alg/maze/
         * 
         * We'll solve the problem of finding and marking a solution path using recursion.
            Remember that a recursive algorithm has at least 2 parts:

            Base case(s) that determine when to stop.
            Recursive part(s) that call the same algorithm (i.e., itself) to assist in solving the problem.
         
            Base cases

            It's not enough to know how to use FIND-PATH recursively to advance 
            through the maze. We also need to determine when FIND-PATH must stop.
            One such base case is to stop when it reaches the goal.

            The other base cases have to do with moving to invalid positions. For example, 
            we have mentioned how to search North of the current position, but disregarded 
            whether that North position is legal. In order words, we must ask:

            Is the position in the maze (...or did we just go outside its bounds)?
            Is the position open (...or is it blocked with an obstacle)?
            Now, to our base cases and recursive parts, we must add some steps to mark positions 
            we are trying, and to unmark positions that we tried, but from which we failed to reach the goal:

            FIND-PATH(x, y)

            if (x,y outside maze) return false
            if (x,y is goal) return true
            if (x,y not open) return false
            mark x,y as part of solution path
            if (FIND-PATH(North of x,y) == true) return true
            if (FIND-PATH(East of x,y) == true) return true
            if (FIND-PATH(South of x,y) == true) return true
            if (FIND-PATH(West of x,y) == true) return true
            unmark x,y as part of solution path
            return false
         
            All these steps together complete a basic algorithm that finds and marks a path to 
            the goal (if any exists) and tells us whether a path was found or not (i.e., 
            returns true or false). This is just one such algorithm--other variations are possible.

         * Julia's comment: 
         * 
         *  1. remember the pseudo code algorith FIN-PATH(x,y), and never fail on any back tracking algorithm again. 
         *    debates about base cases: 
         *    if (x,y outside maze) return false
              if (x,y is goal) return true
              if (x,y not open) return false
         
              The above order can be adjusted? 
         *  2. My practice mistake (9/10/2015, solveMazeUtil_C) is "return false" in the pseudo code, 
         *     last line; how to prevent it next time?
         *     check all paths in the function, miss a return? default is true/false, answer this basic question. 
         *     only return true if confirmation of path is found, reaching target position. 
         *     
         *  3. If the moving direction is down and right, then, no way to form a loop; but if there are 4 directions to move, maybe, there is a loop; so extra checking needs to be done, "make sure that node is not in the path already". Because deadlock may be formed since there is a loop. (9/11/2015, second day thought after review of 9/10/2015)
         */

        /*
         * Another interesting reading:
         * http://blogs.msdn.com/b/mattwar/archive/2005/02/03/366498.aspx
         * 
         * The Setup
         * 
         * Like those comments from the interviewer: 
         * 
         * Fortunately, that's not the way it works here either. Finding a correct solution 
         * to the problem is not the end goal. In an interview I assume you can do that. 
         * What is more important to me as an interviewer is what I learn about you as you 
         * attempt to solve it. Like, do you communicate well. Do you test your assumptions? 
         * Do you have any assumptions? Do you believe in your solution? Can you apply what 
         * you've just learned to a follow up question/scenario? Do you identify the full 
         * problem before plunging into the deep end? Are you able to back out of a dead end? 
         * Do you recognize when you are at a dead end? 
         * 
         * The solution blog:
         * http://blogs.msdn.com/b/mattwar/archive/2005/02/11/371274.aspx
         * 
         * Julia's comment: 
         * 
         *  enjoy the reading of the material. One practice leads more reading, ...
         */
    }
}
