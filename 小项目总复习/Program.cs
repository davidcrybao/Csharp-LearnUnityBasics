using static 小项目总复习.Program;

namespace 小项目总复习
{
    internal class Program
    {
        public struct Vector2
        {
            public int x;
            public int y;

            public Vector2(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public enum E_GameStates
        {
            Start,
            inGame,
            GameOver,
        }

        public enum GridType
        {
            Normal,
            Boom,
            Pause,
            Tunnel,
        }

        public enum E_PlayerType
        {
            Player,
            Computer,
        }

        public struct Player
        {
            public E_PlayerType e_PlayerType;
            public int currentMapIndex;
            public bool isPaused;

            public Player(E_PlayerType e_PlayerType, int currentMapIndex)
            {
                this.e_PlayerType = e_PlayerType;
                this.currentMapIndex = currentMapIndex;
                isPaused = false;
            }

            public void Draw(Map mapInfo)
            {
                Grid grid = mapInfo.grids[currentMapIndex];
                Console.SetCursorPosition(grid.position.x, grid.position.y);
                switch (e_PlayerType)
                {
                    case E_PlayerType.Player:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("★");
                        break;

                    case E_PlayerType.Computer:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("◆");
                        break;
                }
            }
        }

        public struct Grid
        {
            public GridType gridType;
            public Vector2 position;

            public Grid(GridType gridType, int x, int y)
            {
                this.gridType = gridType;
                position.x = x;
                position.y = y;
            }

            public void Draw()
            {
                Console.SetCursorPosition(position.x, position.y);
                switch (gridType)
                {
                    case GridType.Normal:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("□");
                        break;

                    case GridType.Boom:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("●");

                        break;

                    case GridType.Pause:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("￠");

                        break;

                    case GridType.Tunnel:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("▲");
                        break;
                }
            }
        }

        public struct Map
        {
            public Grid[] grids;

            public Map(int x, int y, int num)
            {
                grids = new Grid[num];
                int xCount = 0;
                int yCount = 0;
                int stepNumber = 2;

                Random randomType = new Random();
                for (int i = 0; i < num; i++)
                {
                    int percent = randomType.Next(0, 101);
                    if (percent <= 85 || i == 0 || i == num - 1)
                    {
                        grids[i].gridType = GridType.Normal;
                    }
                    else if (percent > 85 && percent <= 90)
                    {
                        grids[i].gridType = GridType.Boom;
                    }
                    else if (percent > 90 && percent <= 95)
                    {
                        grids[i].gridType = GridType.Pause;
                    }
                    else if (percent > 95 && percent <= 100)
                    {
                        grids[i].gridType = GridType.Tunnel;
                    }
                    grids[i].position = new Vector2(x, y);

                    if (xCount == 12)
                    {
                        yCount++;
                        y++;
                        if (yCount == 2)
                        {
                            xCount = 0;
                            yCount = 0;
                            stepNumber = -stepNumber;
                        }
                    }
                    else
                    {
                        x += stepNumber;
                        xCount++;
                    }
                }
            }

            public void Draw()
            {
                for (int i = 0; i < grids.Length; i++)
                {
                    grids[i].Draw();
                }
            }
        }

        private static void Main(string[] args)
        {
            E_GameStates e_GameStates = E_GameStates.Start;
            Random r = new Random();
            int choice = 0;
            int width = 50;
            int height = 40;
            bool hasGamePaused = false;
            ConsoleInitialize(width, height);

            string title = "飞行棋";

            while (true)
            {
                switch (e_GameStates)
                {
                    case E_GameStates.Start:
                        Console.Clear();
                        StartScene(ref e_GameStates, choice, title);
                        break;

                    case E_GameStates.inGame:
                        Console.Clear();

                        GameSceneInitialize(out e_GameStates, width, height, out title);
                        break;

                    case E_GameStates.GameOver:
                        Console.Clear();
                        StartScene(ref e_GameStates, choice, title);
                        break;

                }
            }
        }

        private static void GameSceneInitialize(out E_GameStates e_GameStates, int width, int height, out string title)
        {
            Map map = new Map(12, 3, 150);
            DrawWallAndOthers(width, height);
            map.Draw();
            Player player = new Player(E_PlayerType.Player, 0);
            Player computer = new Player(E_PlayerType.Computer, 0);
            DrawPlayer(player, computer, map);
            bool isGameOver = false;
            while (true)
            {
                Console.ReadKey(true);
                isGameOver = RollDice(height, ref player, ref computer, map);
                map.Draw();
                DrawPlayer(player, computer, map);

                if (isGameOver)
                {
                    Console.ReadKey();
                    e_GameStates = E_GameStates.GameOver;
                    title = "玩家获胜了!恭喜你";
                    break;
                }
                //电脑
                Console.ReadKey(true);
                isGameOver = RollDice(height, ref computer, ref player, map);
                map.Draw();
                DrawPlayer(player, computer, map);

                if (isGameOver)
                {
                    Console.ReadKey();
                    e_GameStates = E_GameStates.GameOver;
                    title = "电脑获胜,你真垃圾";
                    break;
                }
            }
        }

        private static void DrawWallAndOthers(int width, int height)
        {
            #region 红砖围墙生成

            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < width; i += 2)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
                Console.SetCursorPosition(i, 29);
                Console.Write("■");
                Console.SetCursorPosition(i, 34);
                Console.Write("■");
                Console.SetCursorPosition(i, 39);
                Console.Write("■");
            }

            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
                Console.SetCursorPosition(48, i);
                Console.Write("■");
            }

