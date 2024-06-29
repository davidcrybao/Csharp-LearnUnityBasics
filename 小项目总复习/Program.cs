namespace 小项目总复习
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int width = 50;
            int height = 40;
            int cursorX = 0, cursorY = 0;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            int currentWindowIndex = 1;
            int choice = 0;


            while (true)
            {
                switch (currentWindowIndex)
                {
                    case 0:

                        while (true)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            PrintTextInMiddle("飞行棋", 5);
                            Console.ForegroundColor = choice == 0 ? ConsoleColor.Red : ConsoleColor.White;
                            PrintTextInMiddle("开始游戏", 8);
                            Console.ForegroundColor = choice == 1 ? ConsoleColor.Red : ConsoleColor.White;
                            PrintTextInMiddle("结束游戏", 10);
                            ConsoleKey input = Console.ReadKey().Key;
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
                                        currentWindowIndex = 1;

                                    }
                                    else
                                    {
                                        Environment.Exit(0);
                                    }
                                    break;

                            }
                            if (currentWindowIndex != 0)
                            {
                                break;
                            }
                        }
                        break;

                    case 1:
                        Console.Clear();

                        int startXPosition = 0;
                        int startYPosition = 0;
                        int endXPosition = 0;
                        int endYPosition = 0;
                        while (true)
                        {

                            #region 2围墙生成
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
                            #endregion
                            #region 地图的逻辑生成
                            //我们是在最上面的生成地图的 所以坐标(2,1)开始 到坐标(46,28) 复杂的逻辑 生成其他的时候记录count+二元数组坐标(或者xy两个数组);
                            //(2,29-46.34) 是我们说明的文档生成 最简单的一部分
                            //(2.35-46.38)是我们按键互动之后生成,这里面的逻辑比较复杂
                            startXPosition = r.Next(2, 46);
                            startYPosition = r.Next(2, 5);
                            endXPosition = r.Next(2, 46);
                            endYPosition = r.Next(25, 28);

                            #endregion


                            ConsoleKey input = Console.ReadKey().Key;
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
                                        currentWindowIndex = 1;

                                    }
                                    else
                                    {
                                        Environment.Exit(0);
                                    }
                                    break;

                            }
                        }

                        break;

                    case 2:
                        break;
                }
            }


        }

        static void PrintTextInMiddle(string text, int position, int width = 50)
        {

            int length = text.Length;
            Console.SetCursorPosition(width / 2 - length, position);
            Console.Write(text);

        }
    }
}
