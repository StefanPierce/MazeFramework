using MazeFramework.MazeGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework
{
    public enum Tiles
    {
        FLOOR,
        WALL,
        PASSAGE
    }

    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    class Room
    {
        public int roomID;

        Passage north, east, south, west;

        Tiles[,] grid;


        public static int roomCounter = 0;

        public Room(int width, int height)
        {
            roomID = getRoomID();

            grid = new Tiles[width, height];
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    if (x == 0 || y == 0 || x == grid.GetLength(0)-1 || y == grid.GetLength(1)-1)
                    {
                        grid[x, y] = Tiles.WALL;
                    }
                    else
                    {
                        grid[x, y] = Tiles.FLOOR;
                    }
                }

            }



        }

        public int ROOMID()
        {
            return roomID;
        }
        private int getRoomID()
        {
            roomCounter++;
            return roomCounter;
        }

        public Tiles[,] getTilesForRender()
        {
            return grid;
        }

        public Passage getPassage(Direction d)
        {
            switch (d)
            {
                case Direction.NORTH:
                    return north;
                case Direction.EAST:
                    return east;
                case Direction.SOUTH:
                    return south;
                case Direction.WEST:
                    return west;
            }
            return null;
        }

        public void addPassage(Direction d, int id)
        {
            switch (d)
            {
                case Direction.NORTH:
                    north = new Passage(id);
                    grid[grid.GetLength(0) / 2, grid.GetLength(1) - 1] = Tiles.PASSAGE;
                    break;
                case Direction.EAST:
                    east = new Passage(id);
                    grid[grid.GetLength(0) - 1, grid.GetLength(1) / 2] = Tiles.PASSAGE;
                    break;
                case Direction.SOUTH:
                    south = new Passage(id);
                    grid[grid.GetLength(0) / 2, 0] = Tiles.PASSAGE;
                    break;
                case Direction.WEST:
                    west = new Passage(id);
                    grid[0, grid.GetLength(1)/2] = Tiles.PASSAGE;
                    break;
            }
        }

    }
}
