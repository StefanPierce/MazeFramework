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
        int health = 100;
        ENEMY type;
        int x, y;
        int prevX, prevY;
        int globalX, globalY;
        int damage; 

        public Boolean dead { get; private set; } = false;

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
                    damage = 1;
                    break;
            }
        }

        public void MoveBack()
        {
            x = prevX;
            y = prevY;
        }

        public void Hit(int damage)
        {
            health -= damage;
            if(health < 1)
            {
                dead = true;
            }
        }

        public int Update(int px, int py)
        {
            int damagePlayer = 0;
            prevX = x;
            prevY = y;
            

            
            

            if((px == x && py - 1 == y) || (px == x && py + 1 == y) || 
                (py == y && px - 1 == x) || (py == y && px + 1 == x))
            {
                damagePlayer += damage;
            }
            else
            {
                if (px > x + 1)
                {
                    x += 1;
                    return 0;
                }

                else if (px < x - 1)
                {
                    x -= 1;
                    return 0;
                }
                else if (py > y + 1)
                {
                    y += 1;
                }
                else if (py < y - 1)
                {
                    y -= 1;
                }
            }


            return damagePlayer;

        }

        public void Render()
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

            current.Draw(globalX,globalY);
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
