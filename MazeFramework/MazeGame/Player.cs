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

        public int wealth { get; private set; } = 0;

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

        //return the x and y of where the player is looking

        public Vector2 lookingAt()
        {
            switch (direction)
            {
                case Direction.NORTH:
                    return new Vector2(x, y + 1);
                case Direction.EAST:

                    return new Vector2(x + 1, y);
                case Direction.SOUTH:

                    return new Vector2(x, y - 1);
                case Direction.WEST:

                    return new Vector2(x - 1, y);
            }

            return new Vector2();

        }

        public void setMoving()
        {
            moving = true;
        }

        //point the user away from this direction (used when entering through a door)
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

        //return a vector representing where the camera should be moved to
        public Vector2 getCameraTransform(float scale)
        {
            return new Vector2((globalX - ConfigSettings.iResWidth / (2 * scale)) + current.width / 2, (globalY - ConfigSettings.iResHeight / (2 * scale)) + current.height / 2);
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

        //set pos without the game needing to tween between the two positions
        //by setting global x and y 
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

        //Update function returns damage, this damage is then sent to an enemy if he is standing
        //where the player attacks
        public int Update(Tiles[,] around)
        {
            int deal = 0;


            //used to tween from where the character currently is to the expected grid
            //(means that they dont just jump around the map they smoothly transition)
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
                        //if where the player is looking is a wall or a passage, they cant move fowards
                        if (direction == Direction.NORTH && around[1, 2] != Tiles.WALL && around[1, 2] != Tiles.FAKEPASSAGE)
                        {
                            y += 1;
                            moving = false;
                        }

                        //if a fake passage, write to console (TODO: display in game)
                        if (around[1,2] == Tiles.FAKEPASSAGE)
                        {
                            Console.WriteLine("CANT ENTER THIS PASSAGE");
                        }
                        direction = Direction.NORTH;
                        current = up;
                    }
                    if (InputHandler.playerDown())
                    {
                        if (direction == Direction.SOUTH && around[1, 0] != Tiles.WALL && around[1, 0] != Tiles.FAKEPASSAGE)
                        {
                            y -= 1;
                            moving = false;
                        }
                        else
                        {

                        }
                        if (around[1, 0] == Tiles.FAKEPASSAGE)
                        {
                            Console.WriteLine("CANT ENTER THIS PASSAGE");
                        }
                        direction = Direction.SOUTH;
                        current = down;
                    }
                    if (InputHandler.playerLeft())
                    {
                        if (direction == Direction.WEST && around[0, 1] != Tiles.WALL && around[0, 1] != Tiles.FAKEPASSAGE)
                        {
                            x -= 1;
                            moving = false;

                        }
                        if (around[0,1] == Tiles.FAKEPASSAGE)
                        {
                            Console.WriteLine("CANT ENTER THIS PASSAGE");
                        }
                        direction = Direction.WEST;
                        current = left;
                    }
                    if (InputHandler.playerRight())
                    {
                        if (direction == Direction.EAST && around[2, 1] != Tiles.WALL && around[2, 1] != Tiles.FAKEPASSAGE)
                        {
                            x += 1;
                            moving = false;
                        }
                        if (around[2, 1] == Tiles.FAKEPASSAGE)
                        {
                            Console.WriteLine("CANT ENTER THIS PASSAGE");
                        }
                        direction = Direction.EAST;
                        current = right;
                    }
                    if (InputHandler.playerAttack())
                    {
                        moving = false;
                        deal += 100 + wealth;
                    }
                    if (InputHandler.playerSelect())
                    {
                        moving = false;
                        wealth--;
                        deal = -1;
                    }
                }

            }

            return deal;

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
