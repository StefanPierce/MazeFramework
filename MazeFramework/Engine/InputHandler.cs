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

        private static int up, down, left, right = 0;


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
                if (prevState.IsKeyDown(Key.A)&&left < 20)
                {
                    left++;
                    return false;
                }
                else
                {
                    left = 0;
                    return true;
                }
            }
            left = 0;
            return false;
        }

        public static Boolean playerRight()
        {
            if (state.IsKeyDown(Key.D))
            {
                if (prevState.IsKeyDown(Key.D)&&right<20)
                {
                    right++;
                    return false;
                }
                else
                {
                    right = 0;
                    return true;
                }
            }
            right = 0;
            return false;
        }

        public static Boolean playerUp()
        {
            if (state.IsKeyDown(Key.W))
            {
                if (prevState.IsKeyDown(Key.W)&&up<20)
                {
                    up++;
                    return false;
                }
                else
                {
                    up = 0;
                    return true;
                }
            }
            up = 0;
            return false;

        }

        public static Boolean playerDown()
        {
            if (state.IsKeyDown(Key.S))
            {
                if (prevState.IsKeyDown(Key.S)&&down < 20)
                {
                    down++;
                    return false;
                }
                else
                {
                    down = 0;
                    return true;
                }
            }
            down = 0;
            return false;

        }

    }
}
