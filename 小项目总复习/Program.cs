﻿namespace 小项目总复习
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
            bool isReversedOrder = false;


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
                        int backwardSteps = 10;
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
                        int number = r.Next(2, 15);
                        Vector2[] totalPosition = new Vector2[117 + number];  //总数其实是固定的,9行 每列12+
                        int count = 0; //count是为了给funcVector用

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(drawStartPosition.x - 2, drawStartPosition.y);
                        playerStartPosition.x = drawStartPosition.x - 2;
                        playerStartPosition.y = drawStartPosition.y;
                        Console.Write("□");
                        Console.SetCursorPosition(drawStartPosition.x, drawStartPosition.y);

                        bool generateFunc = r.Next(0, 24) > 18;
                        for (int i = 0; i < 20; i++)
                        {
                            bool hasExecuted = false;
                            // 最后一行特殊处理
                            if (i == 18)
                            {


                                for (int j = -2; j >= -number * 2; j -= 2)
                                {

                                    if (i % 2 == 0)
                                    {
                                        Console.SetCursorPosition(drawStartPosition.x + 24 + j, drawStartPosition.y + i);
                                        Console.Write("■");
                                        totalPosition[count].x = drawStartPosition.x + 24 + j;
                                        totalPosition[count].y = drawStartPosition.y + i;
                                        count++;
                                    }

                                }
                            }//不是最后一行,我们先判断是不是偶数行,偶数行生成一组□,不是的话生成头尾方块
                            else
                            {
                                if (!isReversedOrder)
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
                                            isReversedOrder = true;
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
                                else
                                {
                                    for (int j = 22; j >= 0; j -= 2)
                                    {

                                        if (i % 2 == 0)
                                        {
                                            Console.SetCursorPosition(drawStartPosition.x + j, drawStartPosition.y + i);
                                            Console.Write("□");
                                            totalPosition[count].x = drawStartPosition.x + j;
                                            totalPosition[count].y = drawStartPosition.y + i;
                                            count++;
                                            isReversedOrder = false;
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
                        }
                        #endregion

                        #region 障碍物的生成
                        bool[] isPositionUsed = new bool[117 + number];
                        Vector2[] boomPosition = new Vector2[5];
                        Vector2[] stopPosition = new Vector2[5];
                        int playerInteract = 0;
                        Vector2[] randomInteractPosition = new Vector2[5];
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
                            randomInteractPosition[i].x = totalPosition[randomPosition].x;
                            randomInteractPosition[i].y = totalPosition[randomPosition].y;
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

                        #region 提示信息生成
                        Console.SetCursorPosition(2, 30);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("□:普通格子");
                        Console.SetCursorPosition(2, 32);
                        Console.Write("▲:时空隧道,随机倒退,暂停,换位置");
                        Console.SetCursorPosition(2, 33);
                        Console.Write("★:玩家   ");


                        Console.SetCursorPosition(2, 31);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("￠:暂停,一回合不动     ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("●:炸弹,倒退10格 ");
                        #endregion

                        while (true)
                        {



                            #region 投掷筛子逻辑

                            int diceNumber = r.Next(0, 7);

                            ConsoleKey input = Console.ReadKey().Key;
                            switch (input)
                            {
                                case ConsoleKey.E:
                                    if (playerInteract == 1)
                                    {
                                        playerInteract = 0;
                                        break;
                                    }
                                    else if (playerInteract != 0)
                                    {
                                        playerInteract = 0;
                                    }
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.SetCursorPosition(totalPosition[playerPosition].x, totalPosition[playerPosition].y);
                                    Console.Write("□");
                                    playerPosition += diceNumber;

                                    //到达终点
                                    if (playerPosition >= totalPosition.Length)
                                    {
                                        playerPosition = totalPosition.Length - 1;
                                    }
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.SetCursorPosition(totalPosition[playerPosition].x, totalPosition[playerPosition].y);
                                    Console.Write("★");
                                    if (isPositionUsed[playerPosition])
                                    {

                                        for (int i = 0; i < stopPosition.Length; i++)
                                        {
                                            if (totalPosition[playerPosition].x == stopPosition[i].x && totalPosition[playerPosition].y == stopPosition[i].y)
                                            {
                                                playerInteract = 1;
                                            }
                                            //炸弹的逻辑
                                            if (totalPosition[playerPosition].x == boomPosition[i].x && totalPosition[playerPosition].y == boomPosition[i].y)
                                            {
                                                //遇到一次之后删除
                                                boomPosition[i].x = 0;
                                                boomPosition[i].y = 0;
                                                playerInteract = 2;
                                                backwardSteps = 10;
                                                playerPosition = Boom(totalPosition, playerPosition, drawStartPosition, backwardSteps);

                                            }

                                            if (totalPosition[playerPosition].x == randomInteractPosition[i].x && totalPosition[playerPosition].y == randomInteractPosition[i].y)
                                            {
                                                randomInteractPosition[i].x = 0;
                                                randomInteractPosition[i].y = 0;
                                                int randomFunction = r.Next(0, 3);


                                                switch (randomFunction)
                                                {
                                                    case 0:

                                                        playerInteract = 2;
                                                        backwardSteps = r.Next(5, 15); ;
                                                        playerPosition = Boom(totalPosition, playerPosition, drawStartPosition, backwardSteps);

                                                        break;
                                                    case 1:
                                                        playerInteract = 1;
                                                        break;
                                                    case 2:
                                                        playerInteract = 3;
                                                        break;
                                                }

                                            }

                                        }
                                    }
                                    PlayerInteractTextGenerate(diceNumber, playerInteract);
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

        static void PlayerInteractTextGenerate(int diceNumber, int playerInterctOption = 0, int backwardSteps = 10)
        {
            Console.SetCursorPosition(2, 35);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("玩家扔出的点数为{0}", diceNumber);


            switch (playerInterctOption)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(2, 36);
                    Console.Write("你被禁止移动一个回合       ");
                    break;
                case 2:
                    Console.SetCursorPosition(2, 36);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("你遇到了炸弹,倒退{0}格     ", backwardSteps);
                    break;
                case 3:
                    Console.SetCursorPosition(2, 36);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("准备与电脑交换位置     ", backwardSteps);
                    break;
                default:
                    Console.SetCursorPosition(2, 36);
                    Console.Write("你到达了一个安全的位置");
                    break;

            }


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(2, 37);
            Console.Write("请按E键继续投掷色子");
            Console.SetCursorPosition(2, 38);
        }

        static int Boom(Vector2[] totalPosition, int playerPosition, Vector2 drawStartPosition, int backwardSteps = 10)
        {
            Console.SetCursorPosition(totalPosition[playerPosition].x, totalPosition[playerPosition].y);
            Console.Write("□");
            //这里好像逻辑有问题

            if (totalPosition[playerPosition].y - drawStartPosition.y > 1)
            {
                playerPosition = playerPosition - backwardSteps;
            }
            else
            {
                playerPosition = playerPosition - backwardSteps > drawStartPosition.x - 2 ? playerPosition - backwardSteps : drawStartPosition.x - 2;
            }

            Console.SetCursorPosition(totalPosition[playerPosition].x, totalPosition[playerPosition].y);
            Console.Write("★");
            return playerPosition;

        }
        static string ChangeBlock()
        {
            return "x";
        }
    }
}
