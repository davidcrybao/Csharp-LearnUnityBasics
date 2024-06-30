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
            bool hasGenerate = false;


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
                        Vector2 drawStartPosition = new Vector2(0, 0);
                        Vector2 playerStartPosition = new Vector2(0, 0);
                        Vector2[] funcVector = new Vector2[20];
                        int playerPosition = 0;

                        string block = "□"; //跟障碍物进行交换,或者写个结构体?

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
                        drawStartPosition.x = r.Next(4, 18); //从3开始是因为2的时候我们要在前面画一个起点,这会画到围墙里面
                        drawStartPosition.y = r.Next(2, 5);
                        Vector2[] totalPosition = new Vector2[117];  //总数其实是固定的,9行 每列12+
                        int count = 0; //count是为了给funcVector用

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(drawStartPosition.x - 2, drawStartPosition.y);
                        playerStartPosition.x = drawStartPosition.x - 2;
                        playerStartPosition.y = drawStartPosition.y;
                        Console.Write("□");
                        Console.SetCursorPosition(drawStartPosition.x, drawStartPosition.y);
                        int number = r.Next(0, 12) * 2;
                        bool generateFunc = r.Next(0, 24) > 18;
                        for (int i = 0; i < 20; i++)
                        {
                            bool hasExecuted = false;
                            // 最后一行特殊处理
                            if (i == 18)
                            {

                                for (int j = r.Next(0, 12) * 2; j > 0; j -= 2)
                                {

                                    if (i % 2 == 0)
                                    {
                                        Console.SetCursorPosition(drawStartPosition.x + 24 - j, drawStartPosition.y + i);
                                        Console.Write("□");
                                    }

                                }
                            }//不是最后一行,我们先判断是不是偶数行,偶数行生成一组□,不是的话生成头尾方块
                            else
                            {
                                for (int j = 0; j < 24; j += 2)
                                {

                                    if (i % 2 == 0)
                                    {
                                        Console.SetCursorPosition(drawStartPosition.x + j, drawStartPosition.y + i);
                                        Console.Write("□");
                                        totalPosition[count].x = drawStartPosition.x + j;
                                        totalPosition[count].y = drawStartPosition.y + i;
                                        count++;
                                    }
                                    else if (j == 22 && !hasGenerate && !hasExecuted && i != 19)
                                    {
                                        Console.SetCursorPosition(drawStartPosition.x + j, drawStartPosition.y + i);
                                        Console.Write("□");
                                        totalPosition[count].x = drawStartPosition.x + j;
                                        totalPosition[count].y = drawStartPosition.y + i;
                                        count++;
                                        hasGenerate = true;
                                        hasExecuted = true;
                                    }
                                    else if (j == 0 && hasGenerate && !hasExecuted && i != 19)
                                    {
                                        Console.SetCursorPosition(drawStartPosition.x + j, drawStartPosition.y + i);
                                        Console.Write("□");
                                        totalPosition[count].x = drawStartPosition.x + j;
                                        totalPosition[count].y = drawStartPosition.y + i;
                                        count++;
                                        hasGenerate = false;
                                        hasExecuted = true;
                                    }

                                }
                            }
                        }
                        #endregion

                        #region 障碍物的生成
                        bool[] isPositionUsed = new bool[117];
                        Vector2[] boomPosition = new Vector2[5];
                        Vector2[] stopPosition = new Vector2[5];
                        Vector2[] ranPosition = new Vector2[5];
                        Console.ForegroundColor = ConsoleColor.Blue;
                        for (int i = 0; i < 5; i++)
                        {

                            int randomPosition;
                            do
                            {
                                randomPosition = r.Next(0, 117);
                            } while (isPositionUsed[randomPosition]);

                            isPositionUsed[randomPosition] = true;

                            Console.SetCursorPosition(totalPosition[randomPosition].x, totalPosition[randomPosition].y);
                            Console.Write("￠");
                            stopPosition[i].x = totalPosition[randomPosition].x;
                            stopPosition[i].y = totalPosition[randomPosition].y;
                        }

                        Console.ForegroundColor = ConsoleColor.White;
                        for (int i = 0; i < 5; i++)
                        {
                            int randomPosition;
                            do
                            {
                                randomPosition = r.Next(0, 117);
                            } while (isPositionUsed[randomPosition]);

                            isPositionUsed[randomPosition] = true;

                            Console.SetCursorPosition(totalPosition[randomPosition].x, totalPosition[randomPosition].y);
                            Console.Write("▲");
                            ranPosition[i].x = totalPosition[randomPosition].x;
                            ranPosition[i].y = totalPosition[randomPosition].y;
                        }




                        Console.ForegroundColor = ConsoleColor.Red;
                        for (int i = 0; i < 5; i++)
                        {
                            int randomPosition;
                            do
                            {
                                randomPosition = r.Next(0, 117);
                            } while (isPositionUsed[randomPosition]);

                            isPositionUsed[randomPosition] = true;

                            Console.SetCursorPosition(totalPosition[randomPosition].x, totalPosition[randomPosition].y);
                            Console.Write("●");
                            boomPosition[i].x = totalPosition[randomPosition].x;
                            boomPosition[i].y = totalPosition[randomPosition].y;
                        }

                        #endregion

                        while (true)
                        {



                            #region 投掷筛子逻辑
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.SetCursorPosition(playerStartPosition.x, playerStartPosition.y);
                            Console.Write("★");
                            int diceNumber = r.Next(0, 7);
                            ConsoleKey input = Console.ReadKey().Key;
                            switch (input)
                            {
                                case ConsoleKey.E:
                                    playerPosition += diceNumber;
                                    Console.SetCursorPosition(totalPosition[playerPosition].x, totalPosition[playerPosition].y);
                                    Console.Write("★");
                                    break;

                            }


                            #endregion
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

        static string ChangeBlock()
        {
            return "x";
        }
    }
}
