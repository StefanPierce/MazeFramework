using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework.MazeGame.GameStates
{
    class FinishState : iGameState
    {

        public FinishState(int score)
        {
            Console.WriteLine($"YOU HAD THIS MUCH MONEY: {score}");
        }
        public override void Load()
        {
        }

        public override void Render()
        {
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
