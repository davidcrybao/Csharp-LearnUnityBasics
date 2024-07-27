namespace C_进阶实践练习
{
    internal class GameScene : ISceneUpdate
    {
        private Map map;
        private TetrisHandler tetrisHandler;
        Thread t;
        bool isRunning;

        public GameScene()
        {
            map = new Map(this);
            tetrisHandler = new TetrisHandler();
            isRunning = true;

            t = new Thread(PlayerInput);
            t.IsBackground = true;
            t.Start();
        }

        public void PlayerInput()
        {
            while (isRunning)
            {
                if (Console.KeyAvailable)
                {
                    lock (tetrisHandler)
                    {
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.Q:
                                if (tetrisHandler.CanRotate(E_RotateDirection.CounterClockWise, map))
                                {
                                    tetrisHandler.Rotate(E_RotateDirection.CounterClockWise, map);
                                }
                                break;

                            case ConsoleKey.E:
                                if (tetrisHandler.CanRotate(E_RotateDirection.ClockWise, map))
                                {
                                    tetrisHandler.Rotate(E_RotateDirection.ClockWise, map);
                                }

                                break;

                            case ConsoleKey.S:
                                if (tetrisHandler.CanMove(E_MoveDirection.Down, map)) tetrisHandler.Move(E_MoveDirection.Down);
                                break;

                            case ConsoleKey.A:
                                if (tetrisHandler.CanMove(E_MoveDirection.Left, map)) tetrisHandler.Move(E_MoveDirection.Left);
                                break;

                            case ConsoleKey.D:
                                if (tetrisHandler.CanMove(E_MoveDirection.Right, map)) tetrisHandler.Move(E_MoveDirection.Right);
                                break;
                        }
                    }
                }
            }
        }

        public void Update()
        {
            lock (tetrisHandler)
            {
                map.Draw();
                tetrisHandler.Draw();
                if (tetrisHandler.CanMove(E_MoveDirection.Down, map))
                {
                    tetrisHandler.Move(E_MoveDirection.Down);
                }
                else //执行clear逻辑?
                {
                    map.Add(tetrisHandler.GetCurrentDraws());
                    tetrisHandler.GetRandomCube();
                }
            }
            Thread.Sleep(100);
        }

        public void StopThread()
        {
            isRunning = false;
            t = null;
        }
    }
}