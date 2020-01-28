using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace MazeFramework.MazeGame.GameStates
{
    class HDRoomViewer : RoomViewer
    {
        public override void Render()
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    switch (grid[x, y])
                    {
                        case Tiles.FLOOR:
                            floor.Draw(32 * x, 32 * y);
                            break;
                        case Tiles.WALL:
                            wall.Draw(32 * x, 32 * y);
                            break;
                        case Tiles.PASSAGE:
                            passage.Draw(32 * x, 32 * y);
                            break;
                    }
                }

            }
            
            p1.Render(32);
        }
    }
}
