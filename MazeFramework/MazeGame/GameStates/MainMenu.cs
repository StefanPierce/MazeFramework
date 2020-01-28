using MazeFramework.MazeGame.GameStates;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFramework
{
    class MainMenu : iGameState
    {

        Texture2D background;
        Texture2D title;
        Texture2D startbutton;
        Texture2D exitButton;
        Texture2D configButton;
        Texture2D marker;

        iGameState nextScene = null;

        int selected = 0;
        public override void Load()
        {
            background = ContentLoader.LoadTexture("Sprites/Menu/Background.png");

            title = ContentLoader.LoadTexture("Sprites/Menu/Title.png");
            startbutton = ContentLoader.LoadTexture("Sprites/Menu/Start.png");
            exitButton = ContentLoader.LoadTexture("Sprites/Menu/Exit.png");
            configButton = ContentLoader.LoadTexture("Sprites/Menu/Configure.png");
            marker = ContentLoader.LoadTexture("Sprites/Menu/Marker.png");

        }

        public override void Render()
        {
            background.Draw(0,0);

            title.Draw(20, 100);
            startbutton.Draw(40, 70);
            configButton.Draw(40, 50);
            exitButton.Draw(40, 30);

            marker.Draw(20, 70 - (selected*20));
        }

        public void selectOption()
        {
            switch (selected)
            {
                case 0:
                    nextScene = new RoomViewer();
                    break;
                case 1:
                    nextScene = null;
                    break;
                case 2:
                    nextScene = new ExitState();
                    break;
                default:
                    nextScene = null;
                    break;
            }
            
        }

        public override iGameState switchTo()
        {
            return nextScene;
        }

        public override void Update()
        {
            if (InputHandler.playerUp())
            {
                selected = selected - 1 == -1 ? 2 : selected-1;
            }
            if (InputHandler.playerDown())
            {
                selected = selected + 1 == 3 ? 0 : selected + 1;
            }
            if (InputHandler.playerSelect())
            {
                selectOption();
            }
        }
    }
}
