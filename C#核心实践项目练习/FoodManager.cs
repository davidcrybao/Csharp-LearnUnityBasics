using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_核心实践项目练习
{
    internal class FoodManager
    {
        public Food[] foods;
        public int currentFoodCount = 0;
        Random r;
        public FoodManager()
        {
            r = new Random();
            // 1~2个食物
            foods = new Food[2];

        }


        public void GenerateFood(Snake snake)
        {
            currentFoodCount++;
            Position position = GenerateAvailableRandomPosition(snake);
            if (currentFoodCount <= 1)
            {
                foods[currentFoodCount] = new Food(position.x, position.y);

            }
            else
            {
                currentFoodCount = 0;
                foods[currentFoodCount] = new Food(position.x, position.y);

            }
            foods[currentFoodCount].Draw();

        }
        public Position GenerateAvailableRandomPosition(Snake snake)
        {

            int x = r.Next(2, Game.width / 2 - 2) * 2;
            int y = r.Next(2, Game.height - 2);

            Position temp = new Position(x, y);
            //改成void 然后内循环 是不是可以更简便些?
            if (snake.CheckCollision(temp))
            {

                GenerateAvailableRandomPosition(snake);
            }
            return new Position(x, y);
            //

        }
    }
}
