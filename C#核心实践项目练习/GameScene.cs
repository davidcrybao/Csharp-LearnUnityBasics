using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_核心实践项目练习
{
    internal class GameScene : ISceneUpdate
    {
        Map map;
        Snake snake;

        int updateCount;

        public GameScene()
        {
            map = new Map();
            snake = new Snake(20, 10);

        }

        public void Update()
        {
            if (updateCount % 10000 == 0)
            {
                map.Draw();

                snake.Clear();
                snake.Move();

                snake.Draw();
                if (snake.CheckCollision())
                {
                    Game.SwitchScene(Game_State.end);
                }
                updateCount = 0;
            }
            updateCount++;

            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        snake.ChangeDir(MoveDir.Up);
                        break;
                    case ConsoleKey.S:
                        snake.ChangeDir(MoveDir.Down);
                        break;
                    case ConsoleKey.A:
                        snake.ChangeDir(MoveDir.Left);
                        break;
                    case ConsoleKey.D:
                        snake.ChangeDir(MoveDir.Right);
                        break;
                }
            }
        }
    }
}
