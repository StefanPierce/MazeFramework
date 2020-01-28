using OpenTK;
using System;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeFramework.MazeGame.GameStates;

namespace MazeFramework
{
    class Game
    {
        private GameWindow window;
        iGameState current;

        int x, y;
        public Game(GameWindow window)
        {
            x = 0;
            x = 0;

            this.window = window;
            window.Load += windowLoad;
            window.UpdateFrame += windowUpdateFrame;
            window.RenderFrame += windowRenderFrame;

            window.VSync = OpenTK.VSyncMode.On;

            current = new MainMenu();
        }

        private void windowRenderFrame(object sender, FrameEventArgs e)
        {

            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);

            GL.ClearColor(Color4.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            

            current.Render();




            window.SwapBuffers();
        }

        private void windowUpdateFrame(object sender, FrameEventArgs e)
        {
            InputHandler.updateState();
            current.Update();

            if (current.switchTo() != null)
            {
                current = current.switchTo();
                current.Load();
                if(current is ExitState)
                {
                    window.Close();
                }
            }

        }

        private void windowLoad(object sender, EventArgs e)
        {
            
            GL.Enable(EnableCap.Texture2D);
            GL.Ortho(0, 400, 0, 224, -1, 1);

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            current.Load();
        }
    }
}
