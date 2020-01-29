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
        public Maze(int roomCount)
        {
            rand = new Random();

            rooms = new List<Room>();

            for(int i = 0; i<roomCount; i++)
            {
                rooms.Add(new Room(rand.Next(8,12),rand.Next(8,12)));
            }



            for(int i = 0; i < rooms.Count; i++)
            {
                

                for(int x = 0; x < 3; x++)
                {
                    int otherRoom = i;
                    while (otherRoom == i)
                    {
                        otherRoom = rand.Next(0, rooms.Count);
                    }

                    Direction r1 = (Direction)rand.Next(0, 3);
                    Direction r2 = (Direction)rand.Next(0, 3);

                    if (!rooms[i].doesPassageExist(r1))
                    {
                        if (rooms[otherRoom].addPassage(r2, i, r1))
                        {
                            Console.WriteLine("ADDED ROOM 1");
                            if (rooms[i].addPassage(r1, otherRoom, r2))
                            {
                                Console.WriteLine("ADDED ROOM 2");
                            }

                            Console.WriteLine("-----");
                        }
                    }
                }
                
                


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
