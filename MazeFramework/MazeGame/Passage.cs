using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework.MazeGame
{
    class Passage
    {
        Boolean isExit;
        int connectionID;

        public Passage(int id)
        {
            connectionID = id;
        }

        public int getConnection()
        {
            return connectionID;
        }
    }
}
