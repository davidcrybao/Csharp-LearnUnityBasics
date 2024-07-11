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
        public bool hasGenerate;
        public FoodManager()
        {
            foods = new Food[1];
            hasGenerate = false;
        }
        public void GenerateFood(Position position)
        {
            if (!hasGenerate)
            {

                foods[0] = new Food(position.x, position.y);
                hasGenerate = true;
                foods[0].Draw();
            }
        }

    }
}
