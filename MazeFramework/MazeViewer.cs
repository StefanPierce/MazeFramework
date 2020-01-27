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
        public MazeViewer()
        {

        }
        public override void Load()
        {
        }

        public override void Render()
        {

            GL.Begin(PrimitiveType.Quads);

            GL.Color4(Color4.White);

            GL.Vertex2(0,0);
            GL.Vertex2(0,1);
            GL.Vertex2(1,1);
            GL.Vertex2(1,0);
            GL.End();


        }

        public override void Update()
        {
        }
    }
}
