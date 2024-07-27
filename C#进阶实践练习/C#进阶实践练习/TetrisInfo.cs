using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_进阶实践练习
{
    internal class TetrisInfo
    {
        private List<Position[]> list;

        public int Count { get => list.Count; }

        public TetrisInfo(E_CubeTypes type)
        {
            list = new List<Position[]>();
            switch (type)
            {
                case E_CubeTypes.O_piece:
                    list.Add(new Position[3] { new Position(2, 0), new Position(0, 1), new Position(2, 1) });
                    break;

                case E_CubeTypes.T_Piece:
                    list.Add(new Position[3] { new Position(-2, 0), new Position(0, 1), new Position(2, 0) });
                    list.Add(new Position[3] { new Position(-2, 0), new Position(0, -1), new Position(0, 1) });
                    list.Add(new Position[3] { new Position(-2, 0), new Position(0, -1), new Position(2, 0) });
                    list.Add(new Position[3] { new Position(0, -1), new Position(2, 0), new Position(0, 1) });
                    break;

                case E_CubeTypes.L_piece:
                    list.Add(new Position[3] { new Position(-2, -1), new Position(0, -1), new Position(0, 1) });
                    list.Add(new Position[3] { new Position(2, -1), new Position(-2, 0), new Position(2, 0) });
                    list.Add(new Position[3] { new Position(0, -1), new Position(0, 1), new Position(2, 1) });
                    list.Add(new Position[3] { new Position(-2, 0), new Position(-2, 1), new Position(2, 0) });
                    break;

                case E_CubeTypes.J_piece:
                    list.Add(new Position[3] { new Position(2, -1), new Position(0, -1), new Position(0, 1) });
                    list.Add(new Position[3] { new Position(2, 1), new Position(-2, 0), new Position(2, 0) });
                    list.Add(new Position[3] { new Position(0, -1), new Position(0, 1), new Position(-2, 1) });
                    list.Add(new Position[3] { new Position(-2, 0), new Position(-2, -1), new Position(2, 0) });
                    break;

                case E_CubeTypes.I_piece:
                    list.Add(new Position[3] { new Position(0, -1), new Position(0, 1), new Position(0, 2) });
                    list.Add(new Position[3] { new Position(-4, 0), new Position(-2, 0), new Position(2, 0) });
                    list.Add(new Position[3] { new Position(0, -2), new Position(0, -1), new Position(0, 1) });
                    list.Add(new Position[3] { new Position(-2, 0), new Position(4, 0), new Position(2, 0) });
                    break;

                case E_CubeTypes.S_piece:
                    list.Add(new Position[3] { new Position(0, -1), new Position(2, 0), new Position(2, 1) });
                    list.Add(new Position[3] { new Position(0, 1), new Position(-2, 1), new Position(2, 0) });
                    list.Add(new Position[3] { new Position(-2, -1), new Position(-2, 0), new Position(0, 1) });
                    list.Add(new Position[3] { new Position(-2, 0), new Position(0, -1), new Position(2, -1) });

                    break;

                case E_CubeTypes.Z_piece:
                    list.Add(new Position[3] { new Position(0, -1), new Position(-2, 0), new Position(-2, 1) });
                    list.Add(new Position[3] { new Position(0, -1), new Position(-2, -1), new Position(2, 0) });
                    list.Add(new Position[3] { new Position(2, -1), new Position(2, 0), new Position(0, 1) });
                    list.Add(new Position[3] { new Position(-2, 0), new Position(0, 1), new Position(2, 1) });
                    break;
            }
        }

        public Position[] this[int index]

        {
            get
            {
                if (index < 0)
                {
                    return list[0];
                }
                else if (index >= list.Count) //O型方块只有一种
                {
                    return list[list.Count - 1];
                }
                else
                {
                    return list[index];
                }
            }
        }
    }
}