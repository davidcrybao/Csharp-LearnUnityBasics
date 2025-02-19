﻿// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

int currentSceneID = 1;
int height = 35;
int width = 50;
Console.SetWindowSize(width, height);
Console.SetBufferSize(width, height);
Console.CursorVisible = false;
int zPosition = 8;
int xPosition = 0;
string title = "";


int index = 0;

while (true)
{
    switch (currentSceneID)
    {
        case 0:

            title = "营救公主计划";
            xPosition = GetCharCount(title);
            Console.SetCursorPosition(xPosition, zPosition - 3);
            Console.WriteLine(title);
            xPosition = GetCharCount("开始游戏");
            #region 开始游戏界面
            while (true)
            {
                bool isSceneOver = false;
                Console.SetCursorPosition(xPosition, zPosition);
                Console.ForegroundColor = index == 0 ? ConsoleColor.Red : ConsoleColor.White;
                Console.WriteLine("开始游戏");
                Console.SetCursorPosition(xPosition, zPosition + 2);
                Console.ForegroundColor = index == 1 ? ConsoleColor.Red : ConsoleColor.White;
                Console.WriteLine("结束游戏");

                ConsoleKey input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.W:
                        index = 0;
                        break;

                    case ConsoleKey.S:
                        index = 1;
                        break;

                    case ConsoleKey.E:

                        if (index == 0)
                        {
                            currentSceneID = 1;
                            isSceneOver = true;
                            Debug.WriteLine("开始游戏");
                        }
                        else
                        {
                            Debug.WriteLine("结束游戏");
                            Environment.Exit(0);
                        }
                        break;
                }
                if (isSceneOver)
                {
                    break;
                }
            }
            break;
        #endregion
        case 1:
            Console.Clear();
            Random randomPosition = new Random();
            bool generateWallAndEnemy = false;
            bool isBattling = false;
            bool isBossDefeated = false;
            bool isGameOver = false;
            #region 敌人和围墙的生成

            if (!generateWallAndEnemy)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                for (int i = 0; i < height; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("■");
                    Console.SetCursorPosition(width - 2, i);
                    Console.Write("■");
                }

                for (int i = 0; i < width; i += 2)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("■");
                    Console.SetCursorPosition(i, height - 1);
                    Console.Write("■");
                    Console.SetCursorPosition(i, height - 6);
                    Console.Write("■");
                }
                /*     Console.SetCursorPosition(0, 0);
                     for (int i = 0; i < height; i++)
                     {
                         Console.WriteLine("■");
                     }*/

                generateWallAndEnemy = true;
            }


            #endregion 敌人和围墙的生成

            #region Boss属性相关
            int enemyX = randomPosition.Next(2, 23) * 2;
            int enemyY = randomPosition.Next(1, 14) * 2;
            int enemyHP = 100;
            int enemyAttackMax = 15;
            int enemyAttackMin = 9;
            ConsoleColor bossColor = ConsoleColor.Yellow;
            string bossIcon = "■";
            #endregion

            #region 玩家属性相关
            int playerAttackMin = 8;
            int playerAttackMax = 13;
            int playerHP = 100;
            int playerX = 2;
            int playerY = 2;
            string playerIcon = "●";

            #endregion

            #region 公主属性相关

            int princessX = 20;
            int princessY = 20;
            ConsoleColor princessColor = ConsoleColor.DarkBlue;
            string princessIcon = "◆";
            #endregion

            while (true)
            {

                #region Boss绘制

                if (enemyHP > 0)
                {
                    Console.SetCursorPosition(enemyX, enemyY);
                    Console.ForegroundColor = bossColor;
                    Console.WriteLine(bossIcon);
                }
                #endregion
                #region 8 公主绘制
                else
                {
                    Console.SetCursorPosition(princessX, princessY);
                    Console.ForegroundColor = princessColor;
                    Console.WriteLine(princessIcon);
                }
                #endregion


                #region  玩家绘制-检测输入

                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(playerX, playerY);
                Console.Write(playerIcon);
                //玩家输入
                ConsoleKey input = Console.ReadKey(true).Key;
                #endregion

                if (!isBattling)
                {
                    #region 玩家移动代码 检测敌人
                    Console.SetCursorPosition(playerX, playerY);
                    Console.Write("  ");

                    switch (input)
                    {
                        case ConsoleKey.W:
                            playerY--;
                            if (playerY < 1)
                            {
                                playerY = 1;
                            }
                            else if (playerX == enemyX && playerY == enemyY && enemyHP > 0 || (isBossDefeated && playerX == 20 && playerY == 20))
                            {
                                playerY++;
                            }

                            break;

                        case ConsoleKey.S:
                            playerY++;
                            if (playerY > 28)
                            {
                                playerY = 28;
                            }
                            else if (playerX == enemyX && playerY == enemyY && enemyHP > 0 || (isBossDefeated && playerX == 20 && playerY == 20))
                            {
                                playerY--;
                            }

                            break;

                        case ConsoleKey.A:
                            playerX -= 2;
                            if (playerX < 2)
                            {
                                playerX = 2;
                            }
                            else if (playerX == enemyX && playerY == enemyY && enemyHP > 0 || (enemyHP <= 0 && playerX == 20 && playerY == 20))
                            {
                                playerX += 2;
                            }
                            break;

                        case ConsoleKey.D:
                            playerX += 2;
                            if (playerX >= 46)
                            {
                                playerX = 46;
                            }
                            else if (playerX == enemyX && playerY == enemyY && enemyHP > 0 || (isBossDefeated && playerX == 20 && playerY == 20))
                            {
                                playerX -= 2;
                            }
                            break;
                        case ConsoleKey.Q:
                            //与敌人互动
                            if (((playerX == enemyX && MathF.Abs(playerY - enemyY) == 1) ||
         (playerY == enemyY && MathF.Abs(playerX - enemyX) == 2)) && enemyHP > 0)
                            {
                                isBattling = true;
                                Console.SetCursorPosition(2, height - 5);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("玩家遇到BOSS,准备按J继续");
                                Console.SetCursorPosition(2, height - 4);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Boss的血量是{0}    ", enemyHP);
                                Console.SetCursorPosition(2, height - 3);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("玩家的血量是{0}    ", playerHP);
                            }
                            //与公主互动
                            if (((playerX == princessX && MathF.Abs(playerY - princessY) == 1) ||
         (playerY == princessY && MathF.Abs(playerX - princessX) == 2)) && enemyHP <= 0)
                            {
                                currentSceneID = 2;
                                isGameOver = true;
                                break;
                            }

                            break;
                    }

                    #endregion
                }
                //战斗逻辑
                else
                {
                    #region 攻击初始化

                    Random random = new Random();
                    int playerAttack = 0;
                    int enemyAttack = 0;

                    #endregion


                    if (input == ConsoleKey.J)
                    {
                        //先判断玩家是否活着
                        if (playerHP < 0)
                        {
                            currentSceneID = 2;
                            break;
                        }//Boss是否被打败
                        else if (enemyHP <= 0)
                        {
                            //改变第一个显示的文本,不然还会提示按J继续
                            Console.SetCursorPosition(2, height - 5);
                            Console.Write("公主已出现,在你左下方,走进按Q进行交互!");

                            Console.SetCursorPosition(enemyX, enemyY);
                            Console.WriteLine("   ");
                            Console.SetCursorPosition(playerX, playerY);
                            isBattling = false;
                            isBossDefeated = true;
                        }
                        else //战斗-玩家先出手
                        {

                            playerAttack = random.Next(playerAttackMin, playerAttackMax);
                            enemyAttack = random.Next(enemyAttackMin, enemyAttackMax);
                            enemyHP -= playerAttack;
                            Console.SetCursorPosition(2, height - 5);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("玩家正在与Boss进行战斗,按J继续");
                            Console.SetCursorPosition(2, height - 4);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("玩家对boss造成了{0}伤害,Boss的血量是{1}    ", playerAttack, enemyHP);


                            //怪兽打玩家
                            if (enemyHP > 0)
                            {
                                Console.SetCursorPosition(2, height - 3);
                                Console.ForegroundColor = ConsoleColor.White;
                                playerHP -= enemyAttack;


                                //Boss打败了玩家
                                if (playerHP <= 0)
                                {
                                    title = "游戏失败了,按E选择";
                                    Console.Write("很遗憾,你未能通过Boss失联,失败了           ");
                                }
                                else
                                {
                                    Console.Write("boss造成了{0}伤害,当前玩家的血量是{1}    ", enemyAttack, playerHP);
                                }
                            }
                            else  //打败boss 他的HP小于0
                            {
                                isBossDefeated = true;
                                title = "游戏胜利,按E选择";
                                Console.SetCursorPosition(2, height - 5);
                                Console.Write("恭喜你打败了boss,继续按J寻找公主");
                                Console.SetCursorPosition(2, height - 4);
                                Console.Write("                                             ");
                                Console.SetCursorPosition(2, height - 3);
                                Console.Write("                                             ");
                            }

                        }

                    }
                }

                //跳出当前场景  
                if (isGameOver)
                {
                    break;
                }
            }

            break;

        case 2:

            Console.Clear();
            xPosition = GetCharCount(title);
            Console.SetCursorPosition(xPosition, zPosition - 3);
            Console.WriteLine(title);
            xPosition = GetCharCount("重新开始");


            #region 结束界面
            while (true)
            {
                bool isSceneOver = false;
                Console.SetCursorPosition(xPosition, zPosition);
                Console.ForegroundColor = index == 0 ? ConsoleColor.Red : ConsoleColor.White;
                Console.WriteLine("重新开始");
                Console.SetCursorPosition(xPosition, zPosition + 2);
                Console.ForegroundColor = index == 1 ? ConsoleColor.Red : ConsoleColor.White;
                Console.WriteLine("结束游戏");

                ConsoleKey input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.W:
                        index = 0;
                        break;

                    case ConsoleKey.S:
                        index = 1;
                        break;

                    case ConsoleKey.E:

                        if (index == 0)
                        {
                            currentSceneID = 1;
                            isSceneOver = true;
                            Debug.WriteLine("重新开始");
                        }
                        else
                        {
                            Debug.WriteLine("结束游戏");
                            Environment.Exit(0);
                        }
                        break;
                }
                if (isSceneOver)
                {
                    break;
                }
            }
            #endregion
            break;
    }
}

/*bool CanWalk(ConsoleKey consoleKey,int positionX,int positionY)
{
    switch (consoleKey)
    {
        case ConsoleKey.W:
            if (y <= 2)
            {
                y = 2;
                break;
            }
            y--;
            break;

        case ConsoleKey.S:
            if (y >= 27)
            {
                y = 27;
                break;
            }
            y++;
            break;

        case ConsoleKey.A:
            if (x <= 2)
            {
                x = 2;
                break;
            }
            x = x - 2;
            break;

        case ConsoleKey.D:
            if (x >= 46)
            {
                x = 46;
                break;
            }
            x = x + 2;
            break;
    }
}*/
int GetCharCount(string text)
{
    int count = 0;
    foreach (Char c in text)
    {
        count++;
    }
    return width / 2 - count;
}
