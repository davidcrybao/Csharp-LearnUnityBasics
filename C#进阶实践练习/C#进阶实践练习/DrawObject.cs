using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_进阶实践练习
{
    internal enum E_DrawType
    {
        /// <summary>
        /// 墙壁
        /// </summary>
        Wall,

        /// <summary>
        /// 正方形方块
        /// </summary>
        Cube,

        /// <summary>
        /// 直线
        /// </summary>
        Line,

        /// <summary>
        /// 坦克
        /// </summary>
        Tank,

        /// <summary>
        /// 左梯子
        /// </summary>
        Left_Ladder,

        /// <summary>
        /// 右梯子
        /// </summary>
        Right_Ladder,

        /// <summary>
        /// 左长梯子
        /// </summary>
        Left_Long_Ladder,

        /// <summary>
        /// 右长梯子
        /// </summary>
        Right_Long_Ladder,
    }

    internal class DrawObject : IDraw
    {
        public Position position;
        public E_DrawType type;

        public DrawObject(E_DrawType drawType)
        {
            type = drawType;
        }

        public DrawObject(int x, int y, E_DrawType type) : this(type)
        {
            position = new Position(x, y);
        }

        public void Draw()
        {
            Console.SetCursorPosition(position.x, position.y);

            switch (type)
            {
                case E_DrawType.Wall:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case E_DrawType.Cube:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                case E_DrawType.Line:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case E_DrawType.Tank:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;

                case E_DrawType.Left_Ladder:
                case E_DrawType.Right_Ladder:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;

                case E_DrawType.Left_Long_Ladder:
                case E_DrawType.Right_Long_Ladder:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
            }
            Console.Write("■");
        }

        /// <summary>
        /// 当我们不是Wall的方块跟墙壁接触的时候,把这个方块改成我们墙壁类型
        /// </summary>
        /// <param name="type"></param>
        public void ChangeType(E_DrawType type)
        {
            this.type = type;
        }
    }
}