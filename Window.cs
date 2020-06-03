using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace WindowTest
{
    public class Window
    {
        GameWindow window;
        bool canTranslate = true;

        public Window(GameWindow window)
        {
            this.window = window;
            window.Title = "OpenTK Window Test";

            start();
        }

        void start()
        {
            window.Load += load;
            window.Resize += resize;
            window.RenderFrame += render;

            window.Run(1 / 60);
        }

        void resize(object o, EventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 perspectiveMatrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45), window.Width / window.Height, 1.0f, 1000.0f);
            GL.LoadMatrix(ref perspectiveMatrix);
            GL.MatrixMode(MatrixMode.Modelview);

            GL.End();
        }

        void render(object o, EventArgs e)
        {

            GL.Clear(ClearBufferMask.ColorBufferBit);

            if (canTranslate)
            {
                GL.Translate(0, 0, -1f);
                canTranslate = false;
            }
            //GL.Rotate(.1, 0, 0,.1);
            
            // RENDERING AND CREATING TRIANGLE
            GL.Begin(BeginMode.Triangles);

            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex2(0, .3);
            GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex2(.3, -.2);
            GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex2(-.3, -.2);

            GL.End();
            window.SwapBuffers();
        }

        void load(object o, EventArgs e)
        {
            GL.ClearColor(0f, 0f, 0f, 0f);
        }
    }
}
