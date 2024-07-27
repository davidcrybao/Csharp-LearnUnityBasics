using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_进阶实践练习
{
    internal class GameEndScene : GameBeginOrEndScene
    {
        public GameEndScene()
        {
            title = "游戏结束了";
            firstOption = "回到主菜单";
        }

        public override void Choose()
        {
            if (currentChoice == 0)
            {
                GameManager.SwitchScene(Game_State.begin);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
