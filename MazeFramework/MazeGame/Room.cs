using MazeFramework.Engine;
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
        PASSAGE,
        EXIT
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

        int roomWidth, roomHeight;


        List<Treasure> treasures;
        List<Enemy> enemies;

        public Boolean isVisited { get; private set; }  = false;


        public Room(int width, int height)
        {
            roomID = getRoomID();
            roomWidth = width;
            roomHeight = height;

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

            treasures = new List<Treasure>();
            enemies = new List<Enemy>();

            
        }

        public void GenerateEnemies()
        {
            int num = InputHandler.getRandom(0, 4);

            int x, y;

            for(int i = 0; i < num; i++)
            {
                x = InputHandler.getRandom(1, roomWidth-1);
                y = InputHandler.getRandom(1, roomHeight-1);
                enemies.Add(new Enemy($"ENEMY{i}", ENEMY.ENEMY1, x, y));
            }
        }
        public void setVisited()
        {
            isVisited = true;
        }

        public Passage[] getPassages()
        {
            return new Passage[] { north, east, south, west };
        }

        public int getPassageCount()
        {
            int count = 0;
            if (north != null)
            {
                count++;
            }
            if (south != null)
            {
                count++;
            }
            if (south != null)
            {
                count++;
            }
            if (south != null)
            {
                count++;
            }

            return count;
        }

        public void GenerateTreasures()
        {
            for (int i = 0; i < 10; i++)
            {
                treasures.Add(new Treasure("Treasure", TREASURE.COIN, InputHandler.getRandom(1, roomWidth - 1), InputHandler.getRandom(1, roomHeight - 1)));
            }
        }
        

        public int isTreasureAt(int mazeX, int mazeY)
        {
            int total = 0;
            foreach(Treasure t in treasures)
            {
                
                if(mazeX == t.getX() && mazeY == t.getY())
                {
                    total += t.pickUp();
                }
            }
            return total;
        }

        public void clearTreasures()
        {
            for(int i = treasures.Count-1; i >= 0;  i--)
            {
                if (treasures[i].delete)
                {
                    treasures.RemoveAt(i);
                }
            }
        }

        public void RenderTreasures()
        {
            foreach(Treasure t in treasures)
            {
                t.Render();
            }
        }

        public void RenderEnemies()
        {
            foreach(Enemy e in enemies)
            {
                e.Render();
            }
        }

        public void HitEnemies(int damage, Vector2 pos)
        {
            foreach(Enemy e in enemies) { 
                if(e.getX() == (int)pos.X && e.getY() == (int)pos.Y){
                    e.Hit(damage);
                }
            }
        }

        public void ClearEnemies()
        {
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                if (enemies[i].dead)
                {
                    enemies.RemoveAt(i);
                }
            }
        }

        public int UpdateEnemies(int x, int y)
        {
            int damage = 0;
            foreach(Enemy e in enemies)
            {
                damage += e.Update(x,y);

                
            }

            foreach(Enemy e in enemies)
            {
                foreach (Enemy e2 in enemies)
                {
                    if (!e.name.Equals(e2.name))
                    {
                        if (e.getX() == e2.getX() && e.getY() == e2.getY()) {
                            e.MoveBack();
                            continue;
                        }
                        
                    }
                }
            }
            
            return damage;
        }

        public int ROOMID()
        {
            return roomID;
        }
        private int getRoomID()
        {
            roomCounter++;
            return roomCounter-1;
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

        public Boolean AddExit()
        {
            Console.WriteLine("PASSAGE ADDED TO ROOM " + roomID);
            Passage p = new Passage(true);

            if (north == null)
            {
                north = p;
                grid[grid.GetLength(0) / 2, grid.GetLength(1) - 1] = Tiles.PASSAGE;
                return true;
            }
            else if (south == null)
            {
                south = p;
                grid[grid.GetLength(0) / 2, 0] = Tiles.PASSAGE;
                return true;

            }
            else if (east == null)
            {
                east = p;
                grid[grid.GetLength(0) - 1, grid.GetLength(1) / 2] = Tiles.PASSAGE;
                return true;

            }
            else if (west == null)
            {
                west = p;
                grid[0, grid.GetLength(1) / 2] = Tiles.PASSAGE;
                return true;

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
