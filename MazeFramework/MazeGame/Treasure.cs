using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework.MazeGame
{

    public enum TREASURE
    {
        COIN
    }
    class Treasure : Item
    {

        public static Texture2D coin = ContentLoader.LoadTexture("Sprites/Treasures/Coin.png");

        TREASURE type;
        int value = 0;
        Texture2D texTres;
        int x;
        int y;
        int offsetX;
        int offsetY;

        int tileSize = 16;

        public bool delete { get; private set; } = false;
        public Treasure(string name, TREASURE t, int x, int y) : base(name)
        {
            type = t;

            this.x = x;
            this.y = y;

            offsetX = InputHandler.getRandom(-4, 4);
            offsetY = InputHandler.getRandom(-4, 4);

            switch (type)
            {
                case TREASURE.COIN:
                    value = 1;
                    texTres = coin;
                    break;
            }
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

        public void Render()
        {
            texTres.Draw(getGlobalX()+offsetX, getGlobalY()+offsetY);
        }

        public int pickUp()
        {
            delete = true;
            return value;
        }

    }
}
