using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * problem from blog:
 * http://blogs.msdn.com/b/mattwar/archive/2005/02/03/366498.aspx
 * 
 * setup:
 * The Setup

        You are being asked to write the algorithm/software for a robotic mouse that 
        needs to navigate a maze in order to find some cheese.  There are computing resources 
        available, as wells as a modern programming language to develop your solution.   

         I'll describe the problem using C# but you may choose any common programming language.  
         The maze exists as a regular grid of squarish cells, potentially bordered on each side 
         by a wall that prevents movement in that direction.  In one of these cells is the cheese, 
         and in another is the mouse.  Neither location is known at the start of the search.

        The interface you have by which to control the mouse is rather limited.   It has one function 
        that moves the mouse in a cardinal direction, returning true/false depending on whether the 
        move was successful or not, and another function that returns true if the cheese is actually 
        in the mouse's current cell.

        public interface IMouse {
           bool Move(Direction d);
           bool IsCheeseHere();
        }

        public enum Direction {
          North,
          East,
          South,
          West
        }

    Things to note:   The mouse is intended to be a physical mouse that must be moved via this interface.  
    The software is required to move the mouse to the cheese and then halt.  You may ignore the physical 
    uncertainties of actual movement and assume that each successful move moves the mouse into the center 
    of the adjacent cell, and each unsuccessful moves leave the mouse in its position.  You may also assume 
    the maze to be limited to some reasonable size, at most 100x100 cells, and it is actually possible for 
    the  mouse to reach the cheese.
 */

/*
 * 
 * comment I like most from the blog:
 * Fortunately, that's not the way it works here either. Finding a correct solution to the problem is not 
 * the end goal. In an interview I assume you can do that. What is more important to me as an interviewer 
 * is what I learn about you as you attempt to solve it. Like, do you communicate well. Do you test your assumptions? 
 * Do you have any assumptions? Do you believe in your solution? Can you apply what you've just learned to 
 * a follow up question/scenario? Do you identify the full problem before plunging into the deep end? Are you 
 * able to back out of a dead end? Do you recognize when you are at a dead end?
   
 * Analysis from the blog:
 * 
 * http://blogs.msdn.com/b/mattwar/archive/2005/02/11/371274.aspx
 * 
 * lets discuss the problem again so we can understand the solutions in context.  A robot mouse is dropped 
 * into a maze where somewhere there is placed a piece of cheese.  You must write an algorithm to control 
 * the mouse and successfully find the cheese.  Unfortunately, the mouse is blind so the only feedback you 
 * have is the paltry information coming back from the mouse 'interface'.  The maze is a regular grid of cells, 
 * where each cells may have zero or more walls that impede movement, except for the outer edge that is completely 
 * sealed.   
 * 
 * At the start you don't know where the walls are, you don't know where the cheese is and you definitely don't 
 * know where the mouse is.  All you do know that the maze is limited to some particular size.

   What this should tell you is that you need to exhaustively and deterministically search the maze, stopping only 
 * when you find the cheese.  What it doesn't tell you is the pitfalls you may encounter when doing so, things like 
 * cycles, paths that lead back onto themselves, and open expanses that have no walls around them at all.  A successful 
 * solution will avoid these areas of trouble.  A good solution will do it in a nominal number of moves.

   You must avoid walking randomly.  There is no way of knowing whether the series of suggested directions will actually 
 * cause you to traverse the entire maze.   You may just bob back and forth forever.
 * 
   You must avoid walking in circles.  You need to employ some mechanism to remember where you have been.  Since the mouse 
 * cannot tell you where it is or where it has been, and offers no model of the world other than success or failure to move, 
 * you must invent your own model and a means to keep track. 
   
 * You must avoid getting stuck at a dead end.  Going back the way you came is a good idea, but make sure you have a way to 
 * keep going, that path up to the end might have been narrow and long.
 * 
   At the edges of your explored space will be all the places you have not yet been.  In order to exhaustively search the 
 * maze you need a way to get back there and try them.

   So successful solutions employs cycle detection and backtracking.  
 */
namespace MousingAround
{
    struct Cell {
            public byte next;
            public byte prev;
    }

    public interface IMouse {
        bool Move(Direction d);
        bool IsCheeseHere();
    }

    public enum Direction {
      North,
      East,
      South,
      West
    }

    class MousingAround
    {
        static void Main(string[] args)
        {
        }

        /*
         * code reference: 
         * http://blogs.msdn.com/b/mattwar/archive/2005/02/11/371274.aspx
         * 
         * julia's comment: 
         *  1. try to identify the cycle detection / back tracking code
         *  2. Try to understand code. 
         */
        public static bool FindCheese(IMouse mouse, int rows, int cols) {

            Cell[,] grid = new Cell[rows, cols];

            int r = 0;
            int c = 0; 

            // set terminal, so we don't backtrack past the origin

            grid[r, c].prev = 4; 

            while (!mouse.IsCheeseHere()) {

                byte d = grid[r,c].next;

                if (d < 4) {

                    // increment so we know what to try next

                    grid[r,c].next++;                   

                    // determine next relative position

                    int nr = (r + dr[d] + rows) % rows;

                    int nc = (c + dc[d] + cols) % cols;
                   

                    // only try to move to cells we have not already visited

                    if (grid[nr,nc].next == 0 && mouse.Move((Direction)d)) {

                        r = nr;

                        c = nc; 

                        // remember how to get back
                        grid[r, c].prev = (byte)((d + 2) % 4);
                    }

                }
                else {

                    // backtrack
                    d = grid[r, c].prev;

                    if (d == 4)
                        return false;

                    mouse.Move((Direction)d);

                    r = (r + dr[d] + rows) % rows;

                    c = (c + dc[d] + cols) % cols;
                }
            } 

            return true;
        } 

        static int[] dr = new int[] { -1, 0, 1, 0 };

        static int[] dc = new int[] { 0, 1, 0, -1 };
    
    }
}
