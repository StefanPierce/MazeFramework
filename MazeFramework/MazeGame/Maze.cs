using MazeFramework.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework
{
    public class Maze
    {
        List<Room> rooms;
        Random rand;

        public Maze(int roomCount)
        {
            rand = new Random();

            rooms = new List<Room>();


            for(int i = 0; i<roomCount; i++)
            {
                rooms.Add(
                    new Room(
                        rand.Next(ConfigSettings.minRoomHeight,ConfigSettings.maxRoomHeight),
                        rand.Next(ConfigSettings.minRoomWidth, ConfigSettings.maxRoomWidth))
                    );
            }

            GeneratePassage(0,(Direction)0);

            Console.WriteLine(AddExit(rand.Next(0, rooms.Count-1)) ? "exit added" : "exit not added");




        }

        private void GeneratePassage(int i, Direction prevDir)
        {
            
            int otherRoom = i + 1;

            if(otherRoom >= rooms.Count)
            {
                otherRoom = 0;
            }

            Direction r1 = prevDir;
            while (r1 == prevDir)
            {
                r1 = (Direction)rand.Next(0, 4);
            }

            Direction r2 = (Direction)rand.Next(0, 4);

            if (rooms[otherRoom].addPassage(r2, i, r1))
            {
                rooms[i].addPassage(r1, otherRoom, r2);
            }

            if(otherRoom != 0)
            {
                GeneratePassage(otherRoom, r2);

            }

        }

        private Boolean AddExit(int i)
        {
            return rooms[i].AddExit();
        }
            
        
        public List<Room> getRooms()
        {
            return rooms;
        }

        public void GenerateTreasures()
        {
            foreach(Room r in rooms)
            {
                r.GenerateTreasures();
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
