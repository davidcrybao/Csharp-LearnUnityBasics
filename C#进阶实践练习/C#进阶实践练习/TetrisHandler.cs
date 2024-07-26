using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_进阶实践练习
{

    internal class TetrisHandler 
    {
        E_CubeTypes type;
        int index = 0;
        int cubeType = 0;
        Random r = new Random();
        TetrisInfo tetrisInfo;
        DrawObject[] drawObjects = new DrawObject[3];
        DrawObject originObject;
        public TetrisHandler()
        {
            Initialize();
        }
        private void GetRandomCube()
        {
            index = r.Next(0, 101);
            if (index <= 100 && index > 80)
            {
                type = E_CubeTypes.O_piece;
            }
            else if (index <= 80 && index > 60)
            {
                type = E_CubeTypes.I_piece;
            }
            else if (index <= 60 && index > 40)
            {
                type = index > 50 ? E_CubeTypes.S_piece : E_CubeTypes.Z_piece;

            }
            else if (index <= 40 && index > 20)
            {
                type =index>30?  E_CubeTypes.J_piece : E_CubeTypes.L_piece;
            }
            else
            {
                type = E_CubeTypes.T_Piece;
            }
        }

        public void Initialize()
        {
            GetRandomCube();
            tetrisInfo = new TetrisInfo(type);

            originObject = new DrawObject(5, 5, type);
            //获得一个随机的队列来返回我们的类型
            cubeType = r.Next(0, tetrisInfo.Count);

            for (int i = 0; i < drawObjects.Length; i++)
            {
                drawObjects[i] = new DrawObject(type);
            }

        }

        public void SyncPosition()
        {
            Position[] position = tetrisInfo[index];
            for (int i = 0; i < drawObjects.Length; i++)
            {
                drawObjects[i].position = new Position(position[i].x+originObject.position.x,position[i].y+originObject.position.y);
            }
        

        }
        public  void Draw()
        {
            SyncPosition();
            originObject.Draw();
            for (int i = 0; i < drawObjects.Length; i++)
            {
                  drawObjects[i].Draw();
            }
        }
        public void CWRotate()
        {
            index++;
            Draw();
        }
        public void CCWRotate()
        {
            index--;
            Draw();
        }
    }
}