            #endregion 红砖围墙生成

            #region 提示信息生成

            Console.SetCursorPosition(2, 30);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("□:普通格子");
            Console.SetCursorPosition(2, 32);
            Console.Write("▲:时空隧道,随机倒退,暂停,换位置");
            Console.SetCursorPosition(2, 33);
            Console.Write("★:玩家   ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("◆:电脑    ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("〓:玩家与电脑重合的位置");
            Console.SetCursorPosition(2, 31);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("￠:暂停,一回合不动     ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("●:炸弹,倒退10格 ");

            #endregion 提示信息生成
        }

        private static void ConsoleInitialize(int width, int height)
        {
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            Console.CursorVisible = false;
        }

        private static void StartScene(ref E_GameStates e_GameStates, int choice, string title)
        {
            bool isQuitBegin = false;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                PrintTextInMiddle(title, 5);
                Console.ForegroundColor = choice == 0 ? ConsoleColor.Red : ConsoleColor.White;
                PrintTextInMiddle("开始游戏", 8);
                Console.ForegroundColor = choice == 1 ? ConsoleColor.Red : ConsoleColor.White;
                PrintTextInMiddle("结束游戏", 10);
                ConsoleKey input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.W:
                        choice = 0;
                        break;

                    case ConsoleKey.S:
                        choice = 1;
                        break;

                    case ConsoleKey.E:
                        if (choice == 0)
                        {
                            e_GameStates = E_GameStates.inGame;
                            isQuitBegin = true;
                        }
                        else
                        {
                            Environment.Exit(0);
                        }

                        break;
                }
                if (isQuitBegin)
                {
                    Console.WriteLine("Why not break?");
                    break;
                }
            }
            Console.WriteLine(choice);
        }

