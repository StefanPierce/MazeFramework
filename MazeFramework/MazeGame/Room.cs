using MazeFramework.MazeGame;
using OpenTK;
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

    public class Room
    {
        public int roomID;

        Passage north, east, south, west;

        Tiles[,] grid;

        static Passage[] passages;


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

        public Vector2 getEntrancePos(Direction d)
        {
            switch (d)
            {
                case Direction.NORTH:
                    return new Vector2( grid.GetLength(0) / 2, grid.GetLength(1) - 2);
                    break;
                case Direction.EAST:
                    return new Vector2(grid.GetLength(0) - 2, grid.GetLength(1) / 2);
                    break;
                case Direction.SOUTH:
                    return new Vector2(grid.GetLength(0) / 2, 1);
                    break;
                case Direction.WEST:
                    return new Vector2(1, grid.GetLength(1) / 2);
                    break;
            }

            return new Vector2(grid.GetLength(0) / 2, grid.GetLength(1) / 2);
        }

        public Boolean addPassage(Direction d, int id, Direction eD)
        {
            switch (d)
            {
                case Direction.NORTH:
                    if (north == null)
                    {
                        north = new Passage(id, eD);
                        grid[grid.GetLength(0) / 2, grid.GetLength(1) - 1] = Tiles.PASSAGE;
                        return true;
                    }
                    break;
                case Direction.EAST:
                    if(east == null)
                    {
                        east = new Passage(id, eD);
                        grid[grid.GetLength(0) - 1, grid.GetLength(1) / 2] = Tiles.PASSAGE;
                        return true;
                    }
                    break;
                case Direction.SOUTH:
                    if(south == null)
                    {
                        south = new Passage(id, eD);
                        grid[grid.GetLength(0) / 2, 0] = Tiles.PASSAGE;
                        return true;
                    }
                    break;
                case Direction.WEST:
                    if(west == null)
                    {
                        west = new Passage(id, eD);
                        grid[0, grid.GetLength(1) / 2] = Tiles.PASSAGE;
                        return true;
                    }
                    break;
            }

            return false;
        }

        public Boolean doesPassageExist(Direction d)
        {
            switch (d)
            {
                case Direction.NORTH:
                    return north != null;
                    break;
                case Direction.EAST:
                    return east != null;
                    break;
                case Direction.SOUTH:
                    return south != null;
                    break;
                case Direction.WEST:
                    return west != null;
                    break;
            }
            return false;
        }


    }
}
