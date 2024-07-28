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
        private Random r;

        public FoodManager()
        {
            r = new Random();
            // 1~2个食物
            foods = new Food[2];
        }

        public void GenerateFood(Snake snake)
        {
            if (currentFoodCount >= foods.Length)
            {
                return; // 防止数组越界
            }
            Position position = GenerateAvailableRandomPosition(snake);

            foods[currentFoodCount] = new Food(position.x, position.y);
            foods[currentFoodCount].Draw();
            currentFoodCount++;
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
        public void RemoveFoodAt(int index)
        {
            for (int i = index; i < currentFoodCount - 1; i++)
            {
                foods[i] = foods[i + 1];
            }
            currentFoodCount--;
        }
    }
}