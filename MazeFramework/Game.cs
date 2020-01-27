using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework
{
    class Game
    {
        private GameWindow window;
        iGameState current;


        public Game(GameWindow window)
        {
            

            this.window = window;
            window.Load += windowLoad;
            window.UpdateFrame += windowUpdateFrame;
            window.RenderFrame += windowRenderFrame;

            window.VSync = OpenTK.VSyncMode.On;
        }

        private void windowRenderFrame(object sender, FrameEventArgs e)
        {
            current.Render();
        }

        private void windowUpdateFrame(object sender, FrameEventArgs e)
        {
            current.Update();
        }

        private void windowLoad(object sender, EventArgs e)
        {
            
        }
    }
}
