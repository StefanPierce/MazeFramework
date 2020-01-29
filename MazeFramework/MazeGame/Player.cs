using MazeFramework.Engine;
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
        int globalX;
        int globalY;
        Direction direction;

        Boolean moving = false;

        public Player()
        {
            up = ContentLoader.LoadTexture("Sprites/Player/Up.png");
            down = ContentLoader.LoadTexture("Sprites/Player/Down.png");
            left = ContentLoader.LoadTexture("Sprites/Player/Left.png");
            right = ContentLoader.LoadTexture("Sprites/Player/Right.png");

            current = up;
            direction = Direction.NORTH;
        }

        public void setFaceAwayFrom(Direction d)
        {
            switch (d)
            {
                case Direction.NORTH:
                    direction = Direction.SOUTH;
                    current = down;
                    break;
                case Direction.EAST:
                    direction = Direction.WEST;
                    current = left;
                    break;
                case Direction.SOUTH:
                    direction = Direction.NORTH;
                    current = up;
                    break;
                case Direction.WEST:
                    direction = Direction.EAST;
                    current = down;
                    break;
            }
        }
        public void Move(int x, int y)
        {
            this.x += x;
            this.y += y;
        }

        public void Render(int size)
        {
            current.Draw(globalX, globalY);

            
        }

        public Vector2 getCameraTransform(int size)
        {
            return new Vector2((globalX - ConfigSettings.iResWidth / 2)+current.width/2, (globalY- ConfigSettings.iResHeight / 2)+current.height/2);
        }

        public int getGlobalX(int s)
        {
            return x * s;
        }

        public int getGlobalY(int s)
        {
            return y * s;
        }

        public int getMazeX()
        {
            return x;
        }

        public int getMazeY()
        {
            return y;
        }

        public void setPos(Vector2 vec)
        {
            x = (int)vec.X;
            y = (int)vec.Y;
            globalX = getGlobalX(16);
            globalY = getGlobalY(16);
        }

        public void Update()
        {
            if(globalX != getGlobalX(16) || globalY!= getGlobalY(16))
            {
                if (globalX < getGlobalX(16))
                {
                    globalX++;
                }
                else if (globalX > getGlobalX(16))
                {
                    globalX--;
                }

                if (globalY < getGlobalY(16))
                {
                    globalY++;
                }
                else if (globalY > getGlobalY(16))
                {
                    globalY--;
                }
            }
            
            else
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
}
