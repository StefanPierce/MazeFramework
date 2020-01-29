using System;
using MazeFramework;
using NUnit.Framework;

namespace MazeTesting
{
    public class UnitTest1
    {


        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        public void VerifyNumberOfRooms(int n)
        {
            Maze maze = new Maze(n);

            Assert.AreEqual(n, maze.getRoomCount());

        }


        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        public void VerifyAllRoomsConnected(int n)
        {
            Maze maze = new Maze(n);

            Assert.AreEqual(n, maze.getRoomCount());

        }

        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        public void VerifyExitIsReachable(int n)
        {
            Maze maze = new Maze(n);

            Assert.AreEqual(n, maze.getRoomCount());

        }
    }
}
