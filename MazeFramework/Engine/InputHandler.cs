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

        public static void updateState()
        {
            state = Keyboard.GetState();
        }

        public static Boolean playerLeft()
        {
            return state.IsKeyDown(Key.A);
        }

        public static Boolean playerRight()
        {
            return state.IsKeyDown(Key.D);

        }

        public static Boolean playerUp()
        {
            return state.IsKeyDown(Key.W);

        }

        public static Boolean playerDown()
        {
            return state.IsKeyDown(Key.S);

        }

    }
}
