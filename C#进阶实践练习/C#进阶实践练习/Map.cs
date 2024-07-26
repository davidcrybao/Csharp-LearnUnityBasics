using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace C_进阶实践练习
{
    internal class Map : IDraw
    {
        public Wall[] walls;
        public int currentWallIndex = 0;
        public Wall[] dynamicWalls;
        public int dynWallNumber = 0;

        public Dictionary<int, int> perCubes = new Dictionary<int, int>();

        public Map()
        {
            int count = (GameManager.height-2) * 2 +GameManager.width/2;
            walls = new Wall[count];
            dynamicWalls = new Wall[200];
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

            for (int i = 0; i < dynWallNumber; i++)
            {
                dynamicWalls[i].Draw();
            }
        }

        public void Add()
        {


            if (perCubes.ContainsKey(1))
            {

            }
            else
            {

            }
        }

        public void Check()
        {
            if (perCubes[1]== (GameManager.width / 2))
            {
                Clear();
            }
        
        }
        public void Clear()
        { 
            //是不是都要有个Int yIndex;
           //我们移除这一行的方块,然后清空这一行的内容,然后把上面的全部东西的y-1?

        }
    }
}
