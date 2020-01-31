using OpenTK;
using System;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeFramework.MazeGame.GameStates;
using MazeFramework.Engine;

namespace MazeFramework
{
    class Game
    {
        private GameWindow window;
        iGameState current;

        //Link render and update functions and create the main menu
        public Game(GameWindow window)
        {
            ConfigSettings.loadConfig();

            this.window = window;
            window.Load += windowLoad;
            window.UpdateFrame += windowUpdateFrame;
            window.RenderFrame += windowRenderFrame;

            window.VSync = OpenTK.VSyncMode.On;

            current = new MainMenu();
        }

        //Open GL calls to set up renderer, then call the current state render function
        private void windowRenderFrame(object sender, FrameEventArgs e)
        {
            GL.LoadIdentity();

            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.Ortho(0, ConfigSettings.iResWidth, 0, ConfigSettings.iResHeight, -1, 1);

            GL.ClearColor(Color4.Black);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            current.Render();

            GL.LoadIdentity();
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.Ortho(0, ConfigSettings.iResWidth, 0, ConfigSettings.iResHeight, -1, 1);

            current.RenderOverlay();

            window.SwapBuffers();
        }

        //Update input handler, then the current state, and then check if new state should be loaded
        private void windowUpdateFrame(object sender, FrameEventArgs e)
        {
            InputHandler.updateState();

            if (InputHandler.fullScreen())
            {
                if(window.WindowState == WindowState.Fullscreen)
                {
                    window.WindowState = WindowState.Normal;
                }
                else
                {
                    window.WindowState = WindowState.Fullscreen;
                }
            }

            current.Update();

            if (current.switchTo() != null)
            {
                current = current.switchTo();
                current.Load();
                if (current is ExitState)
                {
                    window.Close();
                }
            }
        }

        //initial loading of the window, set ortho view and enable transparency on images
        private void windowLoad(object sender, EventArgs e)
        {

            GL.Enable(EnableCap.Texture2D);
            GL.Ortho(0, ConfigSettings.iResWidth, 0, ConfigSettings.iResHeight, -1, 1);

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            
            current.Load();
        }
    }
}
