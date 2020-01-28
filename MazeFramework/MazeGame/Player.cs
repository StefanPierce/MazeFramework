using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework
{
    class Player
    {
        Texture2D up, down, left, right;
        Texture2D current;
        public int x;
        public int y;
        public Player()
        {
            up = ContentLoader.LoadTexture("Sprites/Player/Up.png");
            down = ContentLoader.LoadTexture("Sprites/Player/Down.png");
            left = ContentLoader.LoadTexture("Sprites/Player/Left.png");
            right = ContentLoader.LoadTexture("Sprites/Player/Right.png");

            current = up;
        }

        public void Render()
        {
            current.Draw(x, y);
        }

        public void Update()
        {


            if (InputHandler.playerUp())
            {
                y += 1;
                current = up;
            }
            if (InputHandler.playerDown())
            {
                y -= 1;
                current = down;
            }
            if (InputHandler.playerLeft())
            {
                x -= 1;
                current = left;
            }
            if (InputHandler.playerRight())
            {
                x += 1;
                current = right;
            }
        }

    }
}
