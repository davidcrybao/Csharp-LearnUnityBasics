using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_进阶实践练习
{
    public enum E_CubeTypes
    {
        O_piece,
        T_Piece, 
        L_piece, J_piece,
        I_piece, 
        S_piece, Z_piece,
    }

    internal class Tetris 
    {
        private Cube[] cubes;
        E_CubeTypes _CubeTypes;
        int index = 0;

        public Tetris(E_CubeTypes e_CubeTypes)
        {
            cubes = new Cube[4];
            _CubeTypes = e_CubeTypes;
        }

        public  void Draw()
        {
            switch (_CubeTypes)
            {
                case E_CubeTypes.O_piece:
                    cubes[0].position = new Position(0, 0);
                    cubes[1].position = new Position(2, 0);
                    cubes[2].position = new Position(0, 1);
                    cubes[3].position = new Position(2, 1);
                    break;
                case E_CubeTypes.T_Piece:
                    cubes[0].position = new Position(0, 0);
                    cubes[1].position = new Position(2, 0);
                    cubes[2].position = new Position(0, 1);
                    cubes[3].position = new Position(-2, 0);
                    break;
                case E_CubeTypes.L_piece:
                    cubes[0].position = new Position(0, 0);
                    cubes[1].position = new Position(0, 1);
                    cubes[2].position = new Position(0, -1);
                    cubes[3].position = new Position(2, 1);
                    break;
                case E_CubeTypes.J_piece:
                    cubes[0].position = new Position(0, 0);
                    cubes[1].position = new Position(0, 1);
                    cubes[2].position = new Position(0, -1);
                    cubes[3].position = new Position(-2, 1);
                    break;
                case E_CubeTypes.I_piece:
                    cubes[0].position = new Position(0, 0);
                    cubes[1].position = new Position(0, 1);
                    cubes[2].position = new Position(0, 2);
                    cubes[3].position = new Position(0, -1);
                    break;
                case E_CubeTypes.S_piece:
                    cubes[0].position = new Position(0, 0);
                    cubes[1].position = new Position(0, -1);
                    cubes[2].position = new Position(2, 0);
                    cubes[3].position = new Position(2, 1);
                    break;
                case E_CubeTypes.Z_piece:
                    cubes[0].position = new Position(0, 0);
                    cubes[1].position = new Position(0, -1);
                    cubes[2].position = new Position(-2, 0);
                    cubes[3].position = new Position(-2, 1);
                    break;
            }

            foreach (var item in cubes)
            {
                item.Draw();
            }
        }
        public void MoveDownwards()
        {
            for (int i = 0; i < cubes.Length; i++)
            {
                cubes[i].position.y += 1;
            }
        }

        public void CWRotate()
        { 
        
        }
        public void CCWRotate()
        {

        }
    }
}