using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_核心实践项目练习
{
    internal class Snake : IDraw
    {
        SnakeBody[] snakeBodies;
        int eatCount;

        public Snake(int x, int y)
        {
            snakeBodies = new SnakeBody[200];
            snakeBodies[0] = new SnakeBody(BodyType.Head, x, y);
            eatCount = 1;
        }


        public void Draw()
        {
            for (int i = 0; i < eatCount; i++)
            {
                snakeBodies[i].Draw();
            }
        }
        public void Move()
        {
            while (true)
            {
                ConsoleKey input = Console.ReadKey(true).Key;
                Clear();
                ReSetPosition(input);

                Draw();
            }
        }

        public void ReSetPosition(ConsoleKey key)
        {
            int x = 0;
            int y = 0;
            switch (key)
            {
                case ConsoleKey.W:
                    y = -1; x = 0;
                    break;
                case ConsoleKey.S:
                    y = 1; x = 0;
                    break;
                case ConsoleKey.A:
                    x = -2; y = 0;
                    break;
                case ConsoleKey.D:
                    x = 2; y = 0;
                    break;
            }

            for (int i = 0; i < eatCount; i++)
            {
                snakeBodies[i].position += (x, y);
            }

        }
        public void Clear()
        {
            for (int i = 0; i < eatCount; i++)
            {
                snakeBodies[i].Clear();
            }
        }
    }
}
