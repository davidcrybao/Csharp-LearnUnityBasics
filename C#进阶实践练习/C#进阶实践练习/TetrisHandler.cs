using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_进阶实践练习
{
    internal class TetrisHandler
    {
        private int randomPosition = 0;

        private Dictionary<E_CubeTypes, TetrisInfo> tetrisInfo;

        private DrawObject originObject;
        private List<DrawObject> currentDraws;

        private TetrisInfo currentTetrisInfo;

        public TetrisHandler()
        {
            Initialize();
        }

        private void GetRandomCube()
        {
            Random r = new Random();
            //0是wall不考虑,得一个随机的类型
            int typeIndex = r.Next(1, 8);
            E_CubeTypes type = (E_CubeTypes)typeIndex;

            currentDraws = new List<DrawObject>() {
            new DrawObject(type),new DrawObject(type),new DrawObject(type)
            };

            for (int i = 0; i < currentDraws.Count; i++)
            {
                currentDraws[i] = new DrawObject(type);
            }

            //获得随机的位置
            currentTetrisInfo = tetrisInfo[type];
            randomPosition = r.Next(0, currentTetrisInfo.Count);
            Position[] position = currentTetrisInfo[randomPosition];

            //初始位置暂定测试用的
            originObject = new DrawObject(5, 5, type);

            for (int i = 0; i < currentDraws.Count; i++)
            {
                currentDraws[i].position = position[i] + originObject.position;
                //     new Position(position[i].x + originObject.position.x, position[i].y + originObject.position.y);
            }
        }

        public void Initialize()
        {
            tetrisInfo = new Dictionary<E_CubeTypes, TetrisInfo>() {
                {E_CubeTypes.O_piece ,new TetrisInfo (E_CubeTypes.O_piece)},
                  {E_CubeTypes.T_Piece ,new TetrisInfo (E_CubeTypes.T_Piece)},
                  {E_CubeTypes.I_piece ,new TetrisInfo (E_CubeTypes.I_piece)},
                  {E_CubeTypes.S_piece ,new TetrisInfo (E_CubeTypes.S_piece)},
                  {E_CubeTypes.Z_piece ,new TetrisInfo (E_CubeTypes.Z_piece)},
                  {E_CubeTypes.J_piece ,new TetrisInfo (E_CubeTypes.J_piece)},
                  {E_CubeTypes.L_piece ,new TetrisInfo (E_CubeTypes.L_piece)}
            };

            GetRandomCube();
        }

        public void Draw()
        {
            originObject.Draw();
            for (int i = 0; i < currentDraws.Count; i++)
            {
                currentDraws[i].Draw();
            }
        }

        public void CWRotate()
        {
            randomPosition++;
            Draw();
        }

        public void CCWRotate()
        {
            randomPosition--;
            Draw();
        }
    }
}