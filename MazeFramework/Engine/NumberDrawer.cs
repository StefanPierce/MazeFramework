using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework.Engine
{
    class NumberDrawer
    {
        static List<Texture2D> numbers;

        private static void loadNumbers()
        {
            numbers = new List<Texture2D>();

            for(int i = 0; i < 10; i++)
            {
                numbers.Add(ContentLoader.LoadTexture($"Sprites/Font/{i}.png"));
            }
        }

        public static void DrawNumbers(int number, int x, int y)
        {
            if(numbers == null)
            {
                loadNumbers();
            }

            String temp = $"{number}";

            int counter = 0;
            foreach(char c in temp)
            {
                int i = int.Parse(c.ToString());
                numbers[i].Draw(x + (counter*10), y);
                counter++;
            }
        }

    }
}
