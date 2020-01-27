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

        public RoomViewer()
        {
            room = new Room();
            floor = ContentLoader.LoadTexture("Sprites/Room1/Floor.png");
            wall = ContentLoader.LoadTexture("Sprites/Room1/Wall.png");

            p1 = new Player();
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
            p1.Update();
        }
    }
}
