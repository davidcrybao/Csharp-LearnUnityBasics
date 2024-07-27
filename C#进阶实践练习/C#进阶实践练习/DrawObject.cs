using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace C_进阶实践练习
{
    internal enum E_CubeTypes
    {
        Wall,
        O_piece,
        T_Piece,
        L_piece, J_piece,
        I_piece,
        S_piece, Z_piece,
    }
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
        public E_CubeTypes type;

        public DrawObject(E_CubeTypes e_CubeTypes)
        {
            type = e_CubeTypes;
        }

        public DrawObject(int x, int y, E_CubeTypes type) : this(type)
        {
            position = new Position(x, y);
        }

        public void Draw()
        {
            if (position.y<0) return;

            Console.SetCursorPosition(position.x, position.y);

            switch (type)
            {
                case E_CubeTypes.Wall:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case E_CubeTypes.O_piece:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                case E_CubeTypes.I_piece:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case E_CubeTypes.T_Piece:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;

                case E_CubeTypes.S_piece:
                case E_CubeTypes.Z_piece:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;

                case E_CubeTypes.L_piece:
                case E_CubeTypes.J_piece:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
            }
            Console.Write("■");
        }

        public void Clear()
        {
            if (position.y < 0) return;
            Console.SetCursorPosition(position.x, position.y);
            Console.Write("  ");
        }
        /// <summary>
        /// 当我们不是Wall的方块跟墙壁接触的时候,把这个方块改成我们墙壁类型
        /// </summary>
        /// <param name="type"></param>
        public void ChangeType(E_CubeTypes type)
        {
            this.type = type;
        }

        public DrawObject Clone()
        {
            return new DrawObject(position.x, position.y, type);
        }
    }
}