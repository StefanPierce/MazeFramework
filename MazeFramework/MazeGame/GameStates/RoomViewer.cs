using MazeFramework.Engine;
using OpenTK;
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
        protected Room room;
        protected Tiles[,] grid;
        protected Texture2D floor, wall, passage;

        protected Player p1;

        Camera cam;

        Maze maze;

        public RoomViewer()
        {
            floor = ContentLoader.LoadTexture("Sprites/Room1/Floor.png");
            wall = ContentLoader.LoadTexture("Sprites/Room1/Wall.png");
            passage = ContentLoader.LoadTexture("Sprites/Room1/Passage.png");
            
            maze = new Maze(ConfigSettings.roomCount);
            room = maze.getRoom(1);

            p1 = new Player();
            p1.setPos(room.getEntrancePos(Direction.EAST));

            cam = new Camera(p1.getCameraTransform(16), 1);
        }

        public void switchRoom(Room room, Direction exitDirection)
        {
            int tRoomID = this.room.ROOMID();
            this.room = room;
            p1.setPos(room.getEntrancePos(exitDirection));
            p1.setFaceAwayFrom(exitDirection);
            grid = room.getTilesForRender();
            Console.WriteLine($"SWITCHING TO ROOM: {room.ROOMID()}");
        }

        public override void Load()
        {
            grid = room.getTilesForRender();
 
        }

        public override void Render()
        {
            cam.ApplyTran();
            

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
                        case Tiles.PASSAGE:
                            passage.Draw(16 * x, 16 * y);
                            break;
                    }
                }

            }


            p1.Render(16);
            
        }

        public override void Update()
        {
            p1.Update();
            
            try
            {
                Tiles playerPos = grid[p1.getMazeX(), p1.getMazeY()];

                if (InputHandler.playerUp())
                {
                    if(playerPos == Tiles.PASSAGE)
                    {
                        switchRoom(maze.getRoom(room.getPassage(Direction.NORTH).getConnection()), room.getPassage(Direction.NORTH).getExitDirection());
                    }
                    else if (playerPos == Tiles.WALL)
                    {
                        p1.Move(0,-1);
                    }
                }
                if (InputHandler.playerDown())
                {
                    if (playerPos == Tiles.PASSAGE)
                    {
                        switchRoom(maze.getRoom(room.getPassage(Direction.SOUTH).getConnection()), room.getPassage(Direction.SOUTH).getExitDirection());
                    }
                    else if (playerPos == Tiles.WALL)
                    {
                        p1.Move(0, 1);
                    }

                }
                if (InputHandler.playerLeft())
                {
                    if (playerPos == Tiles.PASSAGE)
                    {
                        switchRoom(maze.getRoom(room.getPassage(Direction.WEST).getConnection()), room.getPassage(Direction.WEST).getExitDirection());
                    }
                    else if (playerPos == Tiles.WALL)
                    {
                        p1.Move(1, 0);
                    }

                }
                if (InputHandler.playerRight())
                {
                    if (playerPos == Tiles.PASSAGE)
                    {
                        switchRoom(maze.getRoom(room.getPassage(Direction.EAST).getConnection()), room.getPassage(Direction.EAST).getExitDirection());
                    }else if (playerPos == Tiles.WALL)
                    {
                        p1.Move(-1, 0);
                    }

                }
            }
            catch(Exception e)
            {
            }

            cam.Update(p1.getCameraTransform(16), 1);
        }

        public override iGameState switchTo()
        {
            return null;
        }
    }
}
