using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_进阶实践练习
{
    internal class Cube : DrawObject
    {
      //  ConsoleColor consoleColor;
        public Cube(int x,int y)
        {
            position = new Position(x, y);
        }
        public override void Draw()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.Write("■");
        }
    }
}
