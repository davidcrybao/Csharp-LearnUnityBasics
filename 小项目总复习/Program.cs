namespace 小项目总复习
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

                        while (true)
                        {

                            #region 2围墙生成
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
