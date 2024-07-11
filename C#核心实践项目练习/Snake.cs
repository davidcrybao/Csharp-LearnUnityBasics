using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_核心实践项目练习
{
    enum MoveDir
    {
        Up, Down, Left, Right
    }
    internal class Snake : IDraw
    {
        SnakeBody[] snakeBodies;
        int eatCount;
        MoveDir moveDir;
        public Snake(int x, int y)
        {
            snakeBodies = new SnakeBody[200];
            snakeBodies[0] = new SnakeBody(BodyType.Head, x, y);
            moveDir = MoveDir.Right;
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

            int x = 0;
            int y = 0;
            snakeBodies[0].Clear();
            switch (moveDir)
            {
                case MoveDir.Up:
                    y = -1; x = 0;
                    break;
                case MoveDir.Down:
                    y = 1; x = 0;
                    break;
                case MoveDir.Left:
                    x = -2; y = 0;
                    break;
                case MoveDir.Right:
                    x = 2; y = 0;
                    break;
            }

            //移动的范围限制


            //开始改变所有的坐标
            for (int i = 0; i < eatCount; i++)
            {
                snakeBodies[i].position += (x, y);


            }
        }

        public bool CheckCollision()
        {
            int width = Game.width - 4;
            int height = Game.height - 2;

            //头跟墙壁碰撞
            Position snakeHead = snakeBodies[0].position;
            if (snakeHead.x > width | snakeHead.x < 2)
            {
                return true;
            }
            else if (snakeHead.y > height || snakeHead.y < 1)
            {
                return true;
            }

            //头跟身体碰撞
            if (eatCount >= 3)
            {
                for (int i = eatCount; i > 2; i--)
                {
                    if (snakeBodies[i].position == snakeHead)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public void ChangeDir(MoveDir moveDir)
        {
            if (this.moveDir == moveDir ||
                eatCount > 1 &&
                (this.moveDir == MoveDir.Left && moveDir == MoveDir.Right) ||
                 (this.moveDir == MoveDir.Right && moveDir == MoveDir.Left) ||
                  (this.moveDir == MoveDir.Up && moveDir == MoveDir.Down) ||
                  (this.moveDir == MoveDir.Down && moveDir == MoveDir.Up)
                )
            {
                return;
            }
            this.moveDir = moveDir;
        }

        /*   public void Move()
           {
               while (true)
               {
                   ConsoleKey input = Console.ReadKey(true).Key;
                   //Clear();
                   SnakeBody lastBody = snakeBodies[eatCount - 1];
                   lastBody.Clear();
                   ReSetPosition(input);

                   Draw();
               }
           }
   */


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

            int width = Game.width - 4;
            int height = Game.height - 2;

            //这样会出现一个问题,身体越来越小,直接加个return?
            for (int i = 0; i < eatCount; i++)
            {
                snakeBodies[i].position += (x, y);
                if (snakeBodies[i].position.x > width || snakeBodies[i].position.x < 2)
                {
                    snakeBodies[i].position -= (x, 0);
                    return;
                }
                else if (snakeBodies[i].position.y > height || snakeBodies[i].position.y < 1)
                {
                    snakeBodies[i].position -= (0, y);
                    return;
                }

            }

        }
        public void Clear()
        {
            for (int i = 0; i < eatCount; i++)
            {
                snakeBodies[0].Clear();
            }
        }
    }
}
