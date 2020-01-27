using OpenTK;
using System;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
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

            current = new MazeViewer();
        }

        private void windowRenderFrame(object sender, FrameEventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.ClearColor(Color4.Blue);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Projection);

            current.Render();




            window.SwapBuffers();
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
