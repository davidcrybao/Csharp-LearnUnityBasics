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

        //用List更好些?
        private List<DrawObject> walls = new List<DrawObject>();
        public List<DrawObject> dynamicWalls = new List<DrawObject>();


        public Dictionary<int, int> perCubes = new Dictionary<int, int>();

        public Map()
        {
            int count = (GameManager.height-2) * 2 +GameManager.width/2;
            for (int i = 0; i < GameManager.height-2; i++)
            {
                walls.Add(new DrawObject(0, i,E_CubeTypes.Wall));
            }
            for (int i = 0; i < GameManager.height-2; i++)
            {
                walls.Add( new DrawObject(GameManager.width-2, i, E_CubeTypes.Wall));
            }
            for (int i = 0; i < GameManager.width; i+=2)
            {
                walls.Add(new DrawObject(i, GameManager.height - 3, E_CubeTypes.Wall));
            }
        }

        public void Draw()
        {
            for (int i = 0; i < walls.Count; i++)
            {
                walls[i].Draw();
            }

            for (int i = 0; i < dynamicWalls.Count; i++)
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
