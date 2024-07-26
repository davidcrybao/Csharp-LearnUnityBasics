using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_进阶实践练习
{
    /// <summary>
    /// 废弃类
    /// </summary>
    internal class Wall : DrawObject
    {
        public Wall(E_DrawType drawType) : base(drawType)
        {
        }

        public new void Draw()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("■");
        }
    }
}
