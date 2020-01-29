using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL;

namespace MazeFramework.Engine
{
    class Camera
    {
        public Vector2 position;


        public double zoom;
        //public double rotation;

        public Camera(Vector2 startPos, double startZoom)
        {
            this.position = startPos;
            this.zoom = startZoom;
        }

        public void Update(Vector2 newPos, double newZoom)
        {
            position = newPos;
            zoom = newZoom;
        }

        public void ApplyTran()
        {
            Matrix4 transform = Matrix4.Identity;
            transform = Matrix4.Mult(transform, Matrix4.CreateTranslation(-position.X, -position.Y, 0));
            transform = Matrix4.Mult(transform, Matrix4.CreateScale((float)zoom, (float)zoom, 1.0f));


            GL.MultMatrix(ref transform);
        }

    }
}
