using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework
{
    class Maze
    {
        List<Room> rooms;
        Random rand;
        public Maze()
        {
            rand = new Random();

            rooms = new List<Room>();

            for(int i = 0; i<20; i++)
            {
                rooms.Add(new Room(rand.Next(10,20),rand.Next(10,20)));
            }



            for(int i = 0; i < rooms.Count; i++)
            {
                int otherRoom = i;
                while(otherRoom == i)
                {
                    otherRoom = rand.Next(0, rooms.Count);
                }
                rooms[i].addPassage((Direction)rand.Next(0, 3), otherRoom);
                rooms[otherRoom].addPassage((Direction)rand.Next(0, 3), i);
            }



        }

        public int getRoomCount()
        {
            return rooms.Count();
        }

        public Room getRoom(int i)
        {
            return rooms[i];
        }
    }
}
