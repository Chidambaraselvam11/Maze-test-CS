using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze_test.Interface;

namespace Maze_test
{
    public class Explorer : IExplorer
    {
        public char[,] mazeMatrix = {
            { 'X','X','X','X','X','X','X','X','X','X','X','X','X','X','X'},
            { 'X',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','X'},
            { 'X',' ','X','X','X','X','X','X','X','X','X','X','X',' ','X'},
            { 'X',' ','X',' ',' ',' ',' ',' ',' ',' ',' ',' ','X',' ','X'},
            { 'X',' ','X','X','X','X','X','X','X','X','X',' ','X',' ','X'},
            { 'X',' ','X','X','X','X','X','X','X','X','X',' ','X',' ','X'},
            { 'X',' ','X','X','X','X',' ',' ',' ',' ',' ',' ','X',' ','X'},
            { 'X',' ','X','X','X','X',' ','X','X','X','X',' ','X',' ','X'},
            { 'X',' ','X','X','X','X',' ','X','X','X','X',' ','X',' ','X'},
            { 'X',' ','X',' ',' ',' ','S','X','X','X','X','X','X',' ','X'},
            { 'X',' ','X',' ','X','X','X','X','X','X','X','X','X',' ','X'},
            { 'X',' ','X',' ','X','X','X','X','X','X','X','X','X',' ','X'},
            { 'X',' ','X',' ',' ',' ',' ',' ',' ',' ',' ',' ','X',' ','X'},
            { 'X',' ',' ',' ','X','X','X','X','X','X','X','X',' ',' ','X'},
            { 'X','F','X','X','X','X','X','X','X','X','X','X','X','X','X'}
        };

        public int mazeStartX;
        public int mazeStartY;
        public int mazeCurrentX;
        public int mazeCurrentY;

        public Explorer()
        {            
            for (int mazeRow = 0; mazeRow < mazeMatrix.GetLength(0); mazeRow++)
            {
                for (int mazeCol = 0; mazeCol < mazeMatrix.GetLength(1); mazeCol++)
                {
                    if (mazeMatrix[mazeRow, mazeCol] == 'S')
                    {
                        mazeStartX = mazeRow;
                        mazeStartY = mazeCol;
                        mazeCurrentX = mazeRow;
                        mazeCurrentY = mazeCol;
                        Console.WriteLine("{0} , {1}", mazeStartX, mazeStartY);
                    }
                }
            }
            Console.WriteLine(ExploringMaze(mazeStartX, mazeStartY));
            Console.ReadLine();
        }

        public char GetPlaceByCoordinate(int x, int y)
        {
            return mazeMatrix[x, y];
        }

        public bool ExploringMaze(int x, int y)
        {
            MazeOutput();
            Console.WriteLine();
            if (ReachMazeEnd(x, y))
            {
                return true;
            }
            else if (EdgeWall(x, y))
            {
                mazeCurrentX = x;
                mazeCurrentY = y;
                return false;
            }
            else
            {
                mazeMatrix[x, y] = '>';
                mazeCurrentX = x;
                mazeCurrentY = y;

                if (y - 1 >= 0 && ExploringMaze(x, y - 1))
                {
                    return true;
                }
                else if (x + 1 < mazeMatrix.GetLength(0) && ExploringMaze(x + 1, y))
                {
                    return true;
                }
                else if (y + 1 < mazeMatrix.GetLength(1) && ExploringMaze(x, y + 1))
                {
                    return true;
                }
                else if (x - 1 >= 0 && ExploringMaze(x - 1, y))
                {
                    return true;
                }
                else
                {
                    mazeMatrix[x, y] = '>';
                    mazeCurrentX = x;
                    mazeCurrentY = y;
                    return false;
                }
            }                       
        }        

        public bool MoveForward(int x, int y)
        {
            if (y + 1 < mazeMatrix.GetLength(1) && ReachMazeEnd(x, y + 1))
            {
                Console.WriteLine("Destination reached Successfully");
                return false;
            }            
            else if (y + 1 < mazeMatrix.GetLength(1))
            {
                mazeCurrentX = x;
                mazeCurrentY = y + 1;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MoveBackward(int x, int y)
        {
            if (y - 1 >= 0 && ReachMazeEnd(x, y - 1))
            {
                Console.WriteLine("Destination reached Successfully");
                return false;
            }
            else if (y - 1 >= 0)
            {
                mazeCurrentX = x;
                mazeCurrentY = y-1;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MoveUpward(int x, int y)
        {
            if (x - 1 >= 0 && ReachMazeEnd(x-1, y))
            {
                Console.WriteLine("Destination reached Successfully");
                return false;
            }
            else if (x - 1 >= 0)
            {
                mazeCurrentX = x-1;
                mazeCurrentY = y;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MoveDownward(int x, int y)
        {
            if (x + 1 < mazeMatrix.GetLength(0) && ReachMazeEnd(x + 1, y))
            {
                Console.WriteLine("Destination reached Successfully");
                return false;
            }
            else if (x + 1 < mazeMatrix.GetLength(0))
            {
                mazeCurrentX = x + 1;
                mazeCurrentY = y;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ReachMazeEnd(int x, int y)
        {
            return mazeMatrix[x, y] == 'F';
        }

        public void GetAllpossibleOptions(int x, int y)
        {
            if (y - 1 >= 0 && mazeMatrix[x, y - 1] == ' ')
            {
                Console.WriteLine("backward");
            }
            if (y + 1 < mazeMatrix.GetLength(1) && mazeMatrix[x, y + 1] == ' ')
            {
                Console.WriteLine("forwardward");
            }
            if (x - 1 >= 0 && mazeMatrix[x - 1, y] == ' ')
            {
                Console.WriteLine("upward");
            }
            if (x + 1 < mazeMatrix.GetLength(0) && mazeMatrix[x + 1, y] == ' ')
            {
                Console.WriteLine("downward");
            }
        }

        public void MazeOutput()
        {
            for (int mazeRow = 0; mazeRow < mazeMatrix.GetLength(0); mazeRow++)
            {
                for (int mazeCol = 0; mazeCol < mazeMatrix.GetLength(1); mazeCol++)
                {
                    Console.Write(mazeMatrix[mazeRow, mazeCol]);                    
                }
                Console.WriteLine();
            }
        }

        public bool EdgeWall(int x, int y)
        {
            return ".X".IndexOf(mazeMatrix[x, y]) != -1;            
        }
    }
}
