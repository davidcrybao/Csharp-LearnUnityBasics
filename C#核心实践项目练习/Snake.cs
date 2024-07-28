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
        int eatCount;
        MoveDir moveDir;
        public Snake(int x, int y)
        {
            snakeBodies = new SnakeBody[200];
            snakeBodies[0] = new SnakeBody(BodyType.Head, x, y);
            moveDir = MoveDir.Right;
            eatCount = 1;
            foodManager = new FoodManager();
            foodManager.GenerateFood(this);
            foodManager.GenerateFood(this);
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

            /*   for (int i = 0; i < foodManager.foods.Length; i++)
               {
                   if (snakeBodies[0].position == foodManager.foods[i].position)
                   {
                       Eat();
                       foodManager.foods[i].position = new Position(0, 0);
                       break;
                   }
               }
   */
            //错误的代码 实际上是不需要的
            // foodManager.foods[foodManager.currentFoodCount].Draw();
            //判断移动之后的位置是否 
            for (int i = 0; i <foodManager.currentFoodCount; i++)
            {
                if (snakeBodies[0].position == foodManager.foods[i].position)
                {
                    Eat(i);
                    break;
                }
            }


            // 移动蛇身体的位置
            for (int i = eatCount - 1; i > 0; i--)
            {
                snakeBodies[i].position = snakeBodies[i - 1].position;
            }
            // 更新头部位置
            snakeBodies[0].position += (x, y);


        }
        public void Eat(int foodIndex)
        {

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

            eatCount++;
            foodManager.RemoveFoodAt(foodIndex);
            foodManager.GenerateFood(this);


        }

        /// <summary>
        /// 判断与一个位置是否重合
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
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

            //头跟墙壁碰撞  不用去遍历墙壁数组
            Position snakeHead = snakeBodies[0].position;
            if (snakeHead.x > width | snakeHead.x < 2)
            {
                return true;
            }
            else if (snakeHead.y > height || snakeHead.y < 1)
            {
                return true;
            }

            //头跟身体碰撞 当身体>4的时候 (默认是1);
            if (eatCount > 4)
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

        public void Clear()
        {
            //清除头尾即可,不需要遍历循环-----擦除屁股就行了....
            // snakeBodies[0].Clear();
            snakeBodies[eatCount - 1].Clear();

        }
    }
}
