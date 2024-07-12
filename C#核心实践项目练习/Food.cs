using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_核心实践项目练习
{
    internal class Food : GameObject
    {
        public Food(int x, int y)
        {
            position = new Position(x, y);
        }

        public override void Draw()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("∮");
        }
        //可以选择在食物里加个随机的位置 我目前使用的是食物管理 ,可以 保存多个食物
    }
}
