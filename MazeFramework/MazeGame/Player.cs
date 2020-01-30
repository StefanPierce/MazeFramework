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

        int wealth = 100;

        int tileSize = 16;

        public Boolean moving { get; private set; } = true;

        public Player()
        {
            up = ContentLoader.LoadTexture("Sprites/Player/Up.png");
            down = ContentLoader.LoadTexture("Sprites/Player/Down.png");
            left = ContentLoader.LoadTexture("Sprites/Player/Left.png");
            right = ContentLoader.LoadTexture("Sprites/Player/Right.png");

            current = up;
            direction = Direction.NORTH;

            
        }

        public void setMoving()
        {
            moving = true;
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

        public void Render()
        {
            current.Draw(globalX, globalY);

            
        }

        public Vector2 getCameraTransform(float scale)
        {
            return new Vector2((globalX - ConfigSettings.iResWidth / (2*scale))+current.width/2, (globalY- ConfigSettings.iResHeight / (2*scale))+current.height/2);
        }

        public int getGlobalX()
        {
            return x * tileSize;
        }

        public int getGlobalY()
        {
            return y * tileSize;
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
            globalX = getGlobalX();
            globalY = getGlobalY();
        }

        public void Hit(int damage)
        {
            wealth -= damage;
            Console.WriteLine(wealth);
        }

        public void Update(Tiles[,] around)
        {
            if (globalX != getGlobalX() || globalY != getGlobalY())
            {
                if (globalX < getGlobalX())
                {
                    globalX++;
                }
                if (globalX > getGlobalX())
                {
                    globalX--;
                }

                if (globalY < getGlobalY())
                {
                    globalY++;
                }
                if (globalY > getGlobalY())
                {
                    globalY--;
                }
            }
            else
            {
                if (moving)
                {
                    if (InputHandler.playerUp())
                    {
                        if (direction == Direction.NORTH && around[1, 2] != Tiles.WALL)
                        {
                            y += 1;
                            moving = false;
                        }
                        direction = Direction.NORTH;
                        current = up;
                    }
                    if (InputHandler.playerDown())
                    {
                        if (direction == Direction.SOUTH && around[1, 0] != Tiles.WALL)
                        {
                            y -= 1;
                            moving = false;
                        }
                        else
                        {

                        }
                        direction = Direction.SOUTH;
                        current = down;
                    }
                    if (InputHandler.playerLeft())
                    {
                        if (direction == Direction.WEST && around[0, 1] != Tiles.WALL)
                        {
                            x -= 1;
                            moving = false;

                        }
                        direction = Direction.WEST;
                        current = left;
                    }
                    if (InputHandler.playerRight())
                    {
                        if (direction == Direction.EAST && around[2, 1] != Tiles.WALL)
                        {
                            x += 1;
                            moving = false;
                        }
                        direction = Direction.EAST;
                        current = right;
                    }
                }
                
            }

            
        }

        internal void pickUpMoney(int v)
        {
            wealth += v;
        }

        internal Direction getDirection()
        {
            return direction;
        }
    }
}
