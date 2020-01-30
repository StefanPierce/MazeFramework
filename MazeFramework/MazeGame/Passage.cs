using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework.MazeGame
{
    public class Passage
    {
        public Boolean isExit { get; private set; } = false;
        int connectionID;
        Direction exitPosition;

        

        public Passage(int id, Direction d)
        {
            connectionID = id;
            exitPosition = d;
        }

        public Passage(bool exit)
        {
            isExit = exit;
            
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
