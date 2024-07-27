namespace C_进阶实践练习
{
    internal enum E_RotateDirection
    {
        ClockWise,
        CounterClockWise,
    }

    internal enum E_MoveDirection
    {
        Right, Left, Down
    }

    internal class TetrisHandler
    {
        private int randomPosition = 0;

        private Dictionary<E_CubeTypes, TetrisInfo> tetrisInfo;

        private List<DrawObject> currentDraws;
        private Position[] position;
        private TetrisInfo currentTetrisInfo;

       
        public TetrisHandler()
        {
            Initialize();
            GetRandomCube();
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
        }

        public void GetRandomCube()
        {
            Random r = new Random();
            //0是wall不考虑,得一个随机的类型
            int typeIndex = r.Next(1, 2);

            E_CubeTypes type = (E_CubeTypes)typeIndex;

            currentDraws = new List<DrawObject>() {
            new DrawObject(type),new DrawObject(type),new DrawObject(type),new DrawObject(type)
            };

            currentDraws[0].position = new Position(6, -1);

            //获得随机的位置
            currentTetrisInfo = tetrisInfo[type];
            randomPosition = r.Next(0, currentTetrisInfo.Count);
            position = currentTetrisInfo[randomPosition];

            SyncPosition();
        }

        private void SyncPosition()
        {
            Clear();

            //只存储了三个位置 所以不会出现错误
            for (int i = 0; i < position.Length; i++)
            {
                currentDraws[i + 1].position = position[i] + currentDraws[0].position;
                //     new Position(position[i].x + originObject.position.x, position[i].y + originObject.position.y);
            }
            Draw();
        }

        public void Draw()
        {
            for (int i = 0; i < currentDraws.Count; i++)
            {
                currentDraws[i].Draw();
            }
        }

        public void Clear()
        {
            for (int i = 0; i < currentDraws.Count; i++)
            {
                currentDraws[i].Clear();
            }
        }


        public void Rotate(E_RotateDirection direction, Map map)
        {
            Clear();
            switch (direction)
            {
                case E_RotateDirection.ClockWise:
                    randomPosition++;
                    if (randomPosition >= currentTetrisInfo.Count) randomPosition = 0;
                    break;

                case E_RotateDirection.CounterClockWise:
                    randomPosition--;
                    if (randomPosition < 0) randomPosition = currentTetrisInfo.Count - 1;
                    break;
            }
            position = currentTetrisInfo[randomPosition];

            for (int i = 0; i < position.Length; i++)
            {
                currentDraws[i + 1].position = position[i] + currentDraws[0].position;
            }
            Draw();
        }

        public void Move(E_MoveDirection moveDirection)
        {
            Clear();
            switch (moveDirection)
            {
                case E_MoveDirection.Right:
                    currentDraws[0].position.x += 2;
                    break;

                case E_MoveDirection.Left:
                    currentDraws[0].position.x -= 2;
                    break;

                case E_MoveDirection.Down:
                    currentDraws[0].position.y++;
                    break;
            }
            for (int i = 0; i < position.Length; i++)
            {
                currentDraws[i + 1].position = currentDraws[0].position + position[i];
            }
            Draw();
        }

        public bool CanRotate(E_RotateDirection direction, Map map)
        {
            int temp = randomPosition;
            switch (direction)
            {
                case E_RotateDirection.ClockWise:
                    temp++;
                    if (temp >= currentTetrisInfo.Count) temp = 0;
                    break;

                case E_RotateDirection.CounterClockWise:
                    temp--;
                    if (temp < 0) temp = currentTetrisInfo.Count - 1;
                    break;
            }

            //长度是3
            Position[] nowPos = currentTetrisInfo[temp];
            Position offsetPosition;
            //墙壁是固定的,是不是只要判断X和Y就可以了,X与Y有没有超出我们的边界,
            for (int i = 0; i < nowPos.Length; i++)
            {
                offsetPosition = currentDraws[0].position + nowPos[i];
                if (offsetPosition.x <= 0 || offsetPosition.x >= GameManager.width - 2 || offsetPosition.y >= GameManager.height - 3)
                {
                    return false;
                }
            }

            //如果是和动态的墙壁重合,贼添加进这里面,判断是否要消除这一行,然后生成新的砖块
            //然后在判断是否和动态的墙壁位置重合

            for (int j = 0; j < nowPos.Length; j++)
            {
                offsetPosition = currentDraws[0].position + nowPos[j];
                for (int i = 0; i < map.dynamicWalls.Count; i++)
                {
                    if (map.dynamicWalls[i].position == offsetPosition)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool CanMove(E_MoveDirection moveDirection, Map map)
        {

            List<DrawObject> tempDraws = new List<DrawObject>();
            for (int i = 0; i < currentDraws.Count; i++)
            {
                // 深拷贝 DrawObject
                tempDraws.Add(currentDraws[i].Clone());
            }

            switch (moveDirection)
            {
                case E_MoveDirection.Right:
                    tempDraws[0].position.x += 2;
                    break;

                case E_MoveDirection.Left:
                    tempDraws[0].position.x -= 2;
                    break;

                case E_MoveDirection.Down:
                    tempDraws[0].position.y++;
                    break;
            }

            //变成修正后的位置 postion长度是3,我们不会改变tempDraw[0]的位置
            for (int i = 0; i < position.Length; i++)
            {
                tempDraws[i + 1].position = tempDraws[0].position + position[i];
            }

            //然后我们再比较是否重合
            for (int i = 0; i < tempDraws.Count; i++)
            {
                if (tempDraws[i].position.x <= 0 || tempDraws[i].position.x >= GameManager.width - 2 || tempDraws[i].position.y >= GameManager.height - 3)
                {
                    return false;
                }
            }

            for (int i = 0; i < tempDraws.Count; i++)
            {
                for (int j = 0; j < map.dynamicWalls.Count; j++)
                {
                    if (tempDraws[i].position == map.dynamicWalls[j].position)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public List<DrawObject> GetCurrentDraws()
        {
            return currentDraws;
        }
    }
}