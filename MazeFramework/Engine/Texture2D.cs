using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace MazeFramework
{

    class Texture2D
    {
        int id;
        public int width { get; }
        public int height { get; }

        public Texture2D(int id, int w, int h)
        {
            this.id = id;
            width = w;
            height = h;
        }

        public void Draw(int x, int y)
        {
            

            GL.BindTexture(TextureTarget.Texture2D, id);
            GL.Begin(PrimitiveType.Quads);

            GL.Color4(Color4.White);

            GL.TexCoord2(0, 0);
            GL.Vertex2(0 + x, 0+y);
            
            GL.TexCoord2(1, 0);
            GL.Vertex2(width + x, 0 + y); 
            
            GL.TexCoord2(1, 1);
            GL.Vertex2(width + x, height + y); 
           
            GL.TexCoord2(0, 1);
            GL.Vertex2(0 + x, height + y);
            
            GL.End();
        }
    }
}