        private static void DrawPlayer(Player player, Player computer, Map map)
        {
            if (player.currentMapIndex == computer.currentMapIndex)
            {
                Grid grid = map.grids[player.currentMapIndex];
                Console.SetCursorPosition(grid.position.x, grid.position.y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("〓");
            }
            else
            {
                player.Draw(map);
                computer.Draw(map);
            }
        }

        private static void PrintTextInMiddle(string text, int position, int width = 50)
        {
            int length = text.Length;
            Console.SetCursorPosition(width / 2 - length, position);
            Console.Write(text);
        }

        private static bool RollDice(int height, ref Player player, ref Player secondPlayer, Map map)
        {

            //擦除信息
            ClearInformation(height);
            //决定文本颜色
            Console.ForegroundColor = player.e_PlayerType == E_PlayerType.Player ? ConsoleColor.Cyan : ConsoleColor.DarkRed;
            if (player.isPaused)
            {
                Console.SetCursorPosition(2, height - 5);
                Console.Write("处于暂停点,{0}需要暂停一个回合", player.e_PlayerType == E_PlayerType.Player ? "你" : "电脑");
                Console.SetCursorPosition(2, height - 4);
                Console.Write("按任意键让{0}移动", player.e_PlayerType == E_PlayerType.Player ? "电脑 " : "你");
                player.isPaused = false;
                return false;
            }
            Random random = new Random();
            Grid grid = map.grids[player.currentMapIndex];
            int randomNumber = random.Next(1, 11);
            player.currentMapIndex = player.currentMapIndex + randomNumber < map.grids.Length - 1 ? player.currentMapIndex + randomNumber : map.grids.Length - 1;
            Console.SetCursorPosition(2, height - 5);
            Console.Write("{0}扔出的点数为:{1}", player.e_PlayerType == E_PlayerType.Player ? "你" : "电脑", randomNumber);
            if (player.currentMapIndex == map.grids.Length - 1)
            {
                Console.SetCursorPosition(2, height - 4);
                if (player.e_PlayerType == E_PlayerType.Player)
                {

                    Console.Write("恭喜你获胜");
                }
                else
                {

                    Console.Write("很遗憾 电脑获胜了!");
                }

                Console.SetCursorPosition(2, height - 3);
                Console.Write("请按任意键,结束游戏");
                return true;
            }
            else
            {
                Console.SetCursorPosition(2, height - 4);
                switch (grid.gridType)
                {
                    case GridType.Boom:
                        player.currentMapIndex = player.currentMapIndex - 5 >= 0 ? player.currentMapIndex - 5 : 0;
                        Console.Write("{0}被炸弹炸了,回退5格", player.e_PlayerType == E_PlayerType.Player ? "你" : "电脑");
                        break;

                    case GridType.Pause:
                        Console.Write("{0}即将被暂停一个回合", player.e_PlayerType == E_PlayerType.Player ? "你" : "电脑");
                        player.isPaused = true;
                        break;

                    case GridType.Tunnel:
                        randomNumber = random.Next(0, 91);
                        Console.Write("{0}来到了时空隧道", player.e_PlayerType == E_PlayerType.Player ? "你" : "电脑");
                        Console.SetCursorPosition(2, height - 3);

                        if (randomNumber <= 30)
                        {
                            player.currentMapIndex = player.currentMapIndex - 5 >= 0 ? player.currentMapIndex - 5 : 0;
                            Console.Write("{0}被炸弹炸了,回退5格", player.e_PlayerType == E_PlayerType.Player ? "你" : "电脑");
                            Console.SetCursorPosition(2, height - 2);
                            Console.Write("按任意键让{0}移动", player.e_PlayerType == E_PlayerType.Player ? "电脑" : "你");
                        }
                        else if (randomNumber <= 60)
                        {
                            player.isPaused = true;
                            Console.Write("{0}即将被暂停一个回合", player.e_PlayerType == E_PlayerType.Player ? "你" : "电脑");
                            Console.SetCursorPosition(2, height - 2);
                            Console.Write("按任意键让{0}移动", player.e_PlayerType == E_PlayerType.Player ? "电脑" : "你");
                        }
                        else
                        {
                            int temp = player.currentMapIndex;
                            player.currentMapIndex = secondPlayer.currentMapIndex;
                            secondPlayer.currentMapIndex = temp;
                            Console.Write("{0}即将和{1}交换位置", player.e_PlayerType == E_PlayerType.Player ? "你" : "电脑", player.e_PlayerType == E_PlayerType.Player ? "电脑" : "你");
                            Console.SetCursorPosition(2, height - 2);
                            Console.Write("按任意键让{0}移动", player.e_PlayerType == E_PlayerType.Player ? "电脑" : "你");
                        }

                        break;

                    case GridType.Normal:
                        Console.Write("{0}到达了一个安全的位置", player.e_PlayerType == E_PlayerType.Player ? "你" : "电脑");
                        Console.SetCursorPosition(2, height - 3);
                        Console.Write("按任意键让{0}移动", player.e_PlayerType == E_PlayerType.Player ? "电脑" : "你");
                        break;
                }
            }

            return false;
        }

        private static void ClearInformation(int height)
        {
            Console.SetCursorPosition(2, height - 5);
            Console.Write("                                              ");
            Console.SetCursorPosition(2, height - 4);
            Console.Write("                                              ");
            Console.SetCursorPosition(2, height - 3);
            Console.Write("                                              ");
            Console.SetCursorPosition(2, height - 2);
            Console.Write("                                              ");
        }
    }
}
