using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework.MazeGame
{
    public class Passage
    {
        Boolean isExit;
        int connectionID;
        Direction exitPosition;

        public Passage(int id, Direction d)
        {
            connectionID = id;
            exitPosition = d;
        }

        public Direction getExitDirection()
        {
            return exitPosition;
        }

        public int getConnection()
        {
            return connectionID;
        }
    }
}
