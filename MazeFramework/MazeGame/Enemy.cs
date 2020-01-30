using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework.MazeGame
{
    enum ENEMY
    {
        ENEMY1
    }
    class Enemy : Item
    {
        int health;
        int damage = 1;
        ENEMY type;
        int x, y;
        int globalX, globalY;

        public static Texture2D enemy1 = ContentLoader.LoadTexture("Sprites/Enemies/Enemy1.png");
        private Texture2D current;
        public Enemy(string name, ENEMY e, int x, int y) : base(name)
        {
            this.x = x;
            this.y = y;
            globalX = getGlobalX();
            globalY = getGlobalY();
            type = e;

            switch (type)
            {
                case ENEMY.ENEMY1:
                    current = enemy1;
                    break;
            }
        }

        public int Update(int px, int py)
        {
            int damagePlayer = 0;

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

            if (px > x+1)
            {
                x += 1;
            }
            else if (px < x-1)
            {
                x -= 1;
            }
            else if (py > y+1)
            {
                y += 1;
            }
            else if (py < y-1)
            {
                y -= 1;
            }
            else
            {
                damagePlayer += damage;
            }

            return damagePlayer;

        }

        public void Render()
        {
            current.Draw(getGlobalX(),getGlobalY());
        }

        public int getGlobalX()
        {
            return x * 16;
        }

        public int getGlobalY()
        {
            return y * 16;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

    }
}
