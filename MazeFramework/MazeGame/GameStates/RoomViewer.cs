﻿using MazeFramework.Engine;
using MazeFramework.MazeGame.GameStates;
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

        iGameState nextScene = null;

        public RoomViewer()
        {
            

            floor = ContentLoader.LoadTexture("Sprites/Room1/Floor.png");
            wall = ContentLoader.LoadTexture("Sprites/Room1/Wall.png");
            passage = ContentLoader.LoadTexture("Sprites/Room1/Passage.png");

            UIMoney = ContentLoader.LoadTexture("Sprites/Treasures/UI.png");

            maze = new Maze(ConfigSettings.roomCount);
            maze.GenerateTreasures();
            maze.GenerateEnemies();
            room = maze.getRoom(InputHandler.getRandom(0, ConfigSettings.roomCount-1));
            Console.WriteLine(room.roomID);

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
                        case Tiles.FAKEPASSAGE:
                            passage.Draw(16 * x, 16 * y);
                            break;
                    }
                }

            }


            room.RenderTreasures();
            room.RenderEnemies();
            room.RenderRedCoins();
            p1.Render();

        }

        public override void Update()
        {
            //Collect the tiles that are currently around the player
            around = new Tiles[3, 3];
            for (int y = 0; y < around.GetLength(1); y++)
            {
                for (int x = 0; x < around.GetLength(0); x++)
                {
                    try
                    {
                        around[x, y] = grid[p1.getMazeX() - (1 - x), p1.getMazeY() - (1 - y)];
                    }
                    catch (Exception)
                    {
                        around[x, y] = Tiles.FLOOR;
                    }

                }
            }

            //update player and return the amount of damage the player is dealing
            int damage = p1.Update(around);

            //pick up any money the player is standing on
            p1.pickUpMoney(room.isTreasureAt(p1.getMazeX(), p1.getMazeY()));
            
            //damage = -1 means the player wants to drop a red coin
            if(damage == -1)
            {
                room.dropCoin(p1.x, p1.y);
            }
            else
            {
                //damage enemies based on damage and where the player is looking
                room.HitEnemies(damage, p1.lookingAt());
            }

            //delete killed enemies or picked up treasures
            room.ClearEnemies();
            room.clearTreasures();



            //if player is standing on a passage send him to the new room
            Tiles playerPos = grid[p1.getMazeX(), p1.getMazeY()];
            Direction d = p1.getDirection();

            if (playerPos == Tiles.PASSAGE)
            {
                if (room.getPassage(d).isExit)
                {
                    //if the passage is marked as isExit, load the end of the game state
                    nextScene = new FinishState(p1.wealth);
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

            if(p1.wealth < 0)
            {
                nextScene = new FinishState(p1.wealth);
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
            return nextScene;
        }

        public override void RenderOverlay()
        {
            UIMoney.Draw(ConfigSettings.iResWidth - 80, ConfigSettings.iResHeight - 50);
            NumberDrawer.DrawNumbers(p1.wealth, ConfigSettings.iResWidth - 80, ConfigSettings.iResHeight - 50);

        }
    }
}
