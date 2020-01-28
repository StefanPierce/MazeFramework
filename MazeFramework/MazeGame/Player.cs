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
        Direction direction;

        public Player()
        {
            up = ContentLoader.LoadTexture("Sprites/Player/Up.png");
            down = ContentLoader.LoadTexture("Sprites/Player/Down.png");
            left = ContentLoader.LoadTexture("Sprites/Player/Left.png");
            right = ContentLoader.LoadTexture("Sprites/Player/Right.png");

            current = up;
            direction = Direction.NORTH;
        }

        public void Render()
        {
            current.Draw(getGlobalX(), getGlobalY());
        }

        public int getGlobalX()
        {
            return x * 16;
        }

        public int getGlobalY()
        {
            return y * 16;
        }

        public void Update()
        {


            if (InputHandler.playerUp())
            {
                if (direction == Direction.NORTH)
                {
                    y += 1;
                }
                direction = Direction.NORTH;
                current = up;
            }
            if (InputHandler.playerDown())
            {
                if (direction == Direction.SOUTH)
                {
                    y -= 1;
                }
                direction = Direction.SOUTH;
                current = down;
            }
            if (InputHandler.playerLeft())
            {
                if (direction == Direction.WEST)
                {
                    x -= 1;

                }
                direction = Direction.WEST;
                current = left;
            }
            if (InputHandler.playerRight())
            {
                if (direction == Direction.EAST)
                {
                    x += 1;

                }
                direction = Direction.EAST;
                current = right;
            }
        }

    }
}
