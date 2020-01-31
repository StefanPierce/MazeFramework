using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework.MazeGame
{
    class RedCoin : Item
    {
        int x, y;
        int offsetX, offsetY;

        static Texture2D coin = ContentLoader.LoadTexture("Sprites/Treasures/RedCoin.png");
        public RedCoin(string name, int x, int y) : base(name)
        {
            

            this.x = x;
            this.y = y;

            offsetX = InputHandler.getRandom(-4, 4);
            offsetY = InputHandler.getRandom(-4, 4);

            
        }

        public void Render()
        {
            coin.Draw((x*16) + offsetX, (y*16) + offsetY);
        }
    }
}
