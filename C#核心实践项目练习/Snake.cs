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
        FoodManager foodManager;
        Random r;
        int eatCount;
        MoveDir moveDir;
        public Snake(int x, int y)
        {
            snakeBodies = new SnakeBody[200];
            snakeBodies[0] = new SnakeBody(BodyType.Head, x, y);
            moveDir = MoveDir.Right;
            eatCount = 1;
            foodManager = new FoodManager();
            r = new Random();
            foodManager.GenerateFood(AvailablePosition());
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
            if (snakeBodies[0].position == foodManager.foods[0].position)
            {
                Eat();
            }

            //倒序来完成会更好
            for (int i = eatCount - 1; i > 0; i--)
            {
                snakeBodies[i].position = snakeBodies[i - 1].position;
            }
            snakeBodies[0].position += (x, y);

            //跟着头移动  改变思维 后一个位置的坐标等于前面位置的坐标


        }
        public void Eat()
        {
            //等待修改TODO
            //坐标有问题 我们是在最后一个的后面增加一个 是否需要判断上下左右?



            switch (moveDir)
            {
                case MoveDir.Up:
                    snakeBodies[eatCount] = new SnakeBody(BodyType.Body,
              snakeBodies[eatCount - 1].position.x, snakeBodies[eatCount - 1].position.y + 1);
                    break;
                case MoveDir.Down:
                    snakeBodies[eatCount] = new SnakeBody(BodyType.Body,
            snakeBodies[eatCount - 1].position.x, snakeBodies[eatCount - 1].position.y - 1);
                    break;
                case MoveDir.Left:
                    snakeBodies[eatCount] = new SnakeBody(BodyType.Body,
            snakeBodies[eatCount - 1].position.x + 2, snakeBodies[eatCount - 1].position.y);
                    break;
                case MoveDir.Right:
                    snakeBodies[eatCount] = new SnakeBody(BodyType.Body,
snakeBodies[eatCount - 1].position.x - 2, snakeBodies[eatCount - 1].position.y);
                    break;
            }

            //重新生成食物
            foodManager.hasGenerate = false;
            foodManager.GenerateFood(AvailablePosition());
            eatCount++;
        }
        public Position AvailablePosition()
        {
            bool isAvailable = true;
            Position temp = new Position();
            do
            {
                temp = GenerateRandomPosition();
                isAvailable = CheckCollision(temp);

            } while (isAvailable);
            return temp;

        }
        public Position GenerateRandomPosition()
        {
            int x = r.Next(2, Game.width / 2 - 2) * 2;
            int y = r.Next(2, Game.height - 2);
            return new Position(x, y);
        }
        public bool CheckCollision(Position position)
        {

            for (int i = 0; i < eatCount; i++)
            {
                if (snakeBodies[i].position == position)
                {
                    return true;
                }
            }

            return false;
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
            if (eatCount >= 4)
            {
                for (int i = eatCount - 1; i > 3; i--)
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
                snakeBodies[i].Clear();
            }
        }
    }
}
