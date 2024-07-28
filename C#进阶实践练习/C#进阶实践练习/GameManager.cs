using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_进阶实践练习
{
    internal enum Game_State
    {
        begin, gaming, end,
    }

    internal class GameManager
    {
        public const int height = 40;
        public const int width = 40;

        public static ISceneUpdate nowScene;

        public GameManager()
        {
            Initialize();
            SwitchScene(Game_State.begin);
        }

        public void Start()
        {
            while (true)
            {
                nowScene?.Update();
            }
        }

        private void Initialize()

        {
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            Console.CursorVisible = false;
        }

        public static void SwitchScene(Game_State game_State)
        {
            Console.Clear();
            switch (game_State)
            {
                case Game_State.begin:
                    nowScene = new GameBeginScene();
                    break;

                case Game_State.gaming:
                    nowScene = new GameScene();
                    break;

                case Game_State.end:
                    nowScene = new GameEndScene();
                    break;
            }
        }
    }
}