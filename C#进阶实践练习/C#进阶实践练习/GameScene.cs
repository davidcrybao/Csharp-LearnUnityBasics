using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_进阶实践练习
{
    internal class GameScene : ISceneUpdate
    {
        Map map;
        public GameScene()
        {
            map = new Map();
        }
        public void Update()
        {
            map.Draw();
        }
    }
}
