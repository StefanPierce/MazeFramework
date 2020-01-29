using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework
{
    abstract class iGameState
    {
        public abstract void Load();
        public abstract void Update();
        public abstract void Render();

        public abstract void RenderOverlay();
        public abstract iGameState switchTo();
    }
}
