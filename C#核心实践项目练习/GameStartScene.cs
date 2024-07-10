using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_核心实践项目练习
{
    internal class GameStartScene : GameEndOrStartBase
    {
        public GameStartScene()
        {
            title = "贪吃蛇";
            firstOption = "开始游戏";

        }

        public override void Choose()
        {
            if (currentChoice == 0)
            {
                Game.SwitchScene(Game_State.gaming);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
