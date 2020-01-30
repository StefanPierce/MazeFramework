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

        protected Texture2D UIMoney;

        float zoom = 1;

        protected Player p1;

        Camera cam;

        Maze maze;
        Tiles[,] around = new Tiles[0, 0];

        public RoomViewer()
        {
            floor = ContentLoader.LoadTexture("Sprites/Room1/Floor.png");
            wall = ContentLoader.LoadTexture("Sprites/Room1/Wall.png");
            passage = ContentLoader.LoadTexture("Sprites/Room1/Passage.png");

            UIMoney = ContentLoader.LoadTexture("Sprites/Treasures/UI.png");

            maze = new Maze(ConfigSettings.roomCount);
            maze.GenerateTreasures();
            maze.GenerateEnemies();
            room = maze.getRoom(0);


            p1 = new Player();
            p1.setPos(room.getEntrancePos(Direction.EAST));

            cam = new Camera(p1.getCameraTransform(zoom), zoom);
        }

        public void switchRoom(Room room, Direction exitDirection)
        {
            int tRoomID = this.room.ROOMID();
            this.room = room;
            p1.setPos(room.getEntrancePos(exitDirection));
            p1.setFaceAwayFrom(exitDirection);
            grid = room.getTilesForRender();
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


            room.RenderTreasures();
            room.RenderEnemies();
            p1.Render();

        }

        public override void Update()
        {

            around = new Tiles[3, 3];



                for (int y = 0; y < around.GetLength(1); y++)
                {
                    for (int x = 0; x < around.GetLength(0); x++)
                    {
                        try
                        {
                            around[x, y] = grid[p1.getMazeX() - (1 - x), p1.getMazeY() - (1 - y)];
                        }
                        catch (Exception e)
                        {
                            around[x, y] = Tiles.FLOOR;
                        }

                    }
                }

                p1.Update(around);

                p1.pickUpMoney(room.isTreasureAt(p1.getMazeX(), p1.getMazeY()));
                room.clearTreasures();



                Tiles playerPos = grid[p1.getMazeX(), p1.getMazeY()];
                Direction d = p1.getDirection();

                if (playerPos == Tiles.PASSAGE)
                {
                    if (room.getPassage(d).isExit)
                    {
                        Console.WriteLine("YOU FINISHED THE GAME");
                    }
                    else
                    {
                        switchRoom(maze.getRoom(room.getPassage(d).getConnection()), room.getPassage(d).getExitDirection());
                    }
                }

            if (!p1.moving)
            {
                p1.Hit(room.UpdateEnemies(p1.getMazeX(), p1.getMazeY()));
                p1.setMoving();
            }




            if (InputHandler.isZoomIn())
            {
                zoom += 0.1f;
            }

            if (InputHandler.isZoomOut())
            {
                zoom -= 0.1f;
            }

            cam.Update(p1.getCameraTransform(zoom), zoom);
        }

        

        public override iGameState switchTo()
        {
            return null;
        }

        public override void RenderOverlay()
        {
            //for (int y = 0; y < around.GetLength(1); y++)
            //{
            //    for (int x = 0; x < around.GetLength(0); x++)
            //    {
            //        switch (around[x, y])
            //        {
            //            case Tiles.FLOOR:
            //                floor.Draw(16 * x, 16 * y);
            //                break;
            //            case Tiles.WALL:
            //                wall.Draw(16 * x, 16 * y);
            //                break;
            //            case Tiles.PASSAGE:
            //                passage.Draw(16 * x, 16 * y);
            //                break;
            //        }
            //    }

            //}

            UIMoney.Draw(ConfigSettings.iResWidth - 80, ConfigSettings.iResHeight - 50);
        }
    }
}
