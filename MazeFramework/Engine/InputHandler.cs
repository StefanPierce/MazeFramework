using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework
{
    class InputHandler
    {
        static KeyboardState state = Keyboard.GetState();
        static KeyboardState prevState = state;


        public static void updateState()
        {
            prevState = state;
            state = Keyboard.GetState();
        }


        public static Boolean fullScreen()
        {
            if ((state.IsKeyDown(Key.AltLeft) && state.IsKeyDown(Key.Enter)))
            {
                if ((prevState.IsKeyDown(Key.AltLeft) && prevState.IsKeyDown(Key.Enter)))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public static Boolean playerSelect()
        {
            if (state.IsKeyDown(Key.Enter))
            {
                if (prevState.IsKeyDown(Key.Enter))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
        public static Boolean playerLeft()
        {
            if (state.IsKeyDown(Key.A))
            {
                if (prevState.IsKeyDown(Key.A))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public static Boolean playerRight()
        {
            if (state.IsKeyDown(Key.D))
            {
                if (prevState.IsKeyDown(Key.D))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public static Boolean playerUp()
        {
            if (state.IsKeyDown(Key.W))
            {
                if (prevState.IsKeyDown(Key.W))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;

        }

        public static Boolean playerDown()
        {
            if (state.IsKeyDown(Key.S))
            {
                if (prevState.IsKeyDown(Key.S))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;

        }

    }
}
