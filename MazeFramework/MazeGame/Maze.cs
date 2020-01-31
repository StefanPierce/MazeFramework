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

        public Maze(int roomCount)
        {
            

            rooms = new List<Room>();


            for(int i = 0; i<roomCount; i++)
            {
                rooms.Add(
                    new Room(
                        InputHandler.getRandom(ConfigSettings.minRoomHeight,ConfigSettings.maxRoomHeight),
                        InputHandler.getRandom(ConfigSettings.minRoomWidth, ConfigSettings.maxRoomWidth))
                    );
            }

            GeneratePassage(0,(Direction)0);

            Console.WriteLine(AddExit(InputHandler.getRandom(0, rooms.Count-1)) ? "exit added" : "exit not added");

            GenerateExtraPassages();


        }


        //This will generate extra random passages after a straight path has been added
        private void GenerateExtraPassages()
        {
            for (int i = 0; i < rooms.Count; i++)
            {


                for (int x = 0; x < 2; x++)
                {
                    int otherRoom = i;
                    while (otherRoom == i)
                    {
                        otherRoom = InputHandler.getRandom(0, rooms.Count);
                    }

                    Direction r1 = (Direction)InputHandler.getRandom(0, 4);
                    Direction r2 = (Direction)InputHandler.getRandom(0, 4);

                    if (!rooms[i].doesPassageExist(r1))
                    {
                        if (rooms[otherRoom].addPassage(r2, i, r1))
                        {
                            rooms[i].addPassage(r1, otherRoom, r2);
                            

                        }
                    }
                }
            }
        }

        //will generate a path of passages from one room to the next, this means
        //all rooms will be reachable
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
                r1 = (Direction)InputHandler.getRandom(0, 4);
            }

            Direction r2 = (Direction)InputHandler.getRandom(0, 4);

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

        public void GenerateEnemies()
        {
            foreach(Room r in rooms)
            {
                r.GenerateEnemies();
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
