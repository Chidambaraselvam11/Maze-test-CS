using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_test.Interface
{
    public interface IExplorer
    {
        char GetPlaceByCoordinate(int x, int y);

        bool ExploringMaze(int x, int y);

        bool MoveForward(int x, int y);

        bool MoveBackward(int x, int y);

        bool MoveUpward(int x, int y);

        bool MoveDownward(int x, int y);

        bool ReachMazeEnd(int x, int y);

        void GetAllpossibleOptions(int x, int y);

        void MazeOutput();

        bool EdgeWall(int x, int y);
    }
}
