using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework
{
    class RoomViewer : iGameState
    {
        Room room;
        Tiles[,] grid;
        Texture2D floor, wall;

        Player p1;

        Maze maze;

        public RoomViewer()
        {
            floor = ContentLoader.LoadTexture("Sprites/Room1/Floor.png");
            wall = ContentLoader.LoadTexture("Sprites/Room1/Wall.png");


            maze = new Maze();
            room = maze.getRoom(1);

            p1 = new Player();
        }

        public void switchRoom(Room room)
        {
            
            this.room = room;
            grid = room.getTilesForRender();
        }

        public override void Load()
        {
            grid = room.getTilesForRender();
 
        }

        public override void Render()
        {

            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    switch (grid[x, y])
                    {
                        case Tiles.FLOOR:
                            floor.Draw(16 * x, 16 * y);
                            break;
                        case Tiles.WALL:
                            wall.Draw(16 * x, 16 * y);
                            break;
                    }
                }

            }

            p1.Render();
        }

        public override void Update()
        {
            try
            {
                if (InputHandler.playerUp())
                {
                    switchRoom(maze.getRoom(room.getPassage(Direction.NORTH).getConnection()));
                }
                if (InputHandler.playerDown())
                {
                    switchRoom(maze.getRoom(room.getPassage(Direction.SOUTH).getConnection()));

                }
                if (InputHandler.playerLeft())
                {
                    switchRoom(maze.getRoom(room.getPassage(Direction.WEST).getConnection()));

                }
                if (InputHandler.playerRight())
                {
                    switchRoom(maze.getRoom(room.getPassage(Direction.EAST).getConnection()));

                }
            }
            catch(Exception e)
            {
                Console.WriteLine("No Passage that way");
            }

            p1.Update();
        }

        public override iGameState switchTo()
        {
            return null;
        }
    }
}
