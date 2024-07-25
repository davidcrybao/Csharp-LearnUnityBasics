using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_进阶实践练习
{
    internal class Map : IDraw
    {
        public Wall[] walls;
        public int currentWallIndex = 0;

        public Map()
        {
            int count = (GameManager.height-2) * 2 +GameManager.width/2;
            walls = new Wall[count];

            for (int i = 0; i < GameManager.height-2; i++)
            {
                walls[currentWallIndex] = new Wall(0, i);
                currentWallIndex++;
            }

            for (int i = 0; i < GameManager.height-2; i++)
            {
                walls[currentWallIndex] = new Wall(GameManager.width-2, i);
                currentWallIndex++;
            }


            for (int i = 0; i < GameManager.width; i+=2)
            {
                walls[currentWallIndex] = new Wall(i, GameManager.height - 3);
                currentWallIndex++;
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
