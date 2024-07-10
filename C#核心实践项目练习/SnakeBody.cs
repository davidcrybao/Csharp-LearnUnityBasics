using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_核心实践项目练习
{
    enum BodyType
    {
        Head,
        Body,
    }
    internal class SnakeBody : GameObject
    {
        BodyType type;

        public SnakeBody(BodyType type, int x, int y)
        {
            this.type = type;
            position = new Position(x, y);
        }

        public override void Draw()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = type == BodyType.Head ? ConsoleColor.Yellow : ConsoleColor.Green;
            Console.Write(type == BodyType.Head ? "●" : "○");
        }
        public void Clear()
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  ");
        }
    }
}
