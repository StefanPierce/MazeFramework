using MazeFramework.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework.MazeGame.GameStates
{
    class FinishState : iGameState
    {
        iGameState next = null;
        Texture2D screen;
        int score;

        public FinishState(int score)
        {
            this.score = score;
            Console.WriteLine($"YOU HAD THIS MUCH MONEY: {score}");
            
            if(score < 0)
            {
                screen = ContentLoader.LoadTexture("Sprites/Menu/Death.png");
            }
            else
            {
                screen = ContentLoader.LoadTexture("Sprites/Menu/Win.png");
            }

        }
        public override void Load()
        {
        }

        public override void Render()
        {
            screen.Draw(0, 0);
            if(score>= 0)
            {
                NumberDrawer.DrawNumbers(score, ConfigSettings.iResWidth - 50, ConfigSettings.iResHeight - 50);

            }
        }

        public override void RenderOverlay()
        {
        }

        public override iGameState switchTo()
        {
            return next;
        }

        public override void Update()
        {
            if (InputHandler.playerSelect())
            {
                next = new RoomViewer();

            }
        }
    }
}
