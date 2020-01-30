using System;
using MazeFramework;
using MazeFramework.MazeGame;
using NUnit.Framework;

namespace MazeTesting
{
    public class UnitTest1
    {
        Maze maze;

        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        public void VerifyNumberOfRooms(int n)
        {
            maze = new Maze(n);

            Assert.AreEqual(n, maze.getRoomCount());

        }


        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        public void VerifyAllRoomsConnected(int n)
        {
            maze = new Maze(n);

            Room room = maze.getRoom(0);

            TraverseRooms(ref room);
            int count = 0;

            foreach (Room r in maze.getRooms())
            {
                count++;

                if (!r.isVisited)
                {
                    Assert.True(r.isVisited, $"Room {count} was not visited");
                }
            }


            
        }

        public void TraverseRooms(ref Room r)
        {
            r.setVisited();

            if(r.getPassages() != null)
            {
                foreach (Passage p in r.getPassages())
                {
                    if (p != null)
                    {
                        Room r2 = maze.getRoom(p.getConnection());
                        
                        if (!r2.isVisited)
                        {
                            TraverseRooms(ref r2);
                        }
                    }
                    


                }
            }

            
            

            

        }

        

        [TestCase(10)]
        [TestCase(20)]
        [TestCase(50)]
        public void VerifyExitExists(int n)
        {
            maze = new Maze(n);

            bool exit = false;
            foreach(Room r in maze.getRooms())
            {
                foreach(Passage p in r.getPassages())
                {
                    if (p != null)
                    {
                        if (p.isExit)
                        {
                            exit = true;
                        }
                    }
                }
            }

            Assert.True(exit, "Exit has been found");

        }

        public bool FindExit(Room r, int prevRoomID)
        {

            if (r.getPassages() != null)
            {
                foreach (Passage p in r.getPassages())
                {
                    if (p != null)
                    {
                        if (p.isExit)
                        {
                            Console.WriteLine($"Found in room {r.roomID}");
                            return true;
                        }
                        else
                        {
                            if (p.getConnection() != prevRoomID)
                            {
                                return FindExit(maze.getRoom(p.getConnection()), r.roomID);
                            }

                        }
                    }
                }
            }
            return false;




        }
    }
}
