using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_进阶实践练习
{
    internal class GameBeginScene:GameBeginOrEndScene
    {
        public GameBeginScene() { 
            title = "俄罗斯方块游戏";
            firstOption = "开始游戏";
        }

        public override void Choose()
        {
            if (currentChoice == 0)
            {
                GameManager.SwitchScene(Game_State.gaming);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
