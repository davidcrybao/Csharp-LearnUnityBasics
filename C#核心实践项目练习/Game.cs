using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_核心实践项目练习
{
    enum Game_State
    {
        start,
        gaming,
        end,
    }
    internal class Game
    {
        public const int height = 20;
        public const int width = 70;

        public static ISceneUpdate nowScene;


        public Game()
        {
            Initialize();
        }
        public void Start()
        {

            while (true)
            {
                nowScene?.Update();
            }
        }
        public void Initialize()

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
                case Game_State.start:
                    nowScene = new GameStartScene();
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
