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

        public GameScene()
        {
            map = new Map();
            snake = new Snake(20, 10);

        }

        public void Update()
        {
            map.Draw();
            snake.Draw();
            snake.Move();

        }
    }
}
