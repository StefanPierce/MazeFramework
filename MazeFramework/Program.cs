using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework
{
    class Program
    {

        static GameWindow window;
        static Game game;


        static void Main(string[] args)
        {
            setupGraphics();
        }

        static void setupGraphics()
        {
            window = new GameWindow(1280, 720);
            game = new Game(window);
            window.Run();
        }
    }
}
