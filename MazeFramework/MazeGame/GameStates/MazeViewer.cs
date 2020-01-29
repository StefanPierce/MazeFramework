using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework
{

    class MazeViewer : iGameState
    {
        int x = 100;
        Texture2D sprite;
        public MazeViewer()
        {

        }
        public override void Load()
        {
            sprite = ContentLoader.LoadTexture("Sprites/Player/Front.png");
        }

        public override void Render()
        {

            GL.Begin(PrimitiveType.Quads);

            GL.Color4(Color4.White);

        }

        public override void RenderOverlay()
        {
        }

        public override iGameState switchTo()
        {
            return null;
        }

        public override void Update()
        {
            
        }
    }
}
