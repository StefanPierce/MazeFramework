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

            current = new RoomViewer();
        }

        private void windowRenderFrame(object sender, FrameEventArgs e)
        {
           

            
            GL.ClearColor(Color4.blac);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            current.Render();




            window.SwapBuffers();
        }

        private void windowUpdateFrame(object sender, FrameEventArgs e)
        {
            current.Update();
        }

        private void windowLoad(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.Ortho(0, 400, 0, 224, -1, 1);
            GL.Enable(EnableCap.Texture2D);

            current.Load();
        }
    }
}
