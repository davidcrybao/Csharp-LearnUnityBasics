using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_核心实践项目练习
{
    internal class Map : IDraw
    {
        public Wall[] walls;
        public int currentWallNumber = 0;

        public Map()
        {
            int count = Game.width + Game.height * 2 - 2;
            walls = new Wall[count];

            for (int i = 0; i < Game.width; i += 2)
            {
                walls[currentWallNumber] = new Wall(i, 0);
                currentWallNumber++;
            }


            for (int i = 0; i < Game.width; i += 2)
            {
                walls[currentWallNumber] = new Wall(i, Game.height - 1);
                currentWallNumber++;
            }

            for (int i = 1; i < Game.height; i++)
            {
                walls[currentWallNumber] = new Wall(0, i);
                currentWallNumber++;
            }

            for (int i = 1; i < Game.height; i++)
            {
                walls[currentWallNumber] = new Wall(Game.width - 2, i);
                currentWallNumber++;
            }
        }

        public void Draw()
        {
            for (int i = 0; i < walls.Length; i++)
            {
                walls[i].Draw();
            }
        }
    }
}
