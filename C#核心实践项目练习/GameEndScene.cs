using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_核心实践项目练习
{
    internal class GameEndScene : GameEndOrStartBase
    {
        public GameEndScene()
        {
            title = "游戏结束";
            firstOption = "回到开始界面";

        }

        public override void Choose()
        {
            if (currentChoice == 0)
            {
                Game.SwitchScene(Game_State.start);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